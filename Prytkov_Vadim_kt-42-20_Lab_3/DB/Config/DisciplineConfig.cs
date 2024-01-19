using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class DisciplineConfig: IEntityTypeConfiguration<Disciplines>
    {
        private const string TableName = "cd_disciplines";
        public void Configure(EntityTypeBuilder<Disciplines> builder)
        {
            builder
            .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_discip_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("discip_id")
                .HasComment("Идентификатор дисциплины");

            //------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_discip_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");

            builder.Property(p => p.TeachId)
                .IsRequired()
                .HasColumnName("c_discip_teach")
                .HasColumnType(ColumnType.Int)
                .HasComment("Id преподавателя");

            builder.Property(p => p.LoadId)
                .IsRequired()
                .HasColumnName("c_discip_load")
                .HasColumnType(ColumnType.Int)
                .HasComment("Id нагрузки");
        }
    }
}
