using Domic.Core.Domain.Entities;
using Domic.Core.Persistence.Configs;
using Microsoft.EntityFrameworkCore;

namespace Domic.Persistence.Contexts;

/*Setting*/
public partial class SQLContext : DbContext
{
    public SQLContext(DbContextOptions<SQLContext> options) : base(options)
    {
        
    }
}

/*Entity*/
public partial class SQLContext
{
    public DbSet<Event> Events { get; set; }
}

/*Config*/
public partial class SQLContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new EventConfig());
    }
}