using ManageSchool_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageSchool_API.Data.Map {
    public class SchoolGradesMap : IEntityTypeConfiguration<SchoolGrades> {
        public void Configure(EntityTypeBuilder<SchoolGrades> builder) {
            builder.ToTable("SCHOOLGRADESSTUDENT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Semester)
                .HasColumnName("Semester");
        }
    }
}
