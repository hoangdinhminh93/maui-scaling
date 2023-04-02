namespace MauiScaling;

public partial class App : Application
{
    public static float ExpectedWidth { get; set; } = 375;

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

