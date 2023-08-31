using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();

//DBContext
builder.Services.AddDbContext<AppWebApiContext>(options =>
{
    //string? ConnectionStrings = builder.Configuration.GetConnectionString("ConexMySqlHome");
    string? ConnectionStrings = builder.Configuration.GetConnectionString("ConexMySqlCampus");
    options.UseMySql(ConnectionStrings, ServerVersion.AutoDetect(ConnectionStrings));
});

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
