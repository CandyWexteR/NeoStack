using Core.Exceptions;

namespace Core.Models;

public class Person
{
    private Person(long id, string name, string displayName, Skill[] skills)
    {
        Id = id;
        Name = name;
        DisplayName = displayName;
        Skills = skills;
    }

    public long Id { get; protected set; }
    public string Name { get; protected set; }
    public string DisplayName { get; protected set; }
    public Skill[] Skills { get; protected set; }

    public static Person Create(long id, string name, string displayName, Skill[] skills)
    {
        ValidateValues(name, displayName);

        return new Person(id, name, displayName, skills);
    }

    public void ChangeInfo(string name, string displayName, Skill[] skills)
    {
        ValidateValues(name, displayName);

        Name = name;
        DisplayName = displayName;
        Skills = skills;
    }

    private static void ValidateValues(string name, string displayName)
    {
        var exceptions = new List<NeoStackException>();

        if (name.IsEmpty())
            exceptions.Add(new InvalidValueException("Имя пользователя не может быть пустым"));

        if (displayName.IsEmpty())
            exceptions.Add(new InvalidValueException("Отображаемое имя пользователя не может быть пустым"));

        if (exceptions.Any())
            throw new NeoStackAggregateException("Произошла ошибка при регистрации информации о новом пользвателе:",
                exceptions.ToArray());
    }
}