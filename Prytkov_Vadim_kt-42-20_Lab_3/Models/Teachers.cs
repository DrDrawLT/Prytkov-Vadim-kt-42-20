namespace Prytkov_Vadim_kt_42_20_Lab_3.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SecName { get; set; }

        public string ThirdName { get; set; }

        public int DepId { get; set; }

        public Departments Depart {  get; set; }

        public int AcDegId { get; set; }

        public AcademicDegrees AcademicDegree { get; set; }

        public int PosId { get; set; }

        public Positions Position {  get; set; }
    }
}
