using ManageSchool_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SchoolController : ControllerBase{
    private readonly SchoolService _schoolService;
    public SchoolController(SchoolService schoolService)
    {
        _schoolService = schoolService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<School>> GetStudent([FromRoute] int id){
        try{
            var student = await _schoolService.Get(id);
            return Ok(student);
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostStudent([FromBody] School school){
        try{
            await _schoolService.Add(school);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    } 

    [HttpPut("{id}")]
    public async Task<ActionResult> PutStudent([FromRoute] int id, [FromBody] School school){
        try{
            await _schoolService.Update(id, school);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent([FromRoute] int id){
        try{
            await _schoolService.Delete(id);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

}