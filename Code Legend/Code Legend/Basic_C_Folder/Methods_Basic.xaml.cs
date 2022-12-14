namespace Code_Legend;

public partial class Methods_Basic : ContentPage
{
    public string[] headText = { "Create and call Methods", "Classes and objects" , "OnAppearing() function"};

    public string[] mainText = { "A method is defined with the name of the method, followed by parentheses (). C# provides some pre-defined methods, which you already are familiar with, such as Main(), but you can also create your own methods to perform certain actions.\r\n\r\n To call (execute) a method, write the method's name followed by two parentheses () and a semicolon;\r\n\r\nIn the following example, MyMethod() is used to print a text (the action), when it is called.", "Everything in C# is associated with classes and objects, along with its attributes and methods. For example: in real life, a car is an object. The car has attributes, such as weight and color, and methods, such as drive and brake.\r\n\r\nA Class is like an object constructor, or a \"blueprint\" for creating objects.\r\r\r\r An object is created from a class. We have already created the class named Car, so now we can use this to create objects.\r\n\r\nTo create an object of Car, specify the class name, followed by the object name, and use the keyword new.", "OnAppearing is a virtual method in the Page base class, that does not contain any code (but that does not mean it does not do anything).\r\n\r\nDepending upon which Page subclass you are using, different things might be performed, like the MasterDetailPage performs logic to determine if it should be displayed as a splitview (side-by-side) mode, the native iOS code would do this on an iPad." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public Methods_Basic()
	{
		InitializeComponent();

        img[0] = "methods_basic.png";
        img[1] = "classes_basic.png";
        img[2] = "appear_basic.png";
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