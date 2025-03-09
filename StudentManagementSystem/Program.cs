﻿using Microsoft.EntityFrameworkCore;

public class Student
{
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String MiddleName { get; set; }
    public String LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public String Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public String Title { get; set; }
    public decimal Credits { get; set; }
    public int InstructorId { get; set; }
    
    public Instructor Instructor { get; set; }
}

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int FinalGrade { get; set; }
    
    public Student Student { get; set; }
    public Course Course { get; set; }
}

public class Instructor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime HireDate { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public int? DepartmentHeadId { get; set; }
    public Instructor DepartmentHead { get; set; }
}


public class StudentManagementContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Department> Departments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=StudentManagement;Integrated Security=True;TrustServerCertificate=True;");

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => e.Id); 

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId); 

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany()
            .HasForeignKey(e => e.CourseId); 
        
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Instructor)
            .WithMany()
            .HasForeignKey(c => c.InstructorId);
        
        modelBuilder.Entity<Department>()
            .HasOne(d => d.DepartmentHead) 
            .WithMany() 
            .HasForeignKey(d => d.DepartmentHeadId)
            .OnDelete(DeleteBehavior.SetNull); 
    }
}

class Program
{
    static void Main()
    {
    }
}