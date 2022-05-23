using InsertNbp.Commands.Services;
using InsertNbp.DbRepository;
using InsertNbp.DbRepository.Repositories;
using InsertNbp.NbpApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
// Add services to the container.
services.AddControllersWithViews();

services.AddDbContext<InsertNbpDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"), x => x.MigrationsAssembly("InsertNbp.Web"))
        .UseLazyLoadingProxies()
        .EnableSensitiveDataLogging();
});

services.AddScoped<CurrencyRepository>();
services.AddScoped<CurrencyRateRepository>();
services.AddScoped<CurrencyService>();
services.AddSingleton<NbpService>();
services.AddScoped<CurrencyRateService>();
services.AddScoped<ProxyDbCurrencyRateService>();
services.AddScoped<ProxyCacheCurrencyRateService>();



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
    pattern: "{controller=Home}/{action=Index}/{date?}");

app.Run();
