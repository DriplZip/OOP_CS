namespace BusinessLogic.Exceptions;

public class BusinessLogicException : Exception
{
    protected BusinessLogicException(string message)
        : base(message) { }
}