using Microsoft.EntityFrameworkCore;
using CRUDUSUARIOS.Models;
using CRUDUSUARIOS.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbcrudcoreContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))
);

builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

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
