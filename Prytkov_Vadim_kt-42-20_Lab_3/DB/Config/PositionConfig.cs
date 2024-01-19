using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prytkov_Vadim_kt_42_20_Lab_3.DB.Helpers;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;

namespace Prytkov_Vadim_kt_42_20_Lab_3.DB.Config
{
    public class PositionConfig: IEntityTypeConfiguration<Positions>
    {
        private const string TableName = "cd_positions";
        public void Configure(EntityTypeBuilder<Positions> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Id)
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            //---------------

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");
        }
    }
}
