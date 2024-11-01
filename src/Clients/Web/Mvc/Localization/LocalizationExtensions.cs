namespace DomraSinForms.Clients.Web.Mvc.Localization;

public static class LocalizationExtensions
{
  public static WebApplication UseLocalization(this WebApplication app)
  {

    var supportedCultures = Forms.Mvc.Localization.Localization.SupportedLanguages.Select(i => i.Key).ToArray();
    var options = new RequestLocalizationOptions()
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures)
        .SetDefaultCulture(supportedCultures[0]);

    app.UseRequestLocalization(options);
    return app;
  }
}
