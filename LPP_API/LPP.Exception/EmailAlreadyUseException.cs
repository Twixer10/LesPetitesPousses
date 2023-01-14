namespace LPP.API.Exception;

public class EmailAlreadyUseException : System.Exception
{
    public EmailAlreadyUseException() {}
    public EmailAlreadyUseException(string message) : base(message) { }
    public EmailAlreadyUseException(string message, System.Exception inner) : base(message, inner) { }
}