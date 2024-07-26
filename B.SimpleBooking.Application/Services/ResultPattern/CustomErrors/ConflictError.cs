namespace B.SimpleBooking.Application.Services.ResultPattern.CustomErrors;
public class ConflictError : Error
{
    public ConflictError(string message) : base(message)
    {
    }
}
