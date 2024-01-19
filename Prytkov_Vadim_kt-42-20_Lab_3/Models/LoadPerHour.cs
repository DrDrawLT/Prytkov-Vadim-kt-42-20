namespace Prytkov_Vadim_kt_42_20_Lab_3.Models
{
    public class LoadPerHour
    {
        public int Id { get; set; }

        public int Hours { get; set; }

        public int TeachId { get; set; }

        public Teachers Teacher { get; set;}

        public int DiscipId { get; set; }

        public Disciplines Discipline { get; set; }

        public int DepartId { get; set; }

        public Departments Department { get; set; }
    }
}
