using ManageSchool_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageSchool_API.Data.Configuration;

public class SchoolSubjectMap : IEntityTypeConfiguration<SchoolSubject>
{
    public void Configure(EntityTypeBuilder<SchoolSubject> builder)
    {
        builder.ToTable("SCHOOLSUBJECTS");

        builder.HasKey(ss=>ss.Id);
    }
}
