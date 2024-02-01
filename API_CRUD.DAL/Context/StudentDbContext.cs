using Microsoft.EntityFrameworkCore;
using API_CRUD.BL.Models;

namespace API_CRUD.DAL.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Lorem", Age = 16 },
                new Student { StudentId = 2, Name = "Kevin", Age = 15 },
                new Student { StudentId = 3, Name = "David", Age = 18 },
                new Student { StudentId = 4, Name = "Allen", Age = 10 },
                new Student { StudentId = 5, Name = "Ben", Age = 14 }
                );
        }
    }
}