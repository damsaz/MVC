var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();






builder.Services.AddDistributedMemoryCache();


builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();


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
    pattern: "{controller=People}/{action=Index}/{id?}");
app.UseSession();
app.Run();
