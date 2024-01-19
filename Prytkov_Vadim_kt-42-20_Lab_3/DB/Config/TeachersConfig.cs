using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class TeachersConfig : IEntityTypeConfiguration<Teachers>
    {
        private const string TableName = "cd_teachers";

        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("teach_id")
                .HasComment("Идентификатор преподавателя");

            //---------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_teach_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");

            builder.Property(p => p.SecName)
                .IsRequired()
                .HasColumnName("c_teach_secname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия");

            builder.Property(p => p.ThirdName)
                .IsRequired()
                .HasColumnName("c_teach_thirdname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество");

            builder.Property(p => p.DepId)
                .IsRequired()
                .HasColumnName("c_teach_dep_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор кафедры");

            builder.Property(p => p.AcDegId)
                .IsRequired()
                .HasColumnName("c_teach_acdeg_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор степени");

            builder.Property(p => p.PosId)
                .IsRequired()
                .HasColumnName("c_teach_pos_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор должности");

            //---------------

            builder.ToTable(TableName)
                .HasOne(p => p.Depart)
                .WithMany()
                .HasForeignKey(p => p.DepId)
                .HasConstraintName("fk_f_dep_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepId, $"idx_{TableName}_fk_f_dep_id");

            builder.Navigation(p => p.Depart);
            //
            builder.ToTable(TableName)
                .HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.AcDegId)
                .HasConstraintName("fk_f_acdeg_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcDegId, $"idx_{TableName}_fk_f_acdeg_id");

            builder.Navigation(p=>p.AcademicDegree);
            //
            builder.ToTable(TableName)
                .HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PosId)
                .HasConstraintName("fk_f_posit_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.PosId, $"idx_{TableName}_fk_f_posit_id");

            builder.Navigation(p => p.Position);
        }
    }
}
