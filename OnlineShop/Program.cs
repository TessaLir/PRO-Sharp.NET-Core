using OnlineShop;
using OnlineShop.Models;
using OnlineShop.Models.Interfaces;
using OnlineShop.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRepositoryUser, UserRepository>();
builder.Services.AddSingleton<IRepositoryServices, ServiceRepository>();
builder.Services.AddSingleton<IRepositoryOrder, OrderRepository>();

builder.Services.AddSingleton<IRepository, BaseRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}")

    .WithStaticAssets();


app.Run();
