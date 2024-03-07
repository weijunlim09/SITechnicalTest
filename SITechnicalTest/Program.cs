using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SITechnicalTest.Interfaces;
using SITechnicalTest.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ISupplierService, SupplierService>(client =>
{
    client.BaseAddress = new Uri($"{builder.Configuration["APIBaseAddress"]}");
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

app.Run();
