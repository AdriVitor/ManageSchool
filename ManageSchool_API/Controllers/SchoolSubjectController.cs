using ManageSchool_API.Models;
using ManageSchool_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolSubjectController : ControllerBase{
    private readonly SchoolSubjectService _schoolSubjectService;
    public SchoolSubjectController(SchoolSubjectService schoolSubjectService)
    {
        _schoolSubjectService = schoolSubjectService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SchoolSubject>> GetSchoolSubject([FromRoute] int id){
        try{
            var schoolSubject = await _schoolSubjectService.Get(id);
            return Ok(schoolSubject);
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostSchoolSubject([FromBody] SchoolSubject schoolSubject){
        try{
            await _schoolSubjectService.Add(schoolSubject);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    } 

    [HttpPut("{id}")]
    public async Task<ActionResult> PutSchoolSubject([FromRoute] int id, [FromBody] SchoolSubject schoolSubject){
        try{
            await _schoolSubjectService.Update(id, schoolSubject);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSchoolSubject([FromRoute] int id){
        try{
            await _schoolSubjectService.Delete(id);
            return Ok();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }

}