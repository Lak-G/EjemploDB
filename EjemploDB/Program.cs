using Microsoft.EntityFrameworkCore;
using EjemploDB.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// registra el contexto de base de datos usando sqlite con el archivo tienda.db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tienda.db"));

var app = builder.Build();

// crea la base de datos y las tablas si aún no existen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
