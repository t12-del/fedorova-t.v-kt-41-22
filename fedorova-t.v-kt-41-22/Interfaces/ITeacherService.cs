using fedorova_t.v_kt_41_22.Filters.TeacherFilters;
using fedorova_t.v_kt_41_22.Database;
using fedorova_t.v_kt_41_22.Models;
using Microsoft.EntityFrameworkCore;

namespace fedorova_t.v_kt_41_22.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeacherByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;
        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Teacher[]> GetTeacherByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(w => w.Department.Name == filter.Name).ToArrayAsync(cancellationToken);
            return teachers;
        }


    }

}
