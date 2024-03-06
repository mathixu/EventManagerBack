using EventManager.Business;
using EventManager.Business.Contracts;
using EventManager.DAL;
using EventManager.DAL.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<EventManagerDbContext>(options =>
        {
            options.UseSqlServer("Data Source=localhost;Database=db_eventmanager_dev;Integrated Security=sspi;TrustServerCertificate=True;");
        });

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEventBusiness, EventBusiness>();
    })
    .Build();

host.Run();
