namespace B.SimpleBooking.Application.Services.ResultPattern.CustomErrors;
public class NotFoundError(string message) : Error(message)
{
}
