using System.ComponentModel.DataAnnotations.Schema;
using ManageSchool_API.Models.Abstract;

namespace ManageSchool_API.Models;
[Table("SCHOOLSUBJECTS")]
public class SchoolSubject : Base{
    [ForeignKey("School")]
    public int IdSchool { get; set; }
    [ForeignKey("Teacher")]
    public int IdTeacher { get; set; }
    public Teacher? Teacher { get; set; }
    public Int16 GradeStudent { get; set; } 

    public SchoolSubject()
    {
        
    } 
}