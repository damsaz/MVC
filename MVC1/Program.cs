using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVC1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC1Context") ?? throw new InvalidOperationException("Connection string 'MVC1Context' not found.")));

builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>options.SignIn.RequireConfirmedAccount=false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MVC1Context>();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;
});



builder.Services.AddDistributedMemoryCache();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Doctor",
    pattern: "{controller=Doctor}/{action=fever}/{id?}");
app.MapControllerRoute(
    name: "GuessingGame",
    pattern: "{controller=GuessingGame}/{action=Game}/{id?}");
app.MapControllerRoute(
    name: "People",
    pattern: "{controller=People}/{action=Index}/{Tel?}");
app.MapControllerRoute(
    name: "PeopelAjax",
    pattern: "{controller=PeopelAjax}/{action=Index}/{Tel?}");
app.MapControllerRoute(
    name: "PeopleEF",
    pattern: "{controller=PeopleEF}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Cities",
    pattern: "{controller=Cities}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Countries",
    pattern: "{controller=Countries}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Languages",
    pattern: "{controller=Languages}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "LP",
    pattern: "{controller=LP}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Role",
    pattern: "{controller=Role}/{action=Index}/{id?}");
app.UseSession();
app.Run();
