using Microsoft.EntityFrameworkCore;
using PaylocityEmployeeBenefitsPackage.Business;
using PaylocityEmployeeBenefitsPackage.Business.Interfaces;
using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddTransient<IDeductionCalculator, DeductionCalculator>();
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
