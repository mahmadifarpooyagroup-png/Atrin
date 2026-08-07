using MediatR;

namespace Atrin.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
