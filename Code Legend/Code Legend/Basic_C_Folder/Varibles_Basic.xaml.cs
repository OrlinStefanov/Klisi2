namespace Code_Legend;

public partial class Varibles_Basic : ContentPage
{
    public string[] headText = { "Variables", "Int and double", "Char and string", "Bool" };

    public string[] mainText = { "Variables are containers for storing data values.\r\n\r\nIn C#, there are different types of variables (defined with different keywords), for example:\r\n\r\nint - stores integers (whole numbers), without decimals, such as 123 or -123\r\ndouble - stores floating point numbers, with decimals, such as 19.99 or -19.99\r\nchar - stores single characters, such as 'a' or 'B'. Char values are surrounded by single quotes\r\nstring - stores text, such as \"Hello World\". String values are surrounded by double quotes\r\nbool - stores values with two states: true or false", "Int data types are used to store whole numbers that range from 2147483647 to -2147483648. The majority of the time when you work with numeric values in C#, you will be using the int data type.\r\n\r\n Double data types in C# are used to store floating point numbers that are too large for a float. You can store values ranging from 1.7e−308 to 1.7e+308 in a double. Best practices dictate that a double end in the letter D. You can see how to convert string to int too. If you want to convert int to string we use .ToString().", "There are data types in C# that handle text as well as numbers. The first of these is the char data type, which is used to store a single character. To create one, make sure you character is encased by a pair of single quotes, such as ‘A’. You can store any letter, number, or special character as a char value, so long as it is surrounded by single quotes.\r\n\r\n The other text data type in C# is known as a string. strings are used to store longer sequences of characters than a char. Instead of using single quotes to define them, strings are created using double-quotes.", "he bool type keyword is an alias for the .NET System.Boolean structure type that represents a Boolean value, which can be either true or false.\r\n\r\nTo perform logical operations with values of the bool type, use Boolean logical operators. The bool type is the result type of comparison and equality operators. A bool expression can be a controlling conditional expression in the if, do, while, and for statements and in the conditional operator ?:.\r\n\r\nThe default value of the bool type is false." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public Varibles_Basic()
	{
		InitializeComponent();

        img[0] = "variables_basic.jpg";
        img[1] = "int_basic.png";
        img[2] = "string_basic.png";
        img[3] = "bool_basic.jpg";
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

        progressBar.Progress += 0.25;

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

        progressBar.Progress -= 0.25;

        UpdateQ();

        Questions questions = new Questions();

        questions.QuestionsChange(clicks, headText, mainText, img, First_Text, Second_Text, IMage1, headText.Length);
    }

    private void UpdateQ()
    {
        question.Text = clicks.ToString() + " / " + headText.Length.ToString() + " Questions";
    }
}