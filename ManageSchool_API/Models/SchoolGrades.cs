using System.ComponentModel.DataAnnotations.Schema;
using ManageSchool_API.Models.Abstract;
using ManageSchool_API.Models.Enums;

namespace ManageSchool_API.Models;

[Table("SCHOOLGRADESSTUDENT")]
public class SchoolGrades {
    public int Id { get; set; }
    [ForeignKey("Student")]
    public int IdStudent { get; set; }
    [ForeignKey("School")]
    public int IdSchool { get; set; }
    [ForeignKey("SchoolSubject")]
    public int IdSchoolSubject { get; set; }
    public EnumSemester Semester { get; set; }
    public int Grade { get; set; }
    public bool? Approved { get; set; }
}