using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LibraryWebAppMVC.Services.LibraryService;

using System.Configuration;
using LibraryWebAppMVC.Repositories;
using LibraryWebAppMVC.Library;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ILibraryService>(provider =>
{
    var bookRepository = new BookRepository(BookSeeder.GenerateBookData());
    return new LibraryService(bookRepository);
});

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

var port = 7255;

app.Run($"https://localhost:{port}");
