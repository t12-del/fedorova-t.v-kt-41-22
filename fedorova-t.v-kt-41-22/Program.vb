

' Настройка конвейера HTTP-запросов.

''' Cannot convert GlobalStatementSyntax, CONVERSION ERROR: Conversion for GlobalStatement not implemented, please report this issue in 'var builder = Microsoft.Asp...' at character 111
''' 
''' 
''' Input:
''' 
''' 
''' var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
''' 
''' 
''' Cannot convert GlobalStatementSyntax, CONVERSION ERROR: Conversion for GlobalStatement not implemented, please report this issue in 'var logger = NLog.Web.Setup...' at character 193
''' 
''' 
''' Input:
''' 
''' var logger = NLog.Web.SetupBuilderExtensions.LoadConfigurationFromAppSettings(NLog.LogManager.Setup()).GetCurrentClassLogger();
''' 
''' 
''' Cannot convert GlobalStatementSyntax, CONVERSION ERROR: Conversion for GlobalStatement not implemented, please report this issue in 'try\r\n{\r\n builder.Loggin...' at character 324
''' 
''' 
''' Input:
''' 
''' try
''' {
'''     builder.Logging.ClearProviders();
'''     builder.Host.UseNLog();
''' 
'''     builder.Services.AddControllers();
'''     
'''     builder.Services.AddEndpointsApiExplorer();
'''     builder.Services.AddSwaggerGen();
''' 
'''     builder.Services.AddDbContext<fedorova_t.v_kt_41_22.Database.TeacherDbContext>(options =>
''' options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
''' 
''' 
'''     var app = builder.Build();
''' 
'''     // Настройка конвейера HTTP-запросов.
'''     if (app.Environment.IsDevelopment())
'''     {
'''         app.UseSwagger();
'''         app.UseSwaggerUI();
'''     }
''' 
'''     app.UseAuthorization();
''' 
'''     app.MapControllers();
''' 
'''     app.Run();
''' 
''' }
''' catch (System.Exception ex)
''' {
'''     logger.Error(ex, "Stopped program because of exception");
''' }
''' finally
''' {
'''     NLog.LogManager.Shutdown();
''' }
''' 