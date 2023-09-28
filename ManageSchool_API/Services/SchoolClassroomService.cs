using ManageSchool_API.Data;
using ManageSchool_API.Models;
using ManageSchool_API.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace ManageSchool_API.SchoolClasroom.Services;

public class SchoolClassroomService : IBaseInterfaceService<SchoolClassroom>{
    private readonly AppDbContext _appDbContext;
    public SchoolClassroomService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(SchoolClassroom schoolClassroom)
    {
        await _appDbContext.SchoolClassroom.AddAsync(schoolClassroom);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var schoolClassroom = await Get(id);

        _appDbContext.SchoolClassroom.Remove(schoolClassroom);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<SchoolClassroom> Get(int id)
    {
        var schoolClassroom = await _appDbContext.SchoolClassroom.FirstOrDefaultAsync(s => s.Id == id);
        if(schoolClassroom == null){
            throw new Exception("Classe escolar não encontrada");
        }
        return schoolClassroom;
    }

    public async Task Update(int id, SchoolClassroom schoolClassroomUpdated)
    {
        var schoolClassroom = await Get(id);

        schoolClassroom.Name = schoolClassroomUpdated.Name;
        schoolClassroom.Students = schoolClassroom.Students;

        _appDbContext.SchoolClassroom.Update(schoolClassroom);
        await _appDbContext.SaveChangesAsync();
    }
}