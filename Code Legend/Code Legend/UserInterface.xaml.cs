namespace Code_Legend;

public partial class UserInterface : ContentPage
{
	public UserInterface()
	{
		InitializeComponent();
	}

    private async void FistStepsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FS_UserInterface());
    }

    private async void SettingsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    private async void LayoutsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Layouts_UserInterface());
    }

    private async void PagesBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages_UserInterface());
    }

    private async void ViewsPart1Btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewsP1_UserInterface());
    }

    private async void ViewsPart2Btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewsP2_UserInterface());
    }
}