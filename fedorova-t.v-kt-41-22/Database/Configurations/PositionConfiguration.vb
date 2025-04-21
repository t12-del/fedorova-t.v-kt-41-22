Imports fedorova_t.v_kt_41_22.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders


Namespace fedorova_t.v_kt_41_22.Database.Configurations
    Public Class PositionConfiguration
        Implements IEntityTypeConfiguration(Of Position)
        Public Sub Configure(builder As EntityTypeBuilder(Of Position)) Implements IEntityTypeConfiguration(Of Position).Configure
            builder.ToTable("Positions")
            builder.HasKey(Function(p) p.Id)
            builder.Property(Function(p) p.Title).HasMaxLength(100).IsRequired()
        End Sub
    End Class
End Namespace
