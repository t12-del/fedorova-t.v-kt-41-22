using fedorova_t.v_kt_41_22.Database;
using fedorova_t.v_kt_41_22.Models;
using Microsoft.EntityFrameworkCore;


public class DatabaseService
{
    private readonly TeacherDbContext _context;

    public DatabaseService(TeacherDbContext context)
    {
        _context = context;
    }

    public async Task AddTeacherAsync()
    {
        var degree = new AcademicDegree();
        var position = new Position();
        var department = new Department();

        _context.AcademicDegrees.Add(degree);
        _context.Positions.Add(position);
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        var teacher = new Teacher
        {
            DegreeId = degree.Id,
            PositionId = position.Id,
            DepartmentId = department.Id
        };

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
    }
}
