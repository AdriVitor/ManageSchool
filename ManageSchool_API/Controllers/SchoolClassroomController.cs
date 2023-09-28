using ManageSchool_API.Models;
using ManageSchool_API.SchoolClasroom.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SchoolClassroomController : ControllerBase{
    private readonly SchoolClassroomService _schoolClassroomService;
    public SchoolClassroomController(SchoolClassroomService schoolClassroomService)
    {
        _schoolClassroomService = schoolClassroomService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SchoolClassroom>> GetSchoolClassroom([FromRoute] int id){
        try{
            var student = await _schoolClassroomService.Get(id);
            return Ok(student);
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostSchoolClassroom([FromBody] SchoolClassroom schoolClassroom){
        try{
            await _schoolClassroomService.Add(schoolClassroom);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    } 

    [HttpPut("{id}")]
    public async Task<ActionResult> PutSchoolClassroom([FromRoute] int id, [FromBody] SchoolClassroom schoolClassroom){
        try{
            await _schoolClassroomService.Update(id, schoolClassroom);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSchoolClassroom([FromRoute] int id){
        try{
            await _schoolClassroomService.Delete(id);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

}