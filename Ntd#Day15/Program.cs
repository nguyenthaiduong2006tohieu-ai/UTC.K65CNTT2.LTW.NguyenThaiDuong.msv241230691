using Microsoft.EntityFrameworkCore;
using Ntd_Day15.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QltaiSanContext>(options =>
    options.UseSqlServer("Server=localhost;Database=QLTaiSan;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
