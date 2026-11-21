using Microsoft.EntityFrameworkCore;
using NguyenThaiDuong_241230691.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QlhangHoaContext>(options =>
    options.UseSqlServer("Server=.;Database=QLHangHoa;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"));

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