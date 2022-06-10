using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.DAL.Interfaces;
using ASP_MVC_03_Modele.DAL.Repositories;
using System.Data.SqlClient;
using Tools.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config Injection
// - Tools
builder.Services.AddTransient<Connection>((service) =>
{
    return new Connection(
        SqlClientFactory.Instance,
        builder.Configuration.GetConnectionString("Tristan")
    );
});

// - DAL 
builder.Services.AddTransient<IHeroRepository, HeroRepository>();

// - BLL 
builder.Services.AddTransient<IHeroService,HeroService>();

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
