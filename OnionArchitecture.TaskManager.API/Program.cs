
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.Project;
using OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.Project;
using OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.ProjectTask;
using OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.ProjectTask;
using OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.User;
using OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.User;
using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Application.Services;
using OnionArchitecture.TaskManager.Core.Interfaces;
using OnionArchitecture.TaskManager.Infrastructure.Data;
using OnionArchitecture.TaskManager.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IProjectTaskService, ProjectTaskService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<CreateProjectCommandHandler>();
builder.Services.AddTransient<UpdateProjectCommandHandler>();
builder.Services.AddTransient<DeleteProjectCommandHandler>();
builder.Services.AddTransient<GetProjectByIdQueryHandler>();
builder.Services.AddTransient<GetAllProjectsQueryHandler>();

builder.Services.AddTransient<CreateProjectTaskCommandHandler>();
builder.Services.AddTransient<UpdateProjectTaskCommandHandler>();
builder.Services.AddTransient<DeleteProjectTaskCommandHandler>();
builder.Services.AddTransient<GetProjectTaskByIdQueryHandler>();
builder.Services.AddTransient<GetAllProjectTasksQueryHandler>();

builder.Services.AddTransient<CreateUserCommandHandler>();
builder.Services.AddTransient<UpdateUserCommandHandler>();
builder.Services.AddTransient<DeleteUserCommandHandler>();
builder.Services.AddTransient<GetUserByIdQueryHandler>();
builder.Services.AddTransient<GetAllUsersQueryHandler>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
