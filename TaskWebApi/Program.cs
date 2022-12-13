using TaskWebApi.Data;
using Microsoft.EntityFrameworkCore;
using TaskWebApi.Interfaces;
using TaskWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITask, TaskRepository>();
builder.Services.AddTransient<IProject, ProjectRepository>();

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=TaskWebApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.Name);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    DatabaseInitialization.Initialization(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
