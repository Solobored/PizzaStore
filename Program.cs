using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services required for MVC controllers + Blazor Server
builder.Services.AddControllers()
    // Prevent JSON serializer errors for EF circular references in development:
    .AddJsonOptions(opts =>
    {
        // Ignore object cycles (prevents System.Text.Json.JsonException on round-trips).
        // For production APIs you might want DTOs instead of relying on this.
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        // If you want to allow deeper graphs, increase MaxDepth (default 32).
        // opts.JsonSerializerOptions.MaxDepth = 64;
    });

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// EF Core - SQLite (file in working directory)
builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlite("Data Source=PizzaStore.db"));

// App state service (your Services/OrderState.cs)
builder.Services.AddSingleton<OrderState>();

// Register a named HttpClient for server API calls from components (adjust port if needed).
builder.Services.AddHttpClient("ServerAPI", client =>
{
    // If your app listens on a different port adjust this URI.
    client.BaseAddress = new Uri("http://localhost:5248");
});

// Make a plain HttpClient available for direct injection into components:
// components can use `@inject HttpClient Http`
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

var app = builder.Build();

// CREATE DB AND SEED (ensure this runs once at startup)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<PizzaStoreContext>();

        // Create tables for the current model if missing (development convenience).
        db.Database.EnsureCreated();

        // If you have SeedData.Initialize(PizzaStoreContext) in Data/SeedData.cs, it will run.
        // If not present, this call is harmless only if the method exists.
        SeedData.Initialize(db);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating/seeding the database.");
    }
}

// Standard middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

// Map controllers (API), Blazor Hub and fallback to _Host
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
