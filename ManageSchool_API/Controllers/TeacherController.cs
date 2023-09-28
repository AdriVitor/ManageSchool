using ManageSchool_API.Models;
using ManageSchool_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchool_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase{
    private readonly TeacherService _teacherService;
    public TeacherController(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacher([FromRoute] int id){
        try{
            var teacher = await _teacherService.Get(id);
            return Ok(teacher);
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostTeacher([FromBody] Teacher teacher){
        try{
            await _teacherService.Add(teacher);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    } 

    [HttpPut("{id}")]
    public async Task<ActionResult> PutTeacher([FromRoute] int id, [FromBody] Teacher teacher){
        try{
            await _teacherService.Update(id, teacher);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeacher([FromRoute] int id){
        try{
            await _teacherService.Delete(id);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }
}