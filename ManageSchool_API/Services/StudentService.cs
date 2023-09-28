using ManageSchool_API.Data;
using ManageSchool_API.Models;
using ManageSchool_API.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using ManageSchool_API.SchoolClasroom.Services;

namespace ManageSchool_API.Services;

public class StudentService : IBaseInterfaceService<Student>{
    private readonly AppDbContext _appDbContext;
    private readonly SchoolClassroomService _schoolClassroomService;
    public StudentService(AppDbContext appDbContext, SchoolClassroomService schoolClassroomService)
    {
        _appDbContext = appDbContext;
        _schoolClassroomService = schoolClassroomService;
    }

    public async Task<Student> Get(int id){
        var student = await _appDbContext.Student.FirstOrDefaultAsync(s=>s.Id == id);
        if(student == null){
            throw new Exception("Não foi possivel encontrar o aluno");
        }

        if(student.IdSchoolClassroom != null){
            student.SchoolClassroom = await _schoolClassroomService.Get((int)student.IdSchoolClassroom);
        }
        
        return student;

    }

    public async Task Add(Student student){
        await _appDbContext.Student.AddAsync(student);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Update(int id, Student student){
        var studentUpdated = await Get(id);

        studentUpdated.Name = student.Name;
        studentUpdated.DateOfBirth = student.DateOfBirth;
        studentUpdated.Email = student.Email;
        studentUpdated.Password = student.Password;

        _appDbContext.Student.Update(studentUpdated);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id){
        var student = await Get(id);

        _appDbContext.Student.Remove(student);
        await _appDbContext.SaveChangesAsync();
    }
}