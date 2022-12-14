using System.Runtime.CompilerServices;
namespace Code_Legend;

public partial class Settings : ContentPage
{

    private int num = 0;

    public Settings()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadUser();
        LoadTheme();
        CheckTheme();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        SaveTheme();
    }

    private async void ProfileBackBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void UsernameEditBtn_Clicked(object sender, EventArgs e)
    {
        profileName.Text = "";
        profileName.Focus();
    }

    private void ProfileImageEditBtn_Clicked(object sender, EventArgs e)
    {

    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Image Please",
                FileTypes = FilePickerFileType.Images

            });

            if (result == null)
            {
                profileImg.Source = "user.png";
            }

            var stream = await result.OpenReadAsync();

            string filePath = Path.GetFullPath(result.ToString());

            await SecureStorage.SetAsync("path", filePath);

            profileImg.CornerRadius = 90;
            profileImg.Source = ImageSource.FromStream(() => stream);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        SaveUser(profileName.Text);
    }



    private void slider_Toggled(object sender, ToggledEventArgs e)
    {
        num++;

        if (num == 1)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }

        if (num == 2)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            num = 0;
        }
    }

    //my functions-----------------------------------------------------
    private async void SaveTheme()
    {
        await SecureStorage.SetAsync("switch", slider.IsToggled.ToString());
        await SecureStorage.SetAsync("num", num.ToString());
    }

    private async void LoadTheme()
    {
        num = Convert.ToInt16(await SecureStorage.GetAsync("num"));

        slider.IsToggled = Convert.ToBoolean(await SecureStorage.GetAsync("switch"));
    }

    private async void SaveUser(string name)
    {
        await SecureStorage.SetAsync("user", name);
    }

    private async void LoadUser()
    {
        profileName.Text = await SecureStorage.GetAsync("user");

        
        string res = await SecureStorage.GetAsync("path");


        profileImg.Source = res;
    }

    private void CheckTheme()
    {

        if (num == 1)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }

        if (num == 2)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            num = 0;
        }
    }

    private async void AboutBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new About());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        profileName.Text = "";

        SaveUser(profileName.Text);

        await Navigation.PopAsync();
    }
}