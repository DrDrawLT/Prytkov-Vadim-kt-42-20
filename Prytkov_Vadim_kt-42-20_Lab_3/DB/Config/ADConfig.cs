using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class ADConfig: IEntityTypeConfiguration<AcademicDegrees>
    {
        private const string TableName = "cd_academicDegrees";
        public void Configure(EntityTypeBuilder<AcademicDegrees> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_ad_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("ad_id")
                .HasComment("Идентификатор должности");

            //---------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_ad_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");
        }
    }
}
