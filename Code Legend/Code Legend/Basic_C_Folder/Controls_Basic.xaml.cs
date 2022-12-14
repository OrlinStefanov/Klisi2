namespace Code_Legend;

public partial class Controls_Basic : ContentPage
{
    public string[] headText = { "If-else", "Switch", "For loop", "While loop", "Break" };

    public string[] mainText = { "C# has the following conditional statements:\r\n\r\nUse if to specify a block of code to be executed, if a specified condition is true\r\nUse else to specify a block of code to be executed, if the same condition is false\r\nUse else if to specify a new condition to test, if the first condition is false\r\nUse switch to specify many alternative blocks of code to be executed", "This is how it works:\r\n\r\nThe switch expression is evaluated once\r\nThe value of the expression is compared with the values of each case\r\nIf there is a match, the associated block of code is executed\r\nThe break and default keywords will be described later in this chapter." , "When you know exactly how many times you want to loop through a block of code, use the for loop instead of a while loop. Statement 1 is executed (one time) before the execution of the code block.\r\n\r\nStatement 2 defines the condition for executing the code block.\r\n\r\nStatement 3 is executed (every time) after the code block has been executed.\r\n\r\nThe example below will print the numbers 0 to 4.", "The while loop loops through a block of code as long as a specified condition is True. The do/while loop is a variant of the while loop. This loop will execute the code block once, before checking if the condition is true, then it will repeat the loop as long as the condition is true.", "You have already seen the break statement used in an earlier chapter of this tutorial. It was used to \"jump out\" of a switch statement.\r\n\r\nThe break statement can also be used to jump out of a loop.\r\n\r\nThis example jumps out of the loop when i is equal to 4." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public Controls_Basic()
	{
		InitializeComponent();
        img[0] = "if_else_basic.png";
        img[1] = "switch_basic.png";
        img[2] = "for_basic.jpg";
        img[3] = "while_basic.png";
        img[4] = "break_basic.png";
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