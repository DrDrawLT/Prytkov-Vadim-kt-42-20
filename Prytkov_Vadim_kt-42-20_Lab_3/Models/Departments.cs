namespace Prytkov_Vadim_kt_42_20_Lab_3.Models
{
    public class Departments
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public int CountTeach { get; set; }

        public int TeachId { get; set; }

        public Teachers Deputy { get; set; }

    }
}
