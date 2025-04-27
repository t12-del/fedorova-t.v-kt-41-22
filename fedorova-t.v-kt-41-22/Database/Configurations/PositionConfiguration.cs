﻿using fedorova_t.v_kt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using fedorova_t.v_kt_41_22.Database.Helpers;

namespace fedorova_t.v_kt_41_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "Positions";
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            //Первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pl_{TableName}_position_id");

            //Автоинкрементация
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Position_Id")
                .HasComment("Id должности");

            builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnName("Position_Name")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}
