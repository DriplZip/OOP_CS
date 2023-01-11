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
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Employee>();
        modelBuilder.Entity<Record>();
        modelBuilder.Entity<Account>();
        modelBuilder.Entity<Message>();*/
        modelBuilder.Entity<Employee>(builder =>
        {
            builder.HasMany(x => x.Messages);
        });

        modelBuilder.Entity<Record>(builder =>
        {
            builder.HasMany(x => x.Messages);
        });

        modelBuilder.Entity<Account>(builder =>
        {
            builder.HasOne(x => x.Login);
            builder.HasOne(x => x.PasswordHash);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}