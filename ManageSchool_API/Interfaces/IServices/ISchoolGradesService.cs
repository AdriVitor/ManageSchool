using ManageSchool_API.Models;
using ManageSchool_API.Models.Enums;

namespace ManageSchool_API.Interfaces.IServices;

public interface ISchoolGradesService{
    public Task<SchoolGrades> Get(int idStudent, EnumSemester enumSemester, int IdSchool);
    public Task<List<SchoolGrades>> GetAllGradeSemester(int idStudent, int IdSchool);
    public Task Add(SchoolGrades schoolGrades);
    public Task Update(int idStudent, EnumSemester enumSemester, int grade, int IdSchool);
    public Task Delete(int idStudent, EnumSemester enumSemester, int IdSchool);
}