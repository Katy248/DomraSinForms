using DomraSinForms.Application;
using DomraSinForms.Domain.Identity;
using DomraSinForms.Persistence;
using Forms.Mvc.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Postgres") ?? throw new InvalidOperationException("Connection string 'Postgres' not found.");
builder.Services.AddPersistence(connectionString);

builder.Services.AddDefaultIdentity<User>(options =>
{
  options.SignIn.RequireConfirmedAccount = false;
  options.SignIn.RequireConfirmedEmail = false;
  options.SignIn.RequireConfirmedPhoneNumber = false;
  options.Lockout.MaxFailedAccessAttempts = 700;
  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.MinValue;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();

builder.Services
    .AddLocalization()
    .AddDataAnnotationsPortableObjectLocalization()
    .AddApplication()
    .AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");

AddCaching(builder);
builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  // app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

UseCaching(app);
ConfigLocalization(app);

// UseHttps(app);
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

void ConfigLocalization(WebApplication application)
{
  var supportedCultures = Localization.SupportedLanguages.Select(i => i.Key).ToArray();
  var options = new RequestLocalizationOptions()
      .AddSupportedCultures(supportedCultures)
      .AddSupportedUICultures(supportedCultures)
      .SetDefaultCulture(supportedCultures[0]);

  application.UseRequestLocalization(options);
}

void AddCaching(WebApplicationBuilder builder)
{
  if (!builder.Configuration.GetValue<bool>("UseRedis")) return;

  builder.Services.AddStackExchangeRedisCache(options =>
  {
    options.Configuration = "localhost:6379";
    options.ConfigurationOptions = new()
    {
      AbortOnConnectFail = true,
      EndPoints = { options.Configuration },

    };
  });

  builder.Services.AddOutputCache(options =>
  {
    options.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(5);
  });
}

void UseCaching(WebApplication app)
{
  if (!builder.Configuration.GetValue<bool>("UseRedis")) return;

  app.UseOutputCache();
}

void AddHttps(WebApplicationBuilder builder)
{
  builder.Services.AddHttpsRedirection(options =>
  {
    options.HttpsPort = 5028;
  });
}
void UseHttps(WebApplication app)
{
  app.UseHttpsRedirection();
}
