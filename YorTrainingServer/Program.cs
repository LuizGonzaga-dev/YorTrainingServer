using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Data;

var builder = WebApplication.CreateBuilder(args);

//configuração do banco de dados
var connectionString = builder.Configuration.GetConnectionString("ConnectionMysql");
builder.Services.AddDbContext<YourTrainingDbContext>(options => options.UseMySql(
    connectionString,
    ServerVersion.AutoDetect(connectionString)
));

// Add services to the container.

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
