using Microsoft.EntityFrameworkCore;

using API_PROJECT.Context;
using API_PROJECT.Interfaces;
using API_PROJECT.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySQL(builder.Configuration.GetConnectionString("RELAY_BLAZOR_HYBRID")));



// Configure MySQL DbContext with Pomelo
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("RELAY_BLAZOR_HYBRID"),
        new MySqlServerVersion(new Version(10, 4, 24)) // Use the correct MySQL server version
    ));
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//

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
