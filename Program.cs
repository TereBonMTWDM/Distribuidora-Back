using DistrbuidoraAPI.Logic;
using DistrbuidoraAPI.Data;
using DistrbuidoraAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using DistrbuidoraAPI.Data.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--->Variables de entorno:
DotNetEnv.Env.Load();

///--->Swagger info:
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "1.0.0",
        Title = "Distribuidora AI Máximo TI - Módulo Inventarios",
        Description = "Procesa información en la base de datos con relación al módulo de Inventarios.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Tere Orozco Bon",
            Email = "tereorozco.bon@gmail.com"
        }
    });
});


//--->CORS:
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    })
);

//--->Print Logs:
builder.Services.AddLogging(logging =>
{
    logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

    logging.AddConsole();
    logging.AddDebug();
    logging.SetMinimumLevel(LogLevel.Information);
});

var cnnString = Environment.GetEnvironmentVariable("DATABASE");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProductoLogic, ProductoLogic>();
builder.Services.AddScoped<IProductoProveedorLogic, ProductoProveedorLogic>();
builder.Services.AddScoped<IProveedorLogic, ProveedorLogic>();
builder.Services.AddScoped<ITipoProductoLogic, TipoProductoLogic>();


builder.Services.AddScoped<IProductoData, ProductoData>();
builder.Services.AddScoped<IProductoProveedorData, ProductoProveedorData>();
builder.Services.AddScoped<IProveedorData, ProveedorData>();
builder.Services.AddScoped<ITipoProductoData, TipoProductoData>();




var app = builder.Build();


//--->Logging:
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("=========================================");
logger.LogInformation("TESTING... Logs Logger.LogInformation at PROGRAM.CS");
logger.LogInformation("=========================================");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//para capturar y registrar excepciones globalmente:
//app.UseExceptionHandler("/Home/Error");
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500; // or another Status accordingly to Exception Type
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {
            var ex = error.Error;

            await context.Response.WriteAsync(new ErrorDto()
            {
                Code = 500,
                Message = ex.Message // or your custom message
                                     // other custom data
            }.ToString(), System.Text.Encoding.UTF8);
        }
    });
});



app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();



app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
