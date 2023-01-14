namespace LPP.API.Exception;

public class PseudoAlreadyUseException : System.Exception
{
    public PseudoAlreadyUseException() {}
    public PseudoAlreadyUseException(string message) : base(message) { }
    public PseudoAlreadyUseException(string message, System.Exception inner) : base(message, inner) { }
}