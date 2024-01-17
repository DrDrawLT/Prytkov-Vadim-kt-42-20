using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class DisciplinesConfig : IEntityTypeConfiguration<Disciplines>
    {
        private const string TableName = "cd_disciplines";

        public void Configure(EntityTypeBuilder<Disciplines> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            //---------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_dis_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");

            builder.Property(p => p.TeachId)
                .IsRequired()
                .HasColumnName("c_dis_teach_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор преподавателя");

            builder.Property(p => p.LoadId)
                .IsRequired()
                .HasColumnName("c_dis_load_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор нагрузки");

            //---------------

            builder.ToTable(TableName)
                .HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeachId)
                .HasConstraintName("fk_f_teach_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.TeachId, $"idx_{TableName}_fk_f_teach_id");

            builder.Navigation(p => p.Teacher)
                .AutoInclude();
            //
            builder.ToTable(TableName)
                .HasOne(p => p.LoadArea)
                .WithMany()
                .HasForeignKey(p => p.LoadId)
                .HasConstraintName("fk_f_load_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p => p.LoadId, $"idx_{TableName}_fk_f_load_id");

            builder.Navigation(p => p.LoadArea)
                .AutoInclude();
        }
    }
}
