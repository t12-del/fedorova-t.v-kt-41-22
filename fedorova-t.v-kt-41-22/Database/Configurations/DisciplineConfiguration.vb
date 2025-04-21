Imports fedorova_t.v_kt_41_22.Models
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports Microsoft.EntityFrameworkCore

Namespace fedorova_t.v_kt_41_22.Database.Configurations
    Public Class DisciplineConfiguration
        Implements IEntityTypeConfiguration(Of Discipline)
        Public Sub Configure(builder As EntityTypeBuilder(Of Discipline)) Implements IEntityTypeConfiguration(Of Discipline).Configure
            builder.ToTable("Disciplines")
            builder.HasKey(Function(d) d.Id)
            builder.Property(Function(d) d.Name).HasMaxLength(100).IsRequired()
        End Sub
    End Class
End Namespace
