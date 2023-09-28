using ManageSchool_API.Data;
using ManageSchool_API.Models;
using ManageSchool_API.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace ManageSchool_API.Services;

public class SchoolSubjectService : IBaseInterfaceService<SchoolSubject>
{
    private readonly AppDbContext _appDbContext;
    private readonly TeacherService _teacherService;
    public SchoolSubjectService(AppDbContext appDbContext, TeacherService teacherService)
    {
        _appDbContext = appDbContext;
        _teacherService = teacherService;
    }

    public async Task Add(SchoolSubject schoolSubject)
    {
        await _appDbContext.SchoolSubject.AddAsync(schoolSubject);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var schoolSubject = await Get(id);

        _appDbContext.SchoolSubject.Remove(schoolSubject);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<SchoolSubject> Get(int id)
    {
        var schoolSubject = await _appDbContext.SchoolSubject.FirstOrDefaultAsync(t => t.Id == id);
        if(schoolSubject == null){
            throw new Exception("Matéria escolar não encontrada");
        }

        schoolSubject.Teacher = await _teacherService.Get(schoolSubject.IdTeacher);
        return schoolSubject;
    }

    public async Task Update(int id, SchoolSubject schoolSubjectUpdated)
    {
        var schoolSubject = await Get(id);

        schoolSubject.Name = schoolSubjectUpdated.Name;
        schoolSubject.IdSchool = schoolSubjectUpdated.IdSchool;
        schoolSubject.IdTeacher = schoolSubjectUpdated.IdTeacher;
        schoolSubject.GradeStudent = schoolSubjectUpdated.GradeStudent;
        
        _appDbContext.SchoolSubject.Update(schoolSubject);
        await _appDbContext.SaveChangesAsync();
    }
}
