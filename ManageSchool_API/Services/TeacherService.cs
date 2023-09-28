
using ManageSchool_API.Data;
using ManageSchool_API.Models;
using ManageSchool_API.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

public class TeacherService : IBaseInterfaceService<Teacher>
{
    private readonly AppDbContext _appDbContext;
    public TeacherService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(Teacher teacher)
    {
        await _appDbContext.Teacher.AddAsync(teacher);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var teacher = await Get(id);

        _appDbContext.Teacher.Remove(teacher);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Teacher> Get(int id)
    {
        var teacher = await _appDbContext.Teacher.FirstOrDefaultAsync(t => t.Id == id);
        if(teacher == null){
            throw new Exception("Professor não encontrado");
        }
        return teacher;
    }

    public async Task Update(int id, Teacher teacherUpdated)
    {
        var teacher = await Get(id);

        teacher.Name = teacherUpdated.Name;
        teacher.Email = teacherUpdated.Email;
        teacher.IdSchool = teacherUpdated.IdSchool;
        teacher.Password = teacherUpdated.Password;
        
        _appDbContext.Teacher.Update(teacher);
        await _appDbContext.SaveChangesAsync();
    }
}