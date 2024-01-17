using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class DepartmentsConfig : IEntityTypeConfiguration<Departments>
    {
        private const string TableName = "cd_departments";

        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder
                .HasKey(p=>p.Id)
                .HasName($"pk_{TableName}_department_id");

            builder.Property(p=>p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("depart_id")
                .HasComment("Идентификатор кафедры");

            //---------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_dep_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Наименование кафедры");

            builder.Property(p => p.CreateDate)
                .IsRequired()
                .HasColumnName("c_dep_date")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата создания");

            builder.Property(p => p.CountTeach)
                .IsRequired()
                .HasColumnName("c_dep_count")
                .HasColumnType(ColumnType.Int)
                .HasComment("Кол-во преподавателей");

            builder.Property(p => p.TeachId)
                .IsRequired()
                .HasColumnName("c_dep_teach_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор заместителя");

            //---------------

            builder.ToTable(TableName)
                .HasOne(p=>p.Deputy)
                .WithMany()
                .HasForeignKey(p=>p.TeachId)
                .HasConstraintName("fk_f2_teach_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p=>p.TeachId, $"idx_{TableName}_fk_f2_teach_id");

            builder.Navigation(p => p.Deputy)
                .AutoInclude();
        }
    }
}
