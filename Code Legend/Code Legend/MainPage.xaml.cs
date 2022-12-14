namespace Code_Legend;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}


    private async void UserInterfaceBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserInterface());
    }

    private async void FundamentsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Fundaments());
    }

    private async void SettingsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    private async void Fundamentals2Btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Main_Basic());
    }

    private async void TestBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Main_Test());
    }
}

