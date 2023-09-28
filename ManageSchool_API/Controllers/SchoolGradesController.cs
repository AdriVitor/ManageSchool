using ManageSchool_API.Models;
using ManageSchool_API.Models.Enums;
using ManageSchool_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManageSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SchoolGradesController : ControllerBase{
    private readonly SchoolGradesService _schoolGradesService;
    public SchoolGradesController(SchoolGradesService schoolGradesService)
    {
        _schoolGradesService = schoolGradesService;
    }

    [HttpGet("{idStudent}")]
    public async Task<ActionResult<SchoolGrades>> GetSchoolGrade(
    [FromRoute] int idStudent, 
    [FromQuery(Name = "semester")][Required(ErrorMessage = "O queryParam semester é obrigatório")] EnumSemester enumSemester,
    [FromQuery(Name = "idSchool")][Required(ErrorMessage = "O queryParam idSchool é obrigatório")] int idSchool){
        try{
            var student = await _schoolGradesService.Get(idStudent, enumSemester, idSchool);
            return Ok(student);
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("all/semester/{id}")]
    public async Task<ActionResult> GetListSchoolGrades(
        [FromRoute] int idStudent,
        [FromQuery(Name = "idSchool")][Required(ErrorMessage = "O queryParam idSchool é obrigatório")] int idSchool){
        try{
            await _schoolGradesService.GetAllGradeSemester(idStudent, idSchool);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostSchoolGrade([FromBody] SchoolGrades schoolGrades){
        try{
            await _schoolGradesService.Add(schoolGrades);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    } 

    [HttpPut("{idStudent}")]
    public async Task<ActionResult> PutSchoolGrade([FromRoute] int idStudent, 
    [FromQuery(Name = "semester")][Required(ErrorMessage = "O queryParam semester é obrigatório")] EnumSemester enumSemester,
    [FromQuery(Name = "grade")][Required(ErrorMessage = "O queryParam grade é obrigatório")] int grade,
    [FromQuery(Name = "idSchool")][Required(ErrorMessage = "O queryParam idSchool é obrigatório")] int idSchool){
        try{
            await _schoolGradesService.Update(idStudent, enumSemester, grade, idSchool);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{idStudent}")]
    public async Task<ActionResult> DeleteSchoolGrade(
    [FromRoute] int idStudent, 
    [FromQuery(Name = "semester")][Required(ErrorMessage = "O queryParam semester é obrigatório")] EnumSemester enumSemester,
    [FromQuery(Name = "idSchool")][Required(ErrorMessage = "O queryParam idSchool é obrigatório")] int idSchool){
        try{
            await _schoolGradesService.Delete(idStudent, enumSemester, idSchool);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }
}