using fedorova_t.v_kt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using fedorova_t.v_kt_41_22.Database.Helpers;

namespace fedorova_t.v_kt_41_22.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "AcademicDegree";
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.HasKey(p => p.Id)
           .HasName($"pl_{TableName}_degree_id");

            //Автоинкрементация
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("degree_Id")
                .HasComment("Id уч. степени");

            builder.Property(p => p.Name)
                 .IsRequired()
                 .HasColumnName("Name")
                 .HasColumnType(ColumnType.String).HasMaxLength(50)
                 .HasComment("Название уч. степени");

            builder.ToTable(TableName);
        }
    }
}