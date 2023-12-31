using Dot7.CleanArchitecture.Infrastructure;
using Dot7.CleanArchitecture.Application;
using Dot7.CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var logger = new LoggerConfiguration()
    .WriteTo.Console() // You can add more sinks (e.g., file, database, etc.) as needed
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.AddDbContext<MyWorldDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyWorldDbConnection");
    options.UseSqlServer(connectionString);
});
// Add the following line to add controller services
builder.Services.AddControllers();
// Add the following line to add authorization services
builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);

var app = builder.Build();
// Perform database migration
await PerformDatabaseMigrationAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSerilogRequestLogging(); // Add this line to enable request logging with Serilog

    // Your existing middleware registrations and configurations...
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task PerformDatabaseMigrationAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<MyWorldDbContext>();

    try
    {
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during database migration: {ex}");
    }
}
