using MediatR;
using REZsupport.Application.Commands.Reservation;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Reservation;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Reservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ApiResponse<ReservationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateReservationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<ReservationDto>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate event exists
            var eventEntity = await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == request.Reservation.EventId, cancellationToken);

            if (eventEntity == null)
            {
                return ApiResponse<ReservationDto>.ErrorResponse("Event not found or inactive", new List<string> { "Invalid event ID" });
            }

            // Validate contact exists
            var contactExists = await _context.Contacts
                .AnyAsync(c => c.ContactId == request.Reservation.PrimaryContactId && c.TenantId == request.Reservation.TenantId, cancellationToken);

            if (!contactExists)
            {
                return ApiResponse<ReservationDto>.ErrorResponse("Contact not found", new List<string> { "Invalid contact ID" });
            }

            // Generate reservation number
            var reservationNumber = await GenerateReservationNumber(request.Reservation.TenantId, cancellationToken);

            // Calculate totals
            var subtotal = request.Reservation.Products.Sum(p => p.UnitPrice * p.Occupancy.GetValueOrDefault(1));
            var taxAmount = subtotal * 0.10m; // 10% tax
            var feesAmount = subtotal * 0.05m; // 5% fees
            var totalAmount = subtotal + taxAmount + feesAmount;

            var reservation = new Infrastructure.Persistence.Entities.Reservation
            {
                ReservationId = Guid.NewGuid(),
                TenantId = request.Reservation.TenantId,
                EventId = request.Reservation.EventId,
                PrimaryContactId = request.Reservation.PrimaryContactId,
                CompanyId = request.Reservation.CompanyId,
                GroupId = request.Reservation.GroupId,
                ReservationNumber = reservationNumber,
                ReservationStatus = request.Reservation.ReservationStatus ?? "Pending",
                BookingDate = DateTime.UtcNow,
                SubtotalAmount = subtotal,
                TaxAmount = taxAmount,
                FeesAmount = feesAmount,
                DiscountAmount = 0,
                TotalAmount = totalAmount,
                Currency = "USD",
                AmountPaid = 0,
                AmountDue = totalAmount,
                PaymentStatus = "Pending",
                TotalGuests = request.Reservation.TotalGuests.GetValueOrDefault(0),
                AdultCount = request.Reservation.AdultCount.GetValueOrDefault(0),
                ChildCount = request.Reservation.ChildCount.GetValueOrDefault(0),
                BookingSource = request.Reservation.BookingSource,
                SpecialRequests = request.Reservation.SpecialRequests,
                CreatedDate = DateTime.UtcNow
            };

            _context.Reservations.Add(reservation);

            // Add reservation products
            foreach (var productDto in request.Reservation.Products)
            {
                var reservationProduct = new ReservationProduct
                {
                    ReservationProductId = Guid.NewGuid(),
                    ReservationId = reservation.ReservationId,
                    ProductId = productDto.ProductId,
                    TenantId = request.Reservation.TenantId,
                    Occupancy = productDto.Occupancy.GetValueOrDefault(1),
                    UnitPrice = productDto.UnitPrice,
                    SubtotalAmount = productDto.UnitPrice * productDto.Occupancy.GetValueOrDefault(1),
                    TaxAmount = productDto.UnitPrice * productDto.Occupancy.GetValueOrDefault(1) * 0.10m,
                    TotalAmount = productDto.UnitPrice * productDto.Occupancy.GetValueOrDefault(1) * 1.10m,
                    Status = "Confirmed",
                    CreatedDate = DateTime.UtcNow
                };
                _context.ReservationProducts.Add(reservationProduct);
            }

            // Add guests
            foreach (var guestDto in request.Reservation.Guests)
            {
                var guest = new ReservationGuest
                {
                    GuestId = Guid.NewGuid(),
                    ReservationId = reservation.ReservationId,
                    ContactId = guestDto.ContactId,
                    TenantId = request.Reservation.TenantId,
                    GuestType = guestDto.GuestType ?? "Adult",
                    FirstName = guestDto.FirstName,
                    LastName = guestDto.LastName,
                    Email = guestDto.Email,
                    Phone = guestDto.Phone,
                    DateOfBirth = guestDto.DateOfBirth,
                    PassportNumber = guestDto.PassportNumber,
                    PassportExpiry = guestDto.PassportExpiry,
                    CheckInStatus = "NotCheckedIn",
                    CreatedDate = DateTime.UtcNow
                };
                _context.ReservationGuests.Add(guest);
            }

            await _context.SaveChangesAsync(cancellationToken);

            // Fetch created reservation with related data
            var createdReservation = await _context.Reservations
                .Include(r => r.Event)
                .Include(r => r.PrimaryContact)
                .Include(r => r.ReservationProducts)
                .Include(r => r.ReservationGuests)
                .FirstOrDefaultAsync(r => r.ReservationId == reservation.ReservationId, cancellationToken);

            var reservationDto = MapToDto(createdReservation!);

            return ApiResponse<ReservationDto>.SuccessResponse(reservationDto, "Reservation created successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<ReservationDto>.ErrorResponse("Failed to create reservation", new List<string> { ex.Message });
        }
    }

    private async Task<string> GenerateReservationNumber(Guid tenantId, CancellationToken cancellationToken)
    {
        var year = DateTime.UtcNow.Year;
        var lastReservation = await _context.Reservations
            .Where(r => r.TenantId == tenantId && r.CreatedDate.Year == year)
            .OrderByDescending(r => r.CreatedDate)
            .FirstOrDefaultAsync(cancellationToken);

        var sequence = 1;
        if (lastReservation != null)
        {
            var lastNumber = lastReservation.ReservationNumber.Split('-').Last();
            if (int.TryParse(lastNumber, out var lastSeq))
            {
                sequence = lastSeq + 1;
            }
        }

        return $"RES-{year}-{sequence:D6}";
    }

    private ReservationDto MapToDto(Infrastructure.Persistence.Entities.Reservation reservation)
    {
        return new ReservationDto
        {
            ReservationId = reservation.ReservationId,
            TenantId = reservation.TenantId,
            EventId = reservation.EventId,
            EventName = reservation.Event?.EventName ?? string.Empty,
            PrimaryContactId = reservation.PrimaryContactId,
            PrimaryContactName = $"{reservation.PrimaryContact?.FirstName} {reservation.PrimaryContact?.LastName}",
            ReservationNumber = reservation.ReservationNumber,
            ReservationStatus = reservation.ReservationStatus,
            BookingDate = reservation.BookingDate,
            ConfirmationDate = reservation.ConfirmationDate,
            SubtotalAmount = reservation.SubtotalAmount,
            TaxAmount = reservation.TaxAmount,
            FeesAmount = reservation.FeesAmount,
            DiscountAmount = reservation.DiscountAmount,
            TotalAmount = reservation.TotalAmount,
            Currency = reservation.Currency,
            AmountPaid = reservation.AmountPaid,
            AmountDue = reservation.AmountDue,
            PaymentStatus = reservation.PaymentStatus,
            TotalGuests = reservation.TotalGuests,
            AdultCount = reservation.AdultCount,
            ChildCount = reservation.ChildCount,
            BookingSource = reservation.BookingSource,
            CreatedDate = reservation.CreatedDate,
            Products = reservation.ReservationProducts?.Select(rp => new ReservationProductDto
            {
                ReservationProductId = rp.ReservationProductId,
                ProductId = rp.ProductId,
                ProductName = rp.Product?.ProductName ?? string.Empty,
                ProductCode = rp.Product?.ProductCode,
                Occupancy = rp.Occupancy,
                UnitPrice = rp.UnitPrice,
                SubtotalAmount = rp.SubtotalAmount,
                TaxAmount = rp.TaxAmount,
                TotalAmount = rp.TotalAmount,
                Status = rp.Status
            }).ToList() ?? new List<ReservationProductDto>(),
            Guests = reservation.ReservationGuests?.Select(g => new ReservationGuestDto
            {
                GuestId = g.GuestId,
                ContactId = g.ContactId,
                GuestType = g.GuestType,
                FirstName = g.FirstName,
                LastName = g.LastName,
                Email = g.Email,
                Phone = g.Phone,
                DateOfBirth = g.DateOfBirth,
                CheckInStatus = g.CheckInStatus
            }).ToList() ?? new List<ReservationGuestDto>()
        };
    }
}
