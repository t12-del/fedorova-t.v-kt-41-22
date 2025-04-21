Imports fedorova_t.v_kt_41_22.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Namespace fedorova_t.v_kt_41_22.Database.Configurations
    Public Class AcademicDegreeConfiguration
        Implements IEntityTypeConfiguration(Of AcademicDegree)
        Public Sub Configure(builder As EntityTypeBuilder(Of AcademicDegree)) Implements IEntityTypeConfiguration(Of AcademicDegree).Configure
            builder.ToTable("AcademicDegrees")
            builder.HasKey(Function(d) d.Id)
            builder.Property(Function(d) d.Title).HasMaxLength(100).IsRequired()
        End Sub
    End Class
End Namespace
