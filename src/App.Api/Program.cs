using App.Api.Extensions;
using App.Application.Extensions;
using App.Infrastructure.Extensions;
using App.Infrastructure.Persistence.Context;
using App.ModelDto.Commons;
using Editora.AppInfrastructure.Profiles;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{


    //---------
    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;


    //--------------------
    //Context
    //--------------------
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.EnableSensitiveDataLogging();
    });

    //--------------------
    var cors = "Cors";

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerCustom();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddInjectionRepository();
    builder.Services.AddInjectionApplication();
    builder.Services.addAuthenticationJwt(configuration);

    builder.Services.Configure<ParametrosConfig>(configuration.GetSection("ParametrosConfig"));

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: cors,
            builder =>
            {
                builder.WithOrigins("*");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();

            });
    });

    //--------------------
    //Nlog
    //--------------------
    builder.Logging.ClearProviders();
    builder.WebHost.UseNLog();
    
    var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);

    //--------------------
    //Automapper
    //--------------------
    builder.Services.AddAutoMapper(typeof(AppMappingProfile));

    //--------------------
    var app = builder.Build();

    app.UseCors(cors);
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();



    //---------

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

