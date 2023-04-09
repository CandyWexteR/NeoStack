using Core.Exceptions;

namespace Core.Models;

public class Skill
{
    public const string MainMessage = "Не удалось зарегистрировать навык, так как произошла одна " +
                                       "или несколько ошибок";

    private Skill(string name, byte level)
    {
        Name = name;
        Level = level;
    }

    public string Name { get; protected set; }
    public byte Level { get; protected set; }

    public static Skill Create(string name, byte level)
    {
        var exceptions = new List<NeoStackException>();

        if (name.IsEmpty())
            exceptions.Add(new InvalidValueException("Название навыка не может быть пустым"));

        if (!level.IsInRange(1, 10))
            exceptions.Add(new InvalidValueException("Навык пользователя должен быть в диапазоне [1;10] (от 1 до 10 включительно)."));

        if (exceptions.Any())
        {
            throw new NeoStackAggregateException(MainMessage, exceptions.ToArray());
        }

        return new Skill(name, level);
    }
}