using System.ComponentModel.DataAnnotations.Schema;
using ManageSchool_API.Models.Abstract;

namespace ManageSchool_API.Models;
[Table("STUDENT")]
public class Student : Base{
    [ForeignKey("School")]
    public int IdSchool { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    [ForeignKey("SchoolClassroom")]
    public int? IdSchoolClassroom { get; set; }
    public SchoolClassroom? SchoolClassroom { get; set; }
}