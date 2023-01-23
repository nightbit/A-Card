using A_Card.Classes;

namespace A_Card;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
    }

	private async void OnLoginClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.Login());
	}

    private async void OnRegisterClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.Register());
    }
}


