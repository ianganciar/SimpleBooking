
namespace D.SimpleBooking.Domain.ValueObjects;

public class Address(string street, string number, string complement, string neighborhood, string city, string state, string zipCode) : ValueObject
{
    public string Street { get; private set; } = street;
    public string Number { get; private set; } = number;
    public string Complement { get; private set; } = complement;
    public string Neighborhood { get; private set; } = neighborhood;
    public string City { get; private set; } = city;
    public string State { get; private set; } = state;
    public string ZipCode { get; private set; } = zipCode;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return Complement;
        yield return Neighborhood;
        yield return City;
        yield return State;
        yield return ZipCode;
    }
}