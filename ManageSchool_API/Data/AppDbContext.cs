using ManageSchool_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageSchool_API.Data;

public class AppDbContext : DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<SchoolClassroom> SchoolClassroom { get; set; }
    public DbSet<SchoolSubject> SchoolSubject { get; set; }
    public DbSet<School> School { get; set; }
    public DbSet<SchoolGrades> SchoolGrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-H7797U1\SQLEXPRESS;
                                    Database=ManageSchool;
                                    Integrated Security=True;
                                    Encrypt=False");
    }
}