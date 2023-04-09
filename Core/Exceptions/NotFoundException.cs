namespace Core.Exceptions;

public class NotFoundException : NeoStackException
{
    public NotFoundException(string message) : base(message)
    {
    }
}