using ManageSchool_API.Data;
using ManageSchool_API.Interfaces.IServices;
using ManageSchool_API.Models;
using ManageSchool_API.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ManageSchool_API.Services;

public class SchoolGradesService : ISchoolGradesService{
    private readonly AppDbContext _appDbContext;
    private readonly CalculateGradesService _calculateGradeService;
    public SchoolGradesService(AppDbContext appDbContext, CalculateGradesService calculateGradeService)
    {
        _appDbContext = appDbContext;
        _calculateGradeService = calculateGradeService;
    }

    public async Task Add(SchoolGrades schoolGrades)
    {
        schoolGrades.Approved = _calculateGradeService.CalculateApprovalSemester(schoolGrades.Grade);
        _appDbContext.SchoolGrades.Add(schoolGrades);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(int idStudent, EnumSemester enumSemester, int idSchool)
    {
        var schoolGrades = await Get(idStudent, enumSemester, idSchool);

        _appDbContext.SchoolGrades.Remove(schoolGrades);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<SchoolGrades> Get(int idStudent, EnumSemester enumSemester, int idSchool)
    {
        var schoolGrades = await _appDbContext.SchoolGrades.FirstOrDefaultAsync(g=>g.IdStudent == idStudent && g.Semester == enumSemester && g.IdSchool == idSchool);
        
        if(schoolGrades == null){
            throw new Exception("Notas Escolares não foram encontradas");
        }

        return schoolGrades;
    }

    public async Task<List<SchoolGrades>> GetAllGradeSemester(int idStudent, int idSchool)
    {
        var listSchoolGrades = await _appDbContext.SchoolGrades.Where(g=>g.IdStudent == idStudent && g.IdSchool == idSchool).ToListAsync();
        if(listSchoolGrades.Any()){
            throw new Exception("Notas Escolares não foram encontradas");
        }

        return listSchoolGrades;
    }

    public async Task Update(int id, EnumSemester enumSemester, int grade, int idSchool)
    {
        var schoolGrades = await Get(id, enumSemester, idSchool);

        schoolGrades.Grade = grade;
        schoolGrades.Approved = _calculateGradeService.CalculateApprovalSemester(grade);

        _appDbContext.SchoolGrades.Update(schoolGrades);
        await _appDbContext.SaveChangesAsync();
    }
}