Imports fedorova_t.v_kt_41_22.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders


Namespace fedorova_t.v_kt_41_22.Database.Configurations
    Public Class LoadConfiguration
        Implements IEntityTypeConfiguration(Of Load)
        Public Sub Configure(builder As EntityTypeBuilder(Of Load)) Implements IEntityTypeConfiguration(Of Load).Configure
            builder.ToTable("Loads")
            builder.HasKey(Function(l) l.Id)
            builder.Property(Function(l) l.Hours).IsRequired()

            builder.HasOne(Function(l) l.Teacher).WithMany(Function(t) t.Loads).HasForeignKey(CType(Function(l) l.TeacherId, Expressions.Expression(Of Func(Of Load, Object?)))).OnDelete(DeleteBehavior.Cascade)

            builder.HasOne(Function(l) l.Discipline).WithMany(Function(d) d.Loads).HasForeignKey(CType(Function(l) l.DisciplineId, Expressions.Expression(Of Func(Of Load, Object?)))).OnDelete(DeleteBehavior.Restrict)
        End Sub
    End Class
End Namespace
