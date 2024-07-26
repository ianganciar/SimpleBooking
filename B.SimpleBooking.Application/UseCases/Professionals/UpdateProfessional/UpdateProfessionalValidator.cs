using B.SimpleBooking.Application.Services.ResultPattern.ErrorMessages;
using FluentValidation;

namespace B.SimpleBooking.Application.UseCases.Professionals.UpdateProfessional;
public class UpdateProfessionalValidator : AbstractValidator<UpdateProfessionalCommand>
{
    public UpdateProfessionalValidator()
    {
        RuleFor(p => p.Id)
           .Must(id => int.TryParse(id.ToString(), out _))
           .GreaterThan(0).WithMessage("The Id must be a positive integer.");


        RuleFor(p => p.Name.FirstName)
            .NotEmpty().WithMessage(ErrorMessages.NAME_EMPTY)
            .MaximumLength(50).WithMessage(ErrorMessages.NAME_TOO_LONG);

        RuleFor(p => p.Name.LastName)
            .NotEmpty().WithMessage(ErrorMessages.NAME_EMPTY)
            .MaximumLength(50).WithMessage(ErrorMessages.NAME_TOO_LONG);

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(ErrorMessages.DESCRIPTION_EMPTY)
            .MinimumLength(10).WithMessage(ErrorMessages.DESCRIPTION_TOO_SHORT)
            .MaximumLength(500).WithMessage(ErrorMessages.DESCRIPTION_TOO_LONG);

        RuleFor(p => p.Address.Street)
            .NotEmpty().WithMessage(ErrorMessages.ADDRESS_STREET_EMPTY)
            .MaximumLength(100).WithMessage(ErrorMessages.ADDRESS_STREET_TOO_LONG);

        RuleFor(p => p.Address.Number)
            .NotEmpty().WithMessage(ErrorMessages.ADDRESS_NUMBER_EMPTY)
            .MaximumLength(10).WithMessage(ErrorMessages.ADDRESS_NUMBER_TOO_LONG);

        RuleFor(p => p.Address.Complement)
            .MaximumLength(50).WithMessage(ErrorMessages.ADDRESS_COMPLEMENT_TOO_LONG);

        RuleFor(p => p.Address.Neighborhood)
            .NotEmpty().WithMessage(ErrorMessages.ADDRESS_NEIGHBORHOOD_EMPTY)
            .MaximumLength(50).WithMessage(ErrorMessages.ADDRESS_NEIGHBORHOOD_TOO_LONG);

        RuleFor(p => p.Address.City)
            .NotEmpty().WithMessage(ErrorMessages.ADDRESS_CITY_EMPTY)
            .MaximumLength(50).WithMessage(ErrorMessages.ADDRESS_CITY_TOO_LONG);

        RuleFor(p => p.Address.State)
            .NotEmpty().WithMessage(ErrorMessages.ADDRESS_STATE_EMPTY)
            .Length(2).WithMessage(ErrorMessages.ADDRESS_STATE_INVALID_LENGTH);

        RuleFor(p => p.Address.ZipCode)
            .NotEmpty().WithMessage(ErrorMessages.ADDRESS_ZIPCODE_EMPTY)
            .MaximumLength(10).WithMessage(ErrorMessages.ADDRESS_ZIPCODE_TOO_LONG);
    }
}
