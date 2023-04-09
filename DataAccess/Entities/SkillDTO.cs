namespace DataAccess.Entities;

public class SkillDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Level { get; set; }
    public long PersonId { get; set; }
}