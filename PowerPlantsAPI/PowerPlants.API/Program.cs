using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PowerPlants.Business.Mappings;
using PowerPlants.Business.Services;
using PowerPlants.Persistence;
using PowerPlants.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<PowerPlantsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPowerPlantsRepository, PowerPlantsRepository>();
builder.Services.AddScoped<IPowerPlantsService, PowerPlantsService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PowerPlants API",
        Version = "v1",
        Description = "API for storing and retrieving Power Plants"
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PowerPlantsDbContext>();

    var retryCount = 0;
    var maxRetries = 10;

    while (retryCount < maxRetries)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (Exception ex)
        {
            retryCount++;
            Console.WriteLine($"Migration attempt {retryCount}/{maxRetries} failed: {ex.Message}");

            if (retryCount >= maxRetries)
            {
                Console.WriteLine("Max retries reached. Exiting...");
                throw;
            }

            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PowerPlants API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
