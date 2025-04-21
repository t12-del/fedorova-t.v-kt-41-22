Imports Microsoft.EntityFrameworkCore.Migrations
Namespace fedorova_t.v_kt_41_22.Migrations
    ''' <inheritdoc/>
    Public Partial Class CreateDatabase
        Inherits Migration
        ''' <inheritdoc/>
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(name:="AcademicDegrees", columns:=Function(table) New With {
            .Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"),
.Title = table.Column(Of String)(type:="nvarchar(100)", maxLength:=100, nullable:=False)
}, constraints:=Sub(table)
                    table.PrimaryKey("PK_AcademicDegrees", Function(x) x.Id)
                End Sub)

            migrationBuilder.CreateTable(name:="Disciplines", columns:=Function(table) New With {
            .Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"),
.Name = table.Column(Of String)(type:="nvarchar(100)", maxLength:=100, nullable:=False)
}, constraints:=Sub(table)
                    table.PrimaryKey("PK_Disciplines", Function(x) x.Id)
                End Sub)

            migrationBuilder.CreateTable(name:="Positions", columns:=Function(table) New With {
            .Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"),
.Title = table.Column(Of String)(type:="nvarchar(100)", maxLength:=100, nullable:=False)
}, constraints:=Sub(table)
                    table.PrimaryKey("PK_Positions", Function(x) x.Id)
                End Sub)

            migrationBuilder.CreateTable(name:="Departments", columns:=Function(table) New With {
            .Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"),
.Name = table.Column(Of String)(type:="nvarchar(100)", maxLength:=100, nullable:=False),
.HeadId = table.Column(Of Integer)(type:="int", nullable:=True)
}, constraints:=Sub(table)
                    table.PrimaryKey("PK_Departments", Function(x) x.Id)
                End Sub)

            migrationBuilder.CreateTable(name:="Teachers", columns:=Function(table) New With {
            .Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"),
.FirstName = table.Column(Of String)(type:="nvarchar(50)", maxLength:=50, nullable:=False),
.LastName = table.Column(Of String)(type:="nvarchar(50)", maxLength:=50, nullable:=False),
.AcademicDegreeId = table.Column(Of Integer)(type:="int", nullable:=True),
.PositionId = table.Column(Of Integer)(type:="int", nullable:=True),
.DepartmentId = table.Column(Of Integer)(type:="int", nullable:=True)
}, constraints:=Sub(table)
                    table.PrimaryKey("PK_Teachers", Function(x) x.Id)
                    table.ForeignKey(name:="FK_Teachers_AcademicDegrees_AcademicDegreeId", column:=Function(x) x.AcademicDegreeId, principalTable:="AcademicDegrees", principalColumn:="Id", onDelete:=ReferentialAction.Restrict)
                    table.ForeignKey(name:="FK_Teachers_Departments_DepartmentId", column:=Function(x) x.DepartmentId, principalTable:="Departments", principalColumn:="Id", onDelete:=ReferentialAction.Cascade)
                    table.ForeignKey(name:="FK_Teachers_Positions_PositionId", column:=Function(x) x.PositionId, principalTable:="Positions", principalColumn:="Id", onDelete:=ReferentialAction.Restrict)
                End Sub)

            migrationBuilder.CreateTable(name:="Loads", columns:=Function(table) New With {
            .Id = table.Column(Of Integer)(type:="int", nullable:=False).Annotation("SqlServer:Identity", "1, 1"),
.Hours = table.Column(Of Integer)(type:="int", nullable:=False),
.TeacherId = table.Column(Of Integer)(type:="int", nullable:=False),
.DisciplineId = table.Column(Of Integer)(type:="int", nullable:=False)
}, constraints:=Sub(table)
                    table.PrimaryKey("PK_Loads", Function(x) x.Id)
                    table.ForeignKey(name:="FK_Loads_Disciplines_DisciplineId", column:=Function(x) x.DisciplineId, principalTable:="Disciplines", principalColumn:="Id", onDelete:=ReferentialAction.Restrict)
                    table.ForeignKey(name:="FK_Loads_Teachers_TeacherId", column:=Function(x) x.TeacherId, principalTable:="Teachers", principalColumn:="Id", onDelete:=ReferentialAction.Cascade)
                End Sub)

            migrationBuilder.CreateIndex(name:="IX_Departments_HeadId", table:="Departments", column:="HeadId", unique:=True, filter:="[HeadId] IS NOT NULL")

            migrationBuilder.CreateIndex(name:="IX_Loads_DisciplineId", table:="Loads", column:="DisciplineId")

            migrationBuilder.CreateIndex(name:="IX_Loads_TeacherId", table:="Loads", column:="TeacherId")

            migrationBuilder.CreateIndex(name:="IX_Teachers_AcademicDegreeId", table:="Teachers", column:="AcademicDegreeId")

            migrationBuilder.CreateIndex(name:="IX_Teachers_DepartmentId", table:="Teachers", column:="DepartmentId")

            migrationBuilder.CreateIndex(name:="IX_Teachers_PositionId", table:="Teachers", column:="PositionId")

            migrationBuilder.AddForeignKey(name:="FK_Departments_Teachers_HeadId", table:="Departments", column:="HeadId", principalTable:="Teachers", principalColumn:="Id", onDelete:=ReferentialAction.Restrict)
        End Sub

        ''' <inheritdoc/>
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropForeignKey(name:="FK_Departments_Teachers_HeadId", table:="Departments")

            migrationBuilder.DropTable(name:="Loads")

            migrationBuilder.DropTable(name:="Disciplines")

            migrationBuilder.DropTable(name:="Teachers")

            migrationBuilder.DropTable(name:="AcademicDegrees")

            migrationBuilder.DropTable(name:="Departments")

            migrationBuilder.DropTable(name:="Positions")
        End Sub
    End Class
End Namespace
