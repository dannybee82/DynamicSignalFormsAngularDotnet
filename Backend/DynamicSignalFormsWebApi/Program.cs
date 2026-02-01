using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using RepositoryLayer;
using RepositoryLayer.Repository;
using ServiceLayer.Service;

var builder = WebApplication.CreateBuilder(args);

//For PostgreSQL Databases and DateTime.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add DbContext.
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MainDbContext>(options => options.UseNpgsql(dbConnectionString));

// Add services to the container. And Serialize all Enums to Strings.
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DynamicSignalFormsWebApi", Version = "v1" });
});

// Enable CORS - Cross Origin Resource Sharing
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
        builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

// Register repositories (Database Layer)
builder.Services.AddScoped<ISignalFormRepository, SignalFormRepository>();
builder.Services.AddScoped<ISignalFormFieldRepository, SignalFormFieldRepository>();

// Register services.
builder.Services.AddScoped<ISignalFormService, SignalFormService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();