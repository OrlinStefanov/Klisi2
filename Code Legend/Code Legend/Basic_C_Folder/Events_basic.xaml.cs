namespace Code_Legend;

public partial class Events_basic : ContentPage
{
    public string[] headText = { "DataTime in C#", "ListBox in C#", "Try and catch"};

    public string[] mainText = { "We used the DateTime when there is a need to work with the dates and times in C#.\r\n\r\nWe can format the date and time in different formats by the properties and methods of the DateTime./p>\r\n\r\nThe value of the DateTime is between the 12:00:00 midnight, January 1 0001 and 11:59:59 PM, December 31, 9999 A.D.\r\n\r\nHere we will explain how to create the DateTime in C#.", "he ListBox Control provides us a user interface that will display the List of the items. From there, the users can select one or more items from the List. We can use the ListBox to show the multiple columns, and these columns can contain images and other controls. For creating the ListBox, we will follow the two approaches in Windows Form. To create the ListBox control, either we can use the Forms Designer at the time of the designing, or we can use the ListBox class for creating control at the run time.", "In C# programming, exception handling is performed by try/catch statement. The try block in C# is used to place the code that may throw exception. The catch block is used to handled the exception. The catch block must be preceded by try block." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public Events_basic()
	{
		InitializeComponent();
        img[0] = "datatime_basic.png";
        img[1] = "listbox_basic.jpg";
        img[2] = "try_basic.png";
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        IMage1.Source = img[0];

        UpdateQ();

        Questions questions = new Questions();

        questions.QuestionsChange(0, headText, mainText, img, First_Text, Second_Text, IMage1, headText.Length);
        questions.CheckTheme(num);
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    private async void NextBtn_Clicked(object sender, EventArgs e)
    {
        clicks++;

        if (clicks <= 0)
        {
            clicks = 0;
        }
        else if (clicks >= headText.Length + 1)
        {
            await Navigation.PopAsync();
        }

        progressBar.Progress += 0.33;

        UpdateQ();

        Questions questions = new Questions();

        questions.QuestionsChange(clicks, headText, mainText, img, First_Text, Second_Text, IMage1, headText.Length);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        clicks--;

        if (clicks <= 0)
        {
            clicks = 0;
        }

        progressBar.Progress -= 0.33;

        UpdateQ();

        Questions questions = new Questions();

        questions.QuestionsChange(clicks, headText, mainText, img, First_Text, Second_Text, IMage1, headText.Length);
    }

    private void UpdateQ()
    {
        question.Text = clicks.ToString() + " / " + headText.Length.ToString() + " Questions";
    }
}