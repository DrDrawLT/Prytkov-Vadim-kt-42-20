using Microsoft.EntityFrameworkCore;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Config;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB
{
    public class PrepodDBContext : DbContext
    {
        DbSet<AcademicDegrees> AcademicDegrees { get; set; }
        DbSet<Departments> Departments { get; set; }
        DbSet<Disciplines> Disciplines { get; set; }
        DbSet<LoadPerHour> LoadPerHour { get; set; }
        DbSet<Positions> Positions { get; set; }
        DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentsConfig());
            modelBuilder.ApplyConfiguration(new DisciplinesConfig());
            modelBuilder.ApplyConfiguration(new LoadConfig());
            modelBuilder.ApplyConfiguration(new TeachersConfig());
        }

        public PrepodDBContext(DbContextOptions<PrepodDBContext> options) : base(options)
        {

        }
    }
}
