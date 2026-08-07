namespace Atrin.Shared.Exceptions;

public abstract class AtrinException : Exception
{
    public string ErrorCode { get; }
    public int StatusCode { get; }

    protected AtrinException(string message, string errorCode, int statusCode) 
        : base(message)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;
    }
}

public class NotFoundException : AtrinException
{
    public NotFoundException(string message) 
        : base(message, "NOT_FOUND", 404)
    {
    }
}

public class BadRequestException : AtrinException
{
    public BadRequestException(string message) 
        : base(message, "BAD_REQUEST", 400)
    {
    }
}

public class UnauthorizedException : AtrinException
{
    public UnauthorizedException(string message) 
        : base(message, "UNAUTHORIZED", 401)
    {
    }
}

public class ForbiddenException : AtrinException
{
    public ForbiddenException(string message) 
        : base(message, "FORBIDDEN", 403)
    {
    }
}

public class ConflictException : AtrinException
{
    public ConflictException(string message) 
        : base(message, "CONFLICT", 409)
    {
    }
}

public class InternalServerException : AtrinException
{
    public InternalServerException(string message) 
        : base(message, "INTERNAL_ERROR", 500)
    {
    }
}
