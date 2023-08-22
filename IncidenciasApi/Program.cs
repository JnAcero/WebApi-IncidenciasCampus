using System.Reflection;
using IncidenciasApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigCores();
builder.Services.AddControllers();
builder.Services.AddAplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiIncidenciasDbContext>(options =>
{
    string ? ConnectionString = builder.Configuration.GetConnectionString("ConexMySqlCasa");
    options.UseMySql(ConnectionString,ServerVersion.AutoDetect(ConnectionString));
});
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
