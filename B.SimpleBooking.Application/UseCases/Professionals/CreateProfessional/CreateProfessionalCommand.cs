using B.SimpleBooking.Application.Services.ResultPattern;
using D.SimpleBooking.Domain.ValueObjects;
using MediatR;

namespace B.SimpleBooking.Application.UseCases.Professionals.CreateProfessional;
public record CreateProfessionalCommand(
    Name Name,
    Email Email, string Phone,
    string PasswordHash,
    string Description,
    Address Address
    ) : IRequest<Result<Unit>>;