namespace MauiScaling;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnOpenDialogClicked(object sender, EventArgs e)
	{
		App.Current.MainPage.DisplayAlert("", "This is a dialog :)", "Ok");
	}

    private void OnOpenSamplePageClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new SamplePage());
    }
}


