using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class ProgressDbContext : DbContext
{
    public DbSet<Faculty>? Faculties { get; set; }
    public DbSet<Group>? Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Mark>? Marks { get; set; }
    public DbSet<Progress>? Progresses { get; set; }
    public DbSet<Subject>? Subjects { get; set; }

    public ProgressDbContext(DbContextOptions<ProgressDbContext> options) : base(options)
    {
    }
}