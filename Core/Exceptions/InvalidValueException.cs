namespace Core.Exceptions;

public class InvalidValueException : NeoStackException
{
    public InvalidValueException(string message) : base(message)
    {
    }
}