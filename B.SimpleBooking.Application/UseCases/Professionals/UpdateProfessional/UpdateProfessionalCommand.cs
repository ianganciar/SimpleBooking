using B.SimpleBooking.Application.Services.ResultPattern;
using D.SimpleBooking.Domain.ValueObjects;
using MediatR;

namespace B.SimpleBooking.Application.UseCases.Professionals.UpdateProfessional;
public record UpdateProfessionalCommand(
    int Id,
    Name Name,
    string Description,
    Address Address
    ) : IRequest<Result<int>>;
