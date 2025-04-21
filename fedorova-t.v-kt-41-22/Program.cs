using fedorova_t.v_kt_41_22.Database;
using fedorova_t.v_kt_41_22.Interfaces.TeacherInterfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using static fedorova_t.v_kt_41_22.ServiceExtentions.ServiceExtentions;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TeacherDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddControllers();

    builder.Services.AddScoped<ITeacherService, TeacherService>();

    builder.Services.AddServices();

    var app = builder.Build();

    // Настройка конвейера HTTP-запросов.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}