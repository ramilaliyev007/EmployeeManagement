using EmployeeManagement.Repository.EfCore;
using EmployeeManagement.Service;
using EmployeeManagement.WebAPI.Infrastructure.Extensions;
using EmployeeManagement.WebAPI.Infrastructure.Middlewares;
using Serilog;

Log.Logger.SetStartupLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;

    builder.AddSerilog();

    builder.Services.AddEfCoreLayer(configuration)
                    .AddServiceLayer(configuration);

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandlingMiddleware();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}