using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_lab_3_Tests
{
    public class TeachersTests
    {
        [Fact]
        public void IsValidTeacherName_Vadim_True()
        {
            var testTeacher = new Teachers
            {
                Name = "Вадим"
            };

            var result = testTeacher.IsValidTeacherName();

            Assert.True(result);

        }
    }
}