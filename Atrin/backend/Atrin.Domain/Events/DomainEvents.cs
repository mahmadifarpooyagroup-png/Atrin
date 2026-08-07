namespace Atrin.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}

public abstract class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}

public class UserCreatedEvent : DomainEvent
{
    public Guid UserId { get; }
    public string Email { get; }

    public UserCreatedEvent(Guid userId, string email)
    {
        UserId = userId;
        Email = email;
    }
}

public class UserLoggedInEvent : DomainEvent
{
    public Guid UserId { get; }
    public DateTime LoginTime { get; }

    public UserLoggedInEvent(Guid userId, DateTime loginTime)
    {
        UserId = userId;
        LoginTime = loginTime;
    }
}
