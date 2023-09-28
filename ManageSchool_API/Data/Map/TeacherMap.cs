using ManageSchool_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageSchool_API.Data.Configuration;

public class TeacherMap : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("TEACHER");

        builder.HasKey(t=>t.Id);

        /*builder.HasMany(t=>t.SchoolSubjects)
            .WithOne(t=>t.Teacher)
            .HasForeignKey(t=>t.IdTeacher)
            .HasPrincipalKey(t=>t.Id);*/
    }
}