using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// getting section of database settings from the apps.json file and map to EmployeeDatabaseSettings
builder.Services.Configure<EmployeeDatabaseSettings>(
                builder.Configuration.GetSection("EmployeeManagementDatabaseSettings"));

builder.Services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);

// specifying to MongoDB the connection string 
builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("EmployeeManagementDatabaseSettings:ConnectionString")));

// adding instances of the collection services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAdminUsersService, AdminUsersService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IRoleService, RoleService>();

// allowing requests from different sources (overriding CORS policy)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

