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

            builder.Property(p => p.DepId)
                .IsRequired()
                .HasColumnName("c_load_dep_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор кафедры");

            builder.Property(p => p.DiscipId)
                .IsRequired()
                .HasColumnName("c_load_dis_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            //---------------

            builder.ToTable(TableName)
                .HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeachId)
                .HasConstraintName("fk_f1_teach_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p => p.TeachId, $"idx_{TableName}_fk_f1_teach_id");

            builder.Navigation(p => p.Teacher)
                .AutoInclude();
            //
            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepId)
                .HasConstraintName("fk_f1_dep_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepId, $"idx_{TableName}_fk_f1_dep_id");

            builder.Navigation(p => p.Department)
                .AutoInclude();
            //
            builder.ToTable(TableName)
                .HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DiscipId)
                .HasConstraintName("fk_f_dis_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p => p.DiscipId, $"idx_{TableName}_fk_f_dis_id");

            builder.Navigation(p => p.Discipline)
                .AutoInclude();
        }
    }
}
