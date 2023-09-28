using ManageSchool_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageSchool_API.Data.Configuration;

public class SchoolClassroomMap : IEntityTypeConfiguration<SchoolClassroom>
{
    public void Configure(EntityTypeBuilder<SchoolClassroom> builder)
    {
        builder.ToTable("SCHOOLCLASSROOM");

        builder.HasKey(s=>s.Id);

        builder.HasMany(sc=>sc.Students)
            .WithOne(sc=>sc.SchoolClassroom)
            .HasForeignKey(sc=>sc.IdSchoolClassroom)
            .HasPrincipalKey(sc=>sc.Id);
    }
}