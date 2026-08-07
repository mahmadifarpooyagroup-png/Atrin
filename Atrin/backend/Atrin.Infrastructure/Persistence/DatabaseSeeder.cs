using Atrin.Domain.Entities;
using Atrin.Shared.Constants;

namespace Atrin.Infrastructure.Persistence;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Roles.Any())
            return;

        var roles = new List<Role>
        {
            new() { Id = Guid.NewGuid(), Name = Roles.Admin, Description = "System Administrator" },
            new() { Id = Guid.NewGuid(), Name = Roles.Operator, Description = "Service Center Operator" },
            new() { Id = Guid.NewGuid(), Name = Roles.Customer, Description = "Regular Customer" }
        };

        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();

        if (context.Users.Any(u => u.Email == "admin@atrin.ir"))
            return;

        var adminUser = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@atrin.ir",
            FullName = "System Administrator",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await context.Users.AddAsync(adminUser);
        await context.SaveChangesAsync();

        var adminRole = roles.First(r => r.Name == Roles.Admin);
        var userRole = new UserRole
        {
            Id = Guid.NewGuid(),
            UserId = adminUser.Id,
            RoleId = adminRole.Id,
            CreatedAt = DateTime.UtcNow
        };

        await context.UserRoles.AddAsync(userRole);
        await context.SaveChangesAsync();
    }
}
