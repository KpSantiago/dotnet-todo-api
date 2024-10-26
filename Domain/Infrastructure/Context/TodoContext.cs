using api_dotnet.Domain.Enterprise.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Domain.Infrastructure.Context;

public class TodoContext : DbContext
{
    public DbSet<List> Lists { get; set; }

    public DbSet<Enterprise.Entities.Task> Tasks { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options: options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<List>()
            .HasMany(l => l.Tasks)
            .WithOne(t => t.List)
            .HasForeignKey(t => t.ListId);
    }
}
