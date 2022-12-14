namespace Code_Legend;

public partial class ViewsP2_UserInterface : ContentPage
{
    public string[] headText = { "SearchBar", "ProgressBar", "Picker", "TimePicker", "DatePicker" };

    public string[] mainText = { "SearchBar is a user input control used to initiating a search. The SearchBar control supports placeholder text, query input, search execution, and cancellation. SearchBar derives from the InputView class, from which it inherits additional properties and events.", "ProgressBar indicates to users that the app is progressing through a lengthy activity. The progress bar is a horizontal bar that is filled to a percentage represented by a double value. ProgressBar defines two properties: Progress is a double value that represents the current progress as a value from 0 to 1. ProgressColor is a Color values that defines the color of the ProgressBar. ProgressBar also defines a ProgressTo method that animates the bar from its current value to a specified value.", "Picker displays a short list of items, from which the user can select an item. Picker defines CharacterSpacing, FontAttributes, FontAutoScalingEnabled, FontFamily, FontSize, HorizontalTextAlignment, ItemsSource, SelectedIndex, SelectedItem, TextColor, TextTransform, Title, TitleColor and VerticalTextAlignment. All of the properties are backed by BindableProperty objects, which means that they can be styled, and the properties can be targets of data bindings.", "TimePicker invokes the platform's time-picker control and allows you to select a time. TimePicker defines the following properties: Time of type TimeSpan, the selected time, which defaults to a TimeSpan of 0. The TimeSpan type indicates a duration of time since midnight. TextColor of type Color, the color used to display the selected time. FontSize of type double, which defaults to -1.0. CharacterSpacing, of type double, is the spacing between characters of the TimePicker text.", " DatePicker invokes the platform's date-picker control and allows you to select a date. DatePicker defines MinimumDate, MaximumDate, Date, Format, TextColor, FontAttributes, FontFamily, FontSize and CharacterSpacing. All eight properties are backed by BindableProperty objects, which means that they can be styled, and the properties can be targets of data bindings." };

    public int clicks = 0;
    public int num;

    public string[] img = new string[5];

    public ViewsP2_UserInterface()
    {
        InitializeComponent();

        img[0] = "searchbar.png";
        img[1] = "progressbar.png";
        img[2] = "picker.png";
        img[3] = "timepicker.png";
        img[4] = "datepicker.png";
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

        UpdateQ();

        progressBar.Progress += 0.18;

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

        UpdateQ();

        progressBar.Progress -= 0.18;

        Questions questions = new Questions();

        questions.QuestionsChange(clicks, headText, mainText, img, First_Text, Second_Text, IMage1, headText.Length);
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    private void UpdateQ()
    {
        question.Text = clicks.ToString() + " / " + headText.Length.ToString() + " Questions";
    }
}