using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Prytkov_Vadim_kt_42_20_Lab_3.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SecName { get; set; }

        public string ThirdName { get; set; }

        public int DepId { get; set; }
        
        [JsonIgnore]
        public Departments Depart {  get; set; }

        public int AcDegId { get; set; }

        [JsonIgnore]
        public AcademicDegrees AcademicDegree { get; set; }

        public int PosId { get; set; }

        [JsonIgnore]
        public Positions Position {  get; set; }

        public bool IsValidTeacherName()
        {
            return Regex.Match(Name, @"\A[А-Я]").Success;
        }
    }
}
