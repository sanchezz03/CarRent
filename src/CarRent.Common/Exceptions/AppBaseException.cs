namespace CarRent.Common.Exceptions;

public class AppBaseException : ApplicationException
{
    public string Title { get; protected set; }
    public AppBaseException() : base()
    {
    }

    public AppBaseException(string? message) : base(message)
    {
    }

    public AppBaseException(string message, string title) : base(message)
    {
        Title = title;
    }

    public AppBaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public AppBaseException(string message, string title, Exception inner) : base(message, inner)
    {
        Title = title;
    }
}
