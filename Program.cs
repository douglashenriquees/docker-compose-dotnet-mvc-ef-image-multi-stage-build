using Microsoft.EntityFrameworkCore;
using mvc.Repositories;

var host = Environment.GetEnvironmentVariable("DBHOST") ?? "localhost";
var port = Environment.GetEnvironmentVariable("DBPORT") ?? "3306";
var password = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "strongpass";

var connectionString = $"Server={host};Port={port};Uid=root;Pwd={password};Database=produtosdb;";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddDbContext<AppDbContext>(options => UseMysql(options));

void UseMysql(DbContextOptionsBuilder options)
{
    try
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    catch (Exception ex)
    {
        System.Console.WriteLine(ex.Message);
    }
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// FillDb.FillDataDb(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();