
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Application.Services;
using OnionArchitecture.TaskManager.Core.Interfaces;
using OnionArchitecture.TaskManager.Infrastructure.Data;
using OnionArchitecture.TaskManager.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//builder.Services.AddScoped<IProjectTasksRepository, ProjectTasksRepository>();

builder.Services.AddControllers();

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
