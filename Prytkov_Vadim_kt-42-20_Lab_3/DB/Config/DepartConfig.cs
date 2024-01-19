using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class DepartConfig : IEntityTypeConfiguration<Departments>
    {
        private const string TableName = "cd_derts";
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder
            .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_depart_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("depart_id")
                .HasComment("Идентификатор кафедры");

            //---------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_depart_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");

            builder.Property(p => p.CreateDate)
                .IsRequired()
                .HasColumnName("c_depart_date")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата создания кафедры");

            builder.Property(p => p.CountTeach)
                .IsRequired()
                .HasColumnName("c_depart_count")
                .HasColumnType(ColumnType.Int)
                .HasComment("Кол-во преподавателей");

            builder.Property(p => p.TeachId)
                .IsRequired()
                .HasColumnName("c_depart_teach")
                .HasColumnType(ColumnType.Int)
                .HasComment("Заместитель кафедры");
        }
    }
}
