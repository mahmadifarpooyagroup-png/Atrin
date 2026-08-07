namespace Atrin.Domain.ValueObjects;

public record EmailAddress
{
    public string Value { get; }

    private EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty", nameof(value));

        if (!value.Contains("@") || !value.Contains("."))
            throw new ArgumentException("Invalid email format", nameof(value));

        Value = value.ToLowerInvariant();
    }

    public static EmailAddress Create(string email) => new(email);

    public override string ToString() => Value;

    public static implicit operator string(EmailAddress email) => email.Value;
}

public record PhoneNumber
{
    public string Value { get; }

    private PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be empty", nameof(value));

        var cleaned = value.Replace("-", "").Replace(" ", "").Replace("+", "");
        
        if (!cleaned.All(char.IsDigit) || cleaned.Length < 10 || cleaned.Length > 15)
            throw new ArgumentException("Invalid phone number format", nameof(value));

        Value = value;
    }

    public static PhoneNumber Create(string phone) => new(phone);

    public override string ToString() => Value;

    public static implicit operator string(PhoneNumber phone) => phone.Value;
}

public record PersianDate
{
    public DateTime Value { get; }

    private PersianDate(DateTime value)
    {
        Value = value;
    }

    public static PersianDate Create(DateTime date) => new(date);

    public string ToPersianString()
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        var year = persianCalendar.GetYear(Value);
        var month = persianCalendar.GetMonth(Value);
        var day = persianCalendar.GetDayOfMonth(Value);
        return $"{year}/{month:D2}/{day:D2}";
    }

    public static implicit operator DateTime(PersianDate date) => date.Value;
}
