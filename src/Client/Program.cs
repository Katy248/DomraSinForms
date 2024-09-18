using DomraSinForms.Client.Components;
using DomraSinForms.Application.Extensions;
using DomraSinForms.Client;
using DomraSinForms.Client.Components.Pages.Auth;
using DomraSinForms.Persistence.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
// using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// AdDomraSind services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


builder.Services
    .AddCascadingAuthenticationState()
    .AddAuthenticationCore();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
/* builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(); */

builder.Services
    .AddPersistenceLayer(builder.Configuration.GetConnectionString("Postgres") ?? throw new Exception("Fuck it up"))
    .AddApplicationLayer()
    .AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>()
    .AddScoped<AppAuthenticationStateProvider>()
    .AddTransient<RegisterViewModel>()
    .AddTransient<LoginViewModel>()
    .AddHttpContextAccessor()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();


app.Run();
