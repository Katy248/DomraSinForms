using DomraSinForms.Client.Components;
using DomraSinForms.Application.Extensions;
using DomraSinForms.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// AdDomraSind services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// .AddInteractiveWebAssemblyComponents()


builder.Services
    .AddCascadingAuthenticationState()
    .AddAuthenticationCore()
    .AddPersistenceLayer(@"Server=localhost,1433;Password=<YourStrong@Passw0rd>;User Id=sa;Database=DSF;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=False;")
    .AddApplicationLayer();

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
    .AddInteractiveServerRenderMode();
    // .AddInteractiveWebAssemblyRenderMode()


app.Run();
