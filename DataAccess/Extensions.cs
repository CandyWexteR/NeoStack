using Core.Models;
using DataAccess.Entities;

namespace DataAccess;

public static class Extensions
{
    public static Person FromDto(this PersonDTO model, SkillDTO[] skillsDtos)
    {
        var skills = skillsDtos.Select(f => f.FromDto()).ToArray();
        return Person.Create(model.Id, model.Name, model.DisplayName, skills);
    }

    public static PersonDTO ToDto(this Person model, out SkillDTO[] skills)
    {
        skills = model.Skills.Select(f => f.ToDto(model.Id)).ToArray();
        return new PersonDTO()
        {
            Name = model.Name,
            DisplayName = model.DisplayName,
            Id = model.Id
        };
    }

    public static Skill FromDto(this SkillDTO skill) =>
        Skill.Create(skill.Name, skill.Level);

    public static SkillDTO ToDto(this Skill skill, long personId) =>
        new SkillDTO()
        {
            Id = Guid.NewGuid(),
            Name = skill.Name,
            Level = skill.Level,
            PersonId = personId
        };
}