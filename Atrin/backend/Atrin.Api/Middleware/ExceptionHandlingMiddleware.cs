using System.Net;
using Atrin.Shared.Exceptions;

namespace Atrin.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var errorResponse = new ErrorResponse();

        switch (exception)
        {
            case AtrinException atrinEx:
                response.StatusCode = atrinEx.StatusCode;
                errorResponse = new ErrorResponse
                {
                    StatusCode = response.StatusCode,
                    Message = atrinEx.Message,
                    ErrorCode = atrinEx.ErrorCode
                };
                break;

            case FluentValidation.ValidationException validationEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse = new ErrorResponse
                {
                    StatusCode = response.StatusCode,
                    Message = "Validation failed",
                    ErrorCode = "VALIDATION_ERROR",
                    Errors = validationEx.Errors.Select(e => e.ErrorMessage).ToList()
                };
                break;

            default:
                _logger.LogError(exception, "An unhandled exception occurred");
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse = new ErrorResponse
                {
                    StatusCode = response.StatusCode,
                    Message = "An internal server error occurred",
                    ErrorCode = "INTERNAL_ERROR"
                };
                break;
        }

        await response.WriteAsJsonAsync(errorResponse);
    }
}

public record ErrorResponse
{
    public int StatusCode { get; init; }
    public string Message { get; init; } = string.Empty;
    public string ErrorCode { get; init; } = string.Empty;
    public List<string>? Errors { get; init; }
}
