Imports fedorova_t.v_kt_41_22.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders


Namespace fedorova_t.v_kt_41_22.Database.Configurations
    Public Class DepartmentConfiguration
        Implements IEntityTypeConfiguration(Of Department)
        Public Sub Configure(builder As EntityTypeBuilder(Of Department)) Implements IEntityTypeConfiguration(Of Department).Configure
            builder.ToTable("Departments")
            builder.HasKey(Function(d) d.Id)
            builder.Property(Function(d) d.Name).HasMaxLength(100).IsRequired()

            builder.HasOne(Of Teacher)(Function(d) CType(d.Head, Teacher?)).WithOne(Function(t) CType(t.ManagedDepartment, Department?)).HasForeignKey(Of Department)(CType(Function(d) CObj(d.HeadId), Expressions.Expression(Of Func(Of Department, Object?)))).OnDelete(DeleteBehavior.Restrict)
        End Sub
    End Class
End Namespace
