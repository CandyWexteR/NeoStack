namespace Application.PersonServices.InputModels;

public class PersonInputModel
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public List<SkillInputModel> Skills { get; set; }
}