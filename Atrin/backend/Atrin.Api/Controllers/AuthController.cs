using Atrin.Api.Middleware;
using Atrin.Application.Common.Models;
using Atrin.Shared;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Atrin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IMediator mediator, ILogger<AuthController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        // Implementation will be added in application layer
        // This is a placeholder structure for the foundation
        return Ok(new AuthResult(
            "sample_access_token",
            "sample_refresh_token",
            DateTime.UtcNow.AddMinutes(60)
        ));
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        return CreatedAtAction(nameof(Login), new AuthResult(
            "sample_access_token",
            "sample_refresh_token",
            DateTime.UtcNow.AddMinutes(60)
        ));
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(AuthResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        return Ok(new AuthResult(
            "new_access_token",
            "new_refresh_token",
            DateTime.UtcNow.AddMinutes(60)
        ));
    }

    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        return Ok();
    }
}





