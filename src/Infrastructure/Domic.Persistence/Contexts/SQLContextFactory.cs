using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Domic.Persistence.Contexts;

public class SQLContextFactory : IDesignTimeDbContextFactory<SQLContext>
{
    public SQLContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SQLContext> builder = new DbContextOptionsBuilder<SQLContext>();
        
        builder.UseSqlServer("something");

        return new SQLContext(builder.Options);
    }
}