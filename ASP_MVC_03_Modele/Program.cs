using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.DAL.Interfaces;
using ASP_MVC_03_Modele.DAL.Repositories;
using System.Data.SqlClient;
using Tools.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
//builder.Services.AddTransient(typeof(IBiomeRepository), typeof(BiomeRepository));
builder.Services.AddTransient<IBiomeRepository, BiomeRepository>();

// - BLL
//builder.Services.AddTransient(typeof(BiomeService));
builder.Services.AddTransient<BiomeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
