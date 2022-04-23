using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Data;

public class StudentsProgressContext : DbContext
{
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Mark> Marks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=D:\Study\Labs\MPP\Lab3\Lab3\MPPLab3.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Progress>()
            .HasMany(p => p.Marks)
            .WithOne(m => m.Progress)
            .OnDelete(DeleteBehavior.Cascade);
    }
}