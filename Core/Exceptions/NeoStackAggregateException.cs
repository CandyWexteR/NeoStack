namespace Core.Exceptions;

public class NeoStackAggregateException : NeoStackException
{
    public NeoStackAggregateException(string message) : base(message)
    {
    }

    public NeoStackAggregateException(string message, params NeoStackException[] inner) : base(inner.Aggregate(message, (s, exception) => s+=$"\n {exception.Message}"))
    {
    }
}