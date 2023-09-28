
using ManageSchool_API.Data;
using ManageSchool_API.Models;
using ManageSchool_API.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

public class SchoolService : IBaseInterfaceService<School>
{
    private readonly AppDbContext _appDbContext;
    public SchoolService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(School school)
    {
        await _appDbContext.School.AddAsync(school);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var school = await Get(id);

        _appDbContext.School.Remove(school);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<School> Get(int id)
    {
        var school = await _appDbContext.School.FirstOrDefaultAsync(s => s.Id == id);
        if(school == null){
            throw new Exception("Escola não encontrada");
        }
        return school;
    }

    public async Task Update(int id, School schoolUpdated)
    {
        var school = await Get(id);

        school.Name = schoolUpdated.Name;

        _appDbContext.School.Update(school);
        await _appDbContext.SaveChangesAsync();
    }
}