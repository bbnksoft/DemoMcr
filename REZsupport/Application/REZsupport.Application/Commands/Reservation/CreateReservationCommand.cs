using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Reservation;

namespace REZsupport.Application.Commands.Reservation;

public class CreateReservationCommand : IRequest<ApiResponse<ReservationDto>>
{
    public CreateReservationDto Reservation { get; set; } = null!;

    public CreateReservationCommand(CreateReservationDto reservation)
    {
        Reservation = reservation;
    }
}
