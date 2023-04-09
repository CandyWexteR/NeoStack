using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApi.ContextFactory;

public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args)
    {
        var config =
            new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(typeof(MyContextFactory).Assembly.Location))
                .AddJsonFile("appsettings.json");
        var builder = new DbContextOptionsBuilder<MyContext>();

        builder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");

        return new MyContext(builder.Options);
    }
}