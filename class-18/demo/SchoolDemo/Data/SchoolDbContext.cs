using SchoolDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolDemo.Data
{
  public class SchoolDbContext : IdentityDbContext<ApplicationUser>
  {
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // This calls the base method, and Identity needs it
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Technology>().HasData(
        new Technology { Id = 1, Name = ".NET " },
        new Technology { Id = 2, Name = "Node.js" }
      );

      modelBuilder.Entity<Student>().HasData(
        new Student { Id = 1, FirstName = "Test", LastName = "User", DateOfBirth = DateTime.Parse("2020-02-01 12:00:00") }
      ); ;


      modelBuilder.Entity<Course>().HasData(
        new Course { Id = 1, CourseCode = "dotnet-401d12", Price = 4000, TechnologyId = 1 },
        new Course { Id = 2, CourseCode = "javascript-401n17", Price = 4000, TechnologyId = 2 }
      );

      modelBuilder.Entity<Enrollment>().HasData(
        new Enrollment { CourseId = 1, StudentId = 1 }
      );

      // This creates the composite primary key for the enrollments table
      modelBuilder.Entity<Enrollment>().HasKey(
        // Create a new "anonymous" type (like a JS object)
        enrollment => new { enrollment.CourseId, enrollment.StudentId }
      );
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }

    // This will fail the first time when you try to make a migration because there's no primary key (id)
    // Do a modelbuilder override, and then add it
    public DbSet<Enrollment> Enrollments { get; set; }
  }
}
