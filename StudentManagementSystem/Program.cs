using Microsoft.EntityFrameworkCore;

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
    public String Credits { get; set; }
}

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int Grade { get; set; }
    
    public Student Student { get; set; }
    public Course Course { get; set; }
}

public class StudentManagementContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    
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
    }
}

class Program
{
    static void Main()
    {
    }
}