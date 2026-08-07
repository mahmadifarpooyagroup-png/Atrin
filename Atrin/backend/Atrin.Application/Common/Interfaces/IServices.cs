namespace Atrin.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserName { get; }
    bool IsAuthenticated { get; }
}

public interface IDateTimeService
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public interface ISmsService
{
    Task SendSmsAsync(string phoneNumber, string message);
}

public interface ITokenService
{
    string GenerateJwtToken(string userId, string userName, IEnumerable<string> roles);
}
