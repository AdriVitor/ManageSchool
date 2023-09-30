using ManageSchool_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageSchool_API.Data.Configuration;

public class StudentsMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("STUDENTS");

        builder.HasKey(s=>s.Id);

        builder.Property(s=>s.IdSchoolClassroom)
            .HasColumnName("IDSCHOOLCLASSROOM");
    }
}
