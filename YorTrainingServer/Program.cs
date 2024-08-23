using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using YorTrainingServer.Data;
using YorTrainingServer.Services;

var builder = WebApplication.CreateBuilder(args);

//configuração do banco de dados
var connectionString = builder.Configuration.GetConnectionString("ConnectionMysql");
builder.Services.AddDbContext<YourTrainingDbContext>(options => options.UseMySql(
    connectionString,
    ServerVersion.AutoDetect(connectionString)
));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<FilialService>();
builder.Services.AddScoped<AcademiaService>();
builder.Services.AddScoped<FuncionarioService>();

var app = builder.Build();

// Chamada para adicionar dados iniciais ao banco de dados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Iniciallizar(services);
}

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
