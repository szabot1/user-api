using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Data;

public class UsersContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Age).IsRequired();
            entity.Property(e => e.RegistrationTime).IsRequired();
            entity.ToTable("users");
        });
    }

}