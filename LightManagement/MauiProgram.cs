using MauiIcons.FontAwesome;
using MauiIcons.FontAwesome.Brand;
using MauiIcons.FontAwesome.Solid;
using Microsoft.Extensions.Logging;

namespace LightManagement;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseFontAwesomeMauiIcons()
            .UseFontAwesomeBrandMauiIcons()
            .UseFontAwesomeSolidMauiIcons()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}