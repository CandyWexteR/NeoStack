using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> ops) : base(ops)
    {
        // Database.EnsureCreated();
    }

    public DbSet<PersonDTO> Persons { get; set; }
    public DbSet<SkillDTO> Skills { get; set; }
}