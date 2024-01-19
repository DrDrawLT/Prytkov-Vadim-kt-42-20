using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class LoadConfig : IEntityTypeConfiguration<LoadPerHour>
    {
        private const string TableName = "cd_load";

        public void Configure(EntityTypeBuilder<LoadPerHour> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_load_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("load_id")
                .HasComment("Идентификатор нагрузки");

            //---------------

            builder.Property(p => p.Hours)
                .IsRequired()
                .HasColumnName("c_load_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Время, ч.");

            builder.Property(p => p.TeachId)
                .IsRequired()
                .HasColumnName("c_load_teach_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор преподавателя");

            builder.Property(p => p.DiscipId)
                .IsRequired()
                .HasColumnName("c_load_dis_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.DepartId)
                .IsRequired()
                .HasColumnName("c_load_depart_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор кафедры");

            //---------------

        }
    }
}
