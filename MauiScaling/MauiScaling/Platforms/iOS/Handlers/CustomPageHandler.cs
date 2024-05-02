using Microsoft.Maui.Handlers;
using System.Runtime.InteropServices;

namespace MauiScaling.Handlers
{
    public partial class CustomPageHandler : PageHandler
    {
        protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
        {
            var view = base.CreatePlatformView();

            if (App.UseMagickScale)
            {
                view.Transform = CoreGraphics.CGAffineTransform.MakeScale(
                    (NFloat)Application.Current.MainPage.Width / App.ExpectedWidth,
                    (NFloat)Application.Current.MainPage.Width / App.ExpectedWidth);
            }

            return view;
        }
    }
}