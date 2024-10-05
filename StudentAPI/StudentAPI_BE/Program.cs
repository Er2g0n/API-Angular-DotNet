using Microsoft.EntityFrameworkCore;
using StudentAPI_BE.Dtos;
using StudentAPI_BE.Models;
using StudentAPI_BE.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.

//C?u hình cho AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ket noi database
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<StudentService, StudentServiceImpl>();
builder.Services.AddScoped<CourseService, CourseServiceImpl>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Cho phép truy c?p t? bên ngoài
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.UseAuthorization();

app.MapControllers();

app.Run();
