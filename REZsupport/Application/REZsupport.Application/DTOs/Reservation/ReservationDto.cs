namespace REZsupport.Application.DTOs.Reservation;

public class ReservationDto
{
    public Guid ReservationId { get; set; }
    public Guid TenantId { get; set; }
    public Guid EventId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public Guid PrimaryContactId { get; set; }
    public string PrimaryContactName { get; set; } = string.Empty;
    public string ReservationNumber { get; set; } = string.Empty;
    public string? ReservationStatus { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime? ConfirmationDate { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal FeesAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Currency { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal AmountDue { get; set; }
    public string? PaymentStatus { get; set; }
    public int? TotalGuests { get; set; }
    public int? AdultCount { get; set; }
    public int? ChildCount { get; set; }
    public string? BookingSource { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<ReservationProductDto> Products { get; set; } = new();
    public List<ReservationGuestDto> Guests { get; set; } = new();
}

public class CreateReservationDto
{
    public Guid TenantId { get; set; }
    public Guid EventId { get; set; }
    public Guid PrimaryContactId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? GroupId { get; set; }
    public string? ReservationStatus { get; set; }
    public int? TotalGuests { get; set; }
    public int? AdultCount { get; set; }
    public int? ChildCount { get; set; }
    public string? BookingSource { get; set; }
    public string? SpecialRequests { get; set; }
    public List<CreateReservationProductDto> Products { get; set; } = new();
    public List<CreateReservationGuestDto> Guests { get; set; } = new();
}

public class UpdateReservationDto
{
    public string? ReservationStatus { get; set; }
    public int? TotalGuests { get; set; }
    public int? AdultCount { get; set; }
    public int? ChildCount { get; set; }
    public string? SpecialRequests { get; set; }
}

public class ReservationListDto
{
    public Guid ReservationId { get; set; }
    public string ReservationNumber { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string PrimaryContactName { get; set; } = string.Empty;
    public string? ReservationStatus { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string? PaymentStatus { get; set; }
    public int? TotalGuests { get; set; }
}

public class ReservationProductDto
{
    public Guid ReservationProductId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductCode { get; set; }
    public int? Occupancy { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
}

public class CreateReservationProductDto
{
    public Guid ProductId { get; set; }
    public int? Occupancy { get; set; }
    public decimal UnitPrice { get; set; }
}

public class ReservationGuestDto
{
    public Guid GuestId { get; set; }
    public Guid? ContactId { get; set; }
    public string? GuestType { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? CheckInStatus { get; set; }
}

public class CreateReservationGuestDto
{
    public Guid? ContactId { get; set; }
    public string? GuestType { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PassportNumber { get; set; }
    public DateTime? PassportExpiry { get; set; }
    public string? Nationality { get; set; }
}

public class PaymentDto
{
    public Guid PaymentId { get; set; }
    public Guid ReservationId { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public string? PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
    public string? PaymentStatus { get; set; }
    public string? TransactionId { get; set; }
    public string? ProcessorName { get; set; }
}

public class CreatePaymentDto
{
    public Guid ReservationId { get; set; }
    public Guid TenantId { get; set; }
    public string? PaymentType { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
    public string? PaymentMethodToken { get; set; }
}
