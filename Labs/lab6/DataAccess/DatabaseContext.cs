using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(builder =>
        {
            builder.HasMany(x => x.Messages).WithOne(x => x.Employee);
        });

        modelBuilder.Entity<Record>(builder =>
        {
            builder.HasOne(x => x.Employee);
        });

        modelBuilder.Entity<Message>(builder =>
        {
            builder.HasOne(x => x.Employee);
        });

        modelBuilder.Entity<Account>();
    }
}