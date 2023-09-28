using System.ComponentModel.DataAnnotations;

namespace ManageSchool_API.Models.Abstract;

public abstract class Base
{
    [Key()]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}