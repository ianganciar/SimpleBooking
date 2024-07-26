
using System.Text.RegularExpressions;

namespace D.SimpleBooking.Domain.ValueObjects;
public class Email : ValueObject
{
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            //Result.Fail<string>("Invalid email address.");            
        }

        Value = value;
    }

    public string Value { get; }
       
    public bool IsValid()
    {
        string emailRegexPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return Regex.IsMatch(Value, emailRegexPattern);
    }

    protected override IEnumerable<object> GetEqualityComponents() => [Value];
}
