using System.ComponentModel.DataAnnotations.Schema;
using ManageSchool_API.Models.Abstract;

namespace ManageSchool_API.Models;
[Table("SCHOOLCLASSROOM")]
public class SchoolClassroom : Base{
    [ForeignKey("School")]
    public int IdSchool { get; set; }
    public ICollection<Student>? Students { get; set; }
}