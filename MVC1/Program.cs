﻿using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVC1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC1Context") ?? throw new InvalidOperationException("Connection string 'MVC1Context' not found.")));

builder.Services.AddControllersWithViews();






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
    pattern: "{controller=People}/{action=Index}/{Tel?}");
app.MapControllerRoute(
    name: "PeopelAjax",
    pattern: "{controller=PeopelAjax}/{action=Index}/{Tel?}");
app.MapControllerRoute(
    name: "EF",
    pattern: "{controller=EF}/{action=Index}/{id?}");
app.UseSession();
app.Run();
