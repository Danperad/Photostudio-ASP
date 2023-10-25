using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Photostudio.CSharp.ASP.Repositories;
using Photostudio.CSharp.ASP.Repositories.Interfaces;
using Photostudio.CSharp.Database;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Configuration.AddJsonFile("connections.json", optional: false);
    var connectionString = builder.Configuration.GetConnectionString("Postgres");

    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    builder.Services.AddCors();
    builder.Services.AddControllers();

    builder.Services.AddDbContext<PhotostudioContext>(options =>
        options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
    builder.Services.AddTransient<IClientRepository, ClientRepository>();
    builder.Services.AddTransient<IServicesRepository, ServicesRepository>();
    builder.Services.AddTransient<IOrderRepository, OrderRepository>();


    var app = builder.Build();
    app.UseRouting();
    app.UseAuthorization().UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}