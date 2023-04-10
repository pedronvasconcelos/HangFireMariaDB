using Hangfire;
using Hangfire.Common;
using Hangfire.MySql;
using HangFirePOC.Repositories;
using HangFirePOC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options => options
       .UseMySql(
builder.Configuration.GetConnectionString("MariaDBConnection"),
           ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDBConnection"))));

string hangfireConnectionString = builder.Configuration.GetConnectionString("HangFireConnection");
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseStorage(
        new MySqlStorage(
            hangfireConnectionString,
            new MySqlStorageOptions
            {
                QueuePollInterval = TimeSpan.FromSeconds(10),
                JobExpirationCheckInterval = TimeSpan.FromHours(1),
                CountersAggregateInterval = TimeSpan.FromMinutes(5),
                PrepareSchemaIfNecessary = true,
                DashboardJobListLimit = 25000,
                TransactionTimeout = TimeSpan.FromMinutes(1),
                TablesPrefix = "Hangfire",
            }
        )
    ));
// Add services to the container.

builder.Services.AddHangfireServer(options => options.WorkerCount = 1);

builder.Services.AddScoped<INumberService, NumberService>();    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var serviceScope = app.Services.CreateScope();
var recurringJobManager = serviceScope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
var numberService = serviceScope.ServiceProvider.GetRequiredService<INumberService>();

// Agendar o método GenerateRandomNumberDrawn para executar a cada minuto
recurringJobManager.AddOrUpdate("GenerateRandomNumberDrawn", Job.FromExpression(() => numberService.GenerateRandomNumberDrawn()), Cron.Minutely());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseHangfireDashboard();
app.MapControllers();

app.Run();
