namespace Application.PersonServices.ViewModels;

public class PersonViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public SkillViewModel[] Skills { get; set; }
}