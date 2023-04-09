using Core.Models;

namespace Application.PersonServices.InputModels;

public static class InputModelExtensions
{
    public static Skill ToModel(this SkillInputModel model)
    {
        return Skill.Create(model.Name, model.Level);
    }
}