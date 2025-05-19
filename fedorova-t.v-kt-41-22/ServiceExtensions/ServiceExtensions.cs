using fedorova_t.v_kt_41_22.Interfaces.DepartmentInterfaces.fedorova_t.v_kt_41_22.Interfaces.DepartmentInterfaces;
using fedorova_t.v_kt_41_22.Interfaces.DepartmentInterfaces;
using fedorova_t.v_kt_41_22.Interfaces.DisciplineInterfaces;
using fedorova_t.v_kt_41_22.Interfaces.LoadInterfaces;
using fedorova_t.v_kt_41_22.Interfaces.TeacherInterfaces;

namespace fedorova_t.v_kt_41_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ILoadService, LoadService>();
            return services;
        }
    }
}
