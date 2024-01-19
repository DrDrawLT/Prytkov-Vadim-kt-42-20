using System.Text.Json.Serialization;

namespace Prytkov_Vadim_kt_42_20_Lab_3.Models
{
    public class LoadPerHour
    {
        public int Id { get; set; }

        public int Hours { get; set; }

        public int TeachId { get; set; }

        [JsonIgnore]
        public Teachers Teacher { get; set;}

        public int DiscipId { get; set; }

        [JsonIgnore]
        public Disciplines Discipline { get; set; }

        public int DepartId { get; set; }

        [JsonIgnore]
        public Departments Department { get; set; }
    }
}
