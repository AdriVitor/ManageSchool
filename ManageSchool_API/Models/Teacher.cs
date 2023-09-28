using System.ComponentModel.DataAnnotations.Schema;
using ManageSchool_API.Models.Abstract;

namespace ManageSchool_API.Models;

[Table("TEACHER")]
public class Teacher : Base{
    [ForeignKey("School")]
    public int IdSchool { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    //public ICollection<SchoolSubject>? SchoolSubjects { get; set; }
}