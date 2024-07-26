using FluentValidation.Results;

namespace B.SimpleBooking.Application.Services.ResultPattern.CustomErrors;
public class ValidationError : Error
{
    public List<ValidationFailure> Failures { get; private set; }

    public ValidationError(List<ValidationFailure> failures) : base("Validation Error")
    {
        Failures = failures;
    }

    public ValidationError(ValidationFailure failure) : base("Validation Error")
    {
        Failures = new List<ValidationFailure> { failure };
    }

    public ValidationError(ValidationResult validationResult) : base("Validation Error")
    {
        Failures = validationResult.Errors;
    }
}
