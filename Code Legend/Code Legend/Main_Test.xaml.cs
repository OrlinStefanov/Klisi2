namespace Code_Legend;

public partial class Main_Test : ContentPage
{
	public Main_Test()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Settings());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FS_Test());
    }
}