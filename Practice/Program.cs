using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Dapper;
using Practice.Repositories;
using Practice.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserDapperRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// var masterConnString = "Server=tcp:practicedevmssqldb.database.windows.net,1433;Initial Catalog=practicedevmssqldb;Persist Security Info=False;User ID=azureuser;Password=Stepit12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
// var connection = new SqlConnection(masterConnString);

// try {
//     await connection.ExecuteAsync(
//         sql: @"CREATE DATABASE IF NOT EXISTS Practice
//                 USE Pracitce"
//     );

//     await connection.ExecuteAsync(
//         sql: @"create table Users (
//             Id int primary key identity(1, 1),
//             [Login] nvarchar(100),
//             [Password] nvarchar(100),
//             [Email] nvarchar(100)
//             )"
//     );
// }
// catch(Exception) {
//     Console.WriteLine("Db already exists!");
// }

app.MapControllers();

app.UseHttpsRedirection();
app.Run();
