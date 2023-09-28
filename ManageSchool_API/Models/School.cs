using System.ComponentModel.DataAnnotations.Schema;
using ManageSchool_API.Models.Abstract;

namespace ManageSchool_API.Models;

[Table("SCHOOL")]
public class School : Base{
    public string Name { get; set; }
}