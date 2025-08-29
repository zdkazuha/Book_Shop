using Microsoft.EntityFrameworkCore;
using Book_Shop.Data;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("ConnStr") ?? throw new InvalidOperationException("No Connection String found.");

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BookShopDbContext>(options =>
    options.UseSqlServer(connStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
