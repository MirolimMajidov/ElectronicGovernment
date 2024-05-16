using Microsoft.Extensions.Logging;

namespace ElectronicGovernment.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddCore();
            builder.Services.AddUi();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("materialdesignicons_font.ttf", "materialIcons");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            DependencyInitializerCore.ServiceProvider = app.Services;
            return app;
        }
    }
}