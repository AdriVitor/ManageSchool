using ManageSchool_API.Interfaces.IServices;
using ManageSchool_API.Services;
using Moq;

namespace ManageSchool_Test.Services {

    public class CalculateGradeTests {

        [Fact]
        public void CalculateApprovalStudentSemester() {
            //Arrange
            var gradeStudent1 = 8;
            var gradeStudent2 = 5;

            Mock<ICalculateGradeService> mockStudent1 = new Mock<ICalculateGradeService>();
            mockStudent1.Setup(c => c.CalculateApprovalSemester(gradeStudent1)).Returns(true);

            Mock<ICalculateGradeService> mockStudent2 = new Mock<ICalculateGradeService>();
            mockStudent2.Setup(c=>c.CalculateApprovalSemester(gradeStudent2)).Returns(false);

            var verification = new CalculateGradesService();

            //Act
            var expectedResultStudent1 = mockStudent1.Object.CalculateApprovalSemester(gradeStudent1);
            var resultStudent1 = verification.CalculateApprovalSemester(gradeStudent1);

            var expectedResultStudent2 = mockStudent2.Object.CalculateApprovalSemester(gradeStudent2);
            var resultStudent2 = verification.CalculateApprovalSemester(gradeStudent2);

            //Assert
            Assert.Equal(resultStudent1, expectedResultStudent1);
            Assert.Equal(resultStudent2, expectedResultStudent2);
            Assert.True(resultStudent1);
            Assert.True(expectedResultStudent1);
            Assert.False(resultStudent2);
            Assert.False(expectedResultStudent2);
            Assert.NotEqual(expectedResultStudent1, expectedResultStudent2);
        }
    }
}
