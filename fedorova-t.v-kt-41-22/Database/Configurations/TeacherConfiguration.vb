Imports fedorova_t.v_kt_41_22.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders



Namespace fedorova_t.v_kt_41_22.Database.Configurations
    Public Class TeacherConfiguration
        Implements IEntityTypeConfiguration(Of Teacher)
        Public Sub Configure(builder As EntityTypeBuilder(Of Teacher)) Implements IEntityTypeConfiguration(Of Teacher).Configure
            builder.ToTable("Teachers")
            builder.HasKey(Function(t) t.Id)

            builder.Property(Function(t) t.FirstName).HasMaxLength(50).IsRequired()
            builder.Property(Function(t) t.LastName).HasMaxLength(50).IsRequired()

            builder.HasOne(Of AcademicDegree)(Function(t) CType(t.AcademicDegree, AcademicDegree?)).WithMany(Function(d) d.Teachers).HasForeignKey(CType(Function(t) CObj(t.AcademicDegreeId), Expressions.Expression(Of Func(Of Teacher, Object?)))).OnDelete(DeleteBehavior.Restrict).IsRequired(False)

            builder.HasOne(Of Position)(Function(t) CType(t.Position, Position?)).WithMany(Function(p) p.Teachers).HasForeignKey(CType(Function(t) CObj(t.PositionId), Expressions.Expression(Of Func(Of Teacher, Object?)))).OnDelete(DeleteBehavior.Restrict).IsRequired(False)

            builder.HasOne(Of Department)(Function(t) CType(t.Department, Department?)).WithMany(Function(d) d.Teachers).HasForeignKey(CType(Function(t) CObj(t.DepartmentId), Expressions.Expression(Of Func(Of Teacher, Object?)))).OnDelete(DeleteBehavior.Cascade)
        End Sub

    End Class
End Namespace
