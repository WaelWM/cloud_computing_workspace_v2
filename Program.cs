using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCFlowerShopWeek3.Data;
using MVCFlowerShopWeek3.Areas.Identity.Data;
using System.Runtime.InteropServices.JavaScript;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MVCFlowerShopWeek3ContextConnection") ?? throw new InvalidOperationException("Connection string 'MVCFlowerShopWeek3ContextConnection' not found.");

builder.Services.AddDbContext<MVCFlowerShopWeek3Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MVCFlowerShopWeek3User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MVCFlowerShopWeek3Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.UseAuthentication();
app.UseAuthorization(); //Direct to login page



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
