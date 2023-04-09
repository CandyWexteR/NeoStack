using Application.PersonServices.ViewModels;
using Core.Models;

namespace Application;

public static class ToViewModelExtensions
{
    public static SkillViewModel ToViewModel(this Skill value) => new SkillViewModel()
    {
        Name = value.Name,
        Level = value.Level
    };
    
    public static PersonViewModel ToViewModel(this Person value) => new PersonViewModel()
    {
        Id = value.Id,
        Name = value.Name,
        DisplayName = value.DisplayName,
        Skills = value.Skills.Select(f=> f.ToViewModel()).ToArray()
    };
}