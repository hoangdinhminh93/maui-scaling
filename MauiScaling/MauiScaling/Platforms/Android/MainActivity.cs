using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using MauiScaling.Extensions;

namespace MauiScaling;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Unspecified, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private float _expectedDensity;

    protected override void AttachBaseContext(Context @base)
    {
        if (!App.UseMagickScale)
        {
            base.AttachBaseContext(@base);
            return;
        }

        var displayMetrics = @base.Resources.DisplayMetrics;
        _expectedDensity = Math.Min(displayMetrics.WidthPixels, displayMetrics.HeightPixels) / App.ExpectedWidth;

        var configuration = new Configuration(@base.Resources.Configuration);
        configuration.FontScale = _expectedDensity / @base.Resources.DisplayMetrics.Density;
        var config = Android.App.Application.Context.CreateConfigurationContext(configuration);

        AdjustDensity(config);

        base.AttachBaseContext(config);
    }

    public override void OnConfigurationChanged(Configuration newConfig)
    {
        base.OnConfigurationChanged(newConfig);
        AdjustDensity();
    }

    private void AdjustDensity(Context targetContext = null)
    {
        if (!App.UseMagickScale) return;

        targetContext = targetContext ?? BaseContext;
        if (targetContext == null) return;

        var adjustedDisplayMetrics = targetContext.Resources.DisplayMetrics;
        var needUpdate = false;

        if (!adjustedDisplayMetrics.Density.IsEqualTo(_expectedDensity))
        {
            adjustedDisplayMetrics.Density = _expectedDensity;
            needUpdate = true;
        }
        if (!adjustedDisplayMetrics.ScaledDensity.IsEqualTo(_expectedDensity))
        {
            adjustedDisplayMetrics.ScaledDensity = _expectedDensity;
            needUpdate = true;
        }

        if (needUpdate)
        {
            Android.App.Application.Context.Resources.DisplayMetrics.SetTo(adjustedDisplayMetrics);
        }
    }
}