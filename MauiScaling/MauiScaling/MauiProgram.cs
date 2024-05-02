using MauiScaling.Extensions;
using MauiScaling.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace MauiScaling;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.ReplaceHandler(typeof(Page), typeof(CustomPageHandler), typeof(PageHandler));
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

