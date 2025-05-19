using fedorova_t.v_kt_41_22.Models;
using fedorova_t.v_kt_41_22.Filters.TeacherFilters;
using fedorova_t.v_kt_41_22.Database;
using Microsoft.EntityFrameworkCore;

namespace fedorova_t.v_kt_41_22.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken);
        public Task<Teacher?> GetTeacherByIdAsync(int id, CancellationToken cancellationToken);
        public Task<Teacher> AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        public Task<Teacher> UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        public Task<bool> DeleteTeacherAsync(int id, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;
        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Teachers
                .AsNoTracking()
                .Include(t => t.AcademicDegree)
                .Include(t => t.Position)
                .Include(t => t.Department)
                .AsQueryable();

            // Фильтрация по ученой степени
            if (!string.IsNullOrEmpty(filter.AcademicDegree))
            {
                query = query.Where(t => t.AcademicDegree.Name.Contains(filter.AcademicDegree));
            }

            // Фильтрация по должности
            if (!string.IsNullOrEmpty(filter.Position))
            {
                query = query.Where(t => t.Position.Name.Contains(filter.Position));
            }

            // Фильтрация по кафедре
            if (!string.IsNullOrEmpty(filter.Department))
            {
                query = query.Where(t => t.Department.Name.Contains(filter.Department));
            }

            return await query.ToArrayAsync(cancellationToken);
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Teachers
                .Include(t => t.AcademicDegree)
                .Include(t => t.Position)
                .Include(t => t.Department)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            _dbContext.Teachers.Add(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return teacher;
        }

        public async Task<Teacher> UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            _dbContext.Teachers.Update(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return teacher;
        }

        public async Task<bool> DeleteTeacherAsync(int id, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FindAsync(new object[] { id }, cancellationToken);
            if (teacher == null) return false;

            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}