namespace Atrin.Application.Common.Models;

public record AuthResult(
    string AccessToken,
    string RefreshToken,
    DateTime ExpiresAt
);

public record LoginRequest(
    string Email,
    string Password
);

public record RegisterRequest(
    string Email,
    string Password,
    string FullName
);

public record RefreshTokenRequest(
    string AccessToken,
    string RefreshToken
);
