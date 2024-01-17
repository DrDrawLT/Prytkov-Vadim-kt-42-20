namespace Prytkov_Vadim_kt_42_20_Lab_3.Models
{
    public class Disciplines
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TeachId { get; set; }

        public Teachers Teacher { get; set; }

        public int LoadId { get; set; }

        public LoadPerHour LoadArea { get; set; }
    }
}
