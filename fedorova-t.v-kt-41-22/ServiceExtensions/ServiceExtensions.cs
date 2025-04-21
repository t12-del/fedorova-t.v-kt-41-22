using fedorova_t.v_kt_41_22.Interfaces.TeacherInterfaces;

namespace fedorova_t.v_kt_41_22.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();

            return services;  
        }
    }
}
