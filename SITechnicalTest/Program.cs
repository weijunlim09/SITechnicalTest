using OfficeOpenXml;
using SITechnicalTest.Interfaces;
using SITechnicalTest.Services;

var builder = WebApplication.CreateBuilder(args);

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ISupplierService, SupplierService>(client =>
{
    client.BaseAddress = new Uri($"{builder.Configuration["APIBaseAddress"]}");
});

builder.Services.AddHttpClient<IQuotationService, QuotationService>(client =>
{
    client.BaseAddress = new Uri($"{builder.Configuration["APIBaseAddress"]}");
});

//builder.Services.AddTiming();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseTiming();

//app.UseMiddleware<TimingMiddleware>();

//app.Use(async (context, next) =>
//{
//    var start = DateTime.UtcNow;
//    await next.Invoke(context);
//    app.Logger.LogInformation($"Request Duration : {(DateTime.UtcNow - start).TotalMilliseconds} ms");
//});


//app.Use((HttpContext context, Func<Task> next) =>
//{
//    app.Logger.LogInformation("Terminating the Request");
//    return Task.CompletedTask;
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
