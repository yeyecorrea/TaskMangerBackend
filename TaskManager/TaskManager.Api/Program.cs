using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Config;
using TaskManager.Business.Interfaces;
using TaskManager.Business.Mapping;
using TaskManager.Business.Services;
using TaskManager.Data.DataContext;
using TaskManager.Data.Interfaces;
using TaskManager.Data.Repositories;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthorization();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

//Cargamos la conexion de la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Registramos el DbContext
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Registramos identity
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationContext>();

 

builder.Services.AddTransient<IRepository<int, Tasked>, Repository<int, Tasked>>();
builder.Services.AddTransient<IGenericService<Tasked, TaskedDto>, GenericService<Tasked, TaskedDto>>();

builder.Services.AddTransient<IRepository<int, Tag>, Repository<int, Tag>>();
builder.Services.AddTransient<IGenericService<Tag, TagDto>, GenericService<Tag, TagDto>>();

builder.Services.AddTransient<IRepository<int, Comment>, Repository<int, Comment>>();
builder.Services.AddTransient<IGenericService<Comment, CommentDto>, GenericService<Comment, CommentDto>>();


// Registramos AddAutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
