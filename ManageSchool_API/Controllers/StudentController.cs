using ManageSchool_API.Models;
using ManageSchool_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchool_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase{
    private readonly StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent([FromRoute] int id){
        try{
            var student = await _studentService.Get(id);
            return Ok(student);
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostStudent([FromBody] Student student){
        try{
            await _studentService.Add(student);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    } 

    [HttpPut("{id}")]
    public async Task<ActionResult> PutStudent([FromRoute] int id, [FromBody] Student student){
        try{
            await _studentService.Update(id, student);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent([FromRoute] int id){
        try{
            await _studentService.Delete(id);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }
}