namespace Code_Legend;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        GetText(lbl);
    }

    private void GetText(Label lbl)
	{
		lbl.Text = "Welcome to Code Legend!\r\n\r\nThis innovative application is designed to teach the basics of the latest .NET MAUI programming language. Here you can find tutorials for the two main parts of the programming language:\r\n- User Interface, which is programmed/coded (choose one of the two) in the XAML programming language\r\n- Fundamentals that are programmed/coded (choose one) in the C# programming language\r\nOverall, this new programming language .NET Multi-platform App UI (.NET MAUI) is a cross-platform framework for creating mobile and desktop applications with C# and XAML. With its help, you can develop applications running on Android, iOS, MacOS and Windows with the same code base. .NET MAUI is an evolutionary version of Xamarin.Forms extended from mobile to desktop devices.\r\n\r\n2. Contacting us\r\n\r\nIf you have any questions (or comments) you can contact us by email: cecompany2008@gmail.com";

    }
}