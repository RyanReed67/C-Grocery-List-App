using GroceryApp.Data.Repositories;
using GroceryApp.Services.Service;
using GroceryApp.Services.Interfaces;
using GroceryApp.Services.MockService;
using GroceryApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Define the Connection String (The Water Main)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Register MVC (The House Layout)
builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Web/Views/{1}/{0}.cshtml");
    options.ViewLocationFormats.Add("/Web/Views/Shared/{0}.cshtml");
});

// 3. Register the Database Connection (The Meter)
// We only need this ONCE.
builder.Services.AddDbContext<GroceriesContext>(options => options.UseNpgsql(connectionString));

// 4. Register your new layers (The Foreman and the Pipe Fitter)
builder.Services.AddScoped<IGroceryRepository, GroceryRepository>();
builder.Services.AddScoped<IGroceryService, GroceryService>();
//builder.Services.AddSingleton<IGroceryService, MockGroceryService>();

var app = builder.Build();

// 5. Middleware (The Utilities)
app.UseStaticFiles(); // For your CSS/JS
app.UseRouting();

app.MapGet("/test", () => "The pipes are working!");

// 6. Routing (The GPS)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
