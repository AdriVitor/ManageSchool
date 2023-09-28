using ManageSchool_API.Interfaces.IServices;

namespace ManageSchool_API.Services {
    public class CalculateGradesService : ICalculateGradeService {
        public bool CalculateApprovalSemester(int grade) {
            var approved = false;
            if(grade >= 7) {
                approved = true;
            }

            return approved;
        }
    }
}
