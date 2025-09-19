using Book_Shop.Data;
using Book_Shop.Data.Entities;
using Book_Shop.Extensions;
using Book_Shop.Interfaces;
using Book_Shop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("ConnStr") ?? throw new InvalidOperationException("No Connection String found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BookShopDbContext>(options =>
    options.UseSqlServer(connStr));

builder.Services.AddIdentity<User, IdentityRole >(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<BookShopDbContext>();


builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IFavoritesService, FavoritesService>();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    scope.ServiceProvider.SeedRolesAsync().Wait();
    scope.ServiceProvider.SeedAdminAsync().Wait();
}
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

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
