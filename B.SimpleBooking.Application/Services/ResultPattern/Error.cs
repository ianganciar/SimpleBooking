namespace B.SimpleBooking.Application.Services.ResultPattern;
public abstract class Error
{
    public string Message { get; }

    protected Error(string message)
    {
        Message = message;
    }
}
