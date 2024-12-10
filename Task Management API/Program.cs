using Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastracture;
using Infrastracture.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Use_Cases.Task;
using UseCases;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
string cs = Configuration["connectionString"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(cs));
RegisterServices(builder, Configuration);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterServices(WebApplicationBuilder builder, ConfigurationManager Configuration)
{
    builder.Services.AddSingleton<IConfiguration>(Configuration);
    builder.Services.AddScoped<IEmploeeRepository, EmploeeRepository>();
    builder.Services.AddScoped<ITaskRepository, TaskRepository>();
    builder.Services.AddScoped<IRegisterEmploee, RegisterEmploee>();
    builder.Services.AddScoped<IUpdateEmploee, UpdateEmploee>();
    builder.Services.AddScoped<IAddTask, AddTask>();
    builder.Services.AddScoped<IDeleteTask, DeleteTask>();
    builder.Services.AddScoped<IRetrieveTask, RetrieveTask>();
    builder.Services.AddScoped<IUpdateTask, UpdateTask>();
}