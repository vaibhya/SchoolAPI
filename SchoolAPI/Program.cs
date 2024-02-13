using Microsoft.EntityFrameworkCore;
using SchoolAPI.Model;
using SchoolAPI.Repository;
using SchoolAPI.Service;
using FluentValidation.AspNetCore;
using System.Reflection;
using SchoolAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(StudentMapper));
builder.Services.AddFluentValidation(
    fv =>
    {
        fv.ImplicitlyValidateChildProperties = true;
        fv.ImplicitlyValidateRootCollectionElements = true;
        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository,StudentRepository>();

builder.Services.AddDbContext<StudentDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DBConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
