using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces;
using ClientName_MobileNetwork_SimAuthentication_DBConnectivity.Data;
using ClientName_MobileNetwork_SimAuthentication_RepositoryLayer;
using ClientName_MobileNetwork_SimAuthentication_ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add the classes &interface to inbult dependecy injection container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
