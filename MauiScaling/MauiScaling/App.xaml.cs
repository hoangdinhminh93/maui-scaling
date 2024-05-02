namespace MauiScaling;

public partial class App : Application
{
    public static float ExpectedWidth { get; set; } = 600;

	public static bool UseMagickScale { get; set; } = true;

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

