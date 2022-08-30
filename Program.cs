using Microsoft.EntityFrameworkCore;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Repository;

var builder = WebApplication.CreateBuilder(args);

// services
builder.Configuration
    .AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// db
builder.Services.AddDbContext<TaskManagerContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:WebApiDatabase"], 
    opt => { opt.EnableRetryOnFailure(); }));
// openApi swagger
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
