
namespace Code_Legend;

public partial class FS_Test : ContentPage
{
    public string[] questions = { "What Label can be?", "What is Button defining?", "When the Clicked event raised?", "What is Image defining?" , "What StackLayout is used for?", "What views does HorizontalStackLayout organize?", "To position Grid cells is using?" };

    public string[] answer1 = { "colored, spaced", "Clicked", "When the Button tap finger or mouse pointer is released from the button’s surfac.", "Aspect, Clicked, IsAnimationPlaying, Source", "To organize child views in a one-demensional horizontal stack.", "child views", "RowDefinition and ColumnDefinitions" };
    public string[] answer2 = { "colored, text decorated; ", "Clicked, Pressed, Released", "When finger or mouse pointer presses on a Button.", "Aspect, Source, IsAnimationPlaying, IsLoading, IsOpaque, Source.", "To organize child views in a one-demensional vertical stack.", "It doesn’t organize views", "RowDefinition and ColumnDefinitions" };
    public string[] answer3 = { "colored, spaced, text decorated", "Clicked, Pressed", "When finger or mouse pointer presses on a Button.", "Aspect, IsAnimationPlaying, IsLoading, Source", "To organize elements in a one-demensional stack", "I don’t know.", "Grid.ColumnSpan and Grid.RowSpan" };

    public string[] correctAnswers = {"ans3" , "ans2", "ans1", "ans2", "ans1", "ans1", "ans1" };

    public int clicks = -1;
    public int score = 0;

    public int num;

	public FS_Test()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        AddTest();
        Questions questions = new Questions();

        questions.CheckTheme(num);

    }

    private async void NextBtn_Clicked(object sender, EventArgs e)
    {
        clicks++;

        progressBar.Progress += 0.14;

        if (clicks < questions.Length)
        {
            AddTest();

            if (correctAnswers[clicks] == check1.ClassId && check1.IsChecked == true)
            {
                score++;
            }

            if (correctAnswers[clicks] == check2.ClassId && check2.IsChecked == true)
            {
                score++;
            }

            if (correctAnswers[clicks] == check3.ClassId && check3.IsChecked == true)
            {
                score++;
            }

            check1.IsChecked = false;
            check2.IsChecked = false;
            check3.IsChecked = false;
        }

        if (clicks == questions.Length)
        {
            await DisplayAlert("Results", "Score: " + score.ToString() + "/7", "Ok");
        }

        if (clicks == questions.Length + 1)
        {
            await Navigation.PopAsync();
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Test", "You can't return to the previous question but you can do the test again if you want!", "Ok");
    }

    private void UpdateQ()
    {
        question.Text = (clicks + 1).ToString() + " / " + questions.Length.ToString() + " Questions";
    }

    private void AddTest()
    {
        Test test = new Test();

        UpdateQ();

        test.SetQuestions(clicks, questions, questionLbl);
        test.SetAnswers(clicks, answer1, answer2, answer3, ans1, ans2, ans3);
    }
}