namespace Code_Legend;

public partial class FS_UserInterface : ContentPage
{
    public string[] headText = { "First steps", "Label", "Button", "Image" };

    public string[] mainText = { "XAML allows developers to define user interfaces in .NET Multi-platform App UI (.NET MAUI) apps using markup rather than code. XAML is not required in a .NET MAUI app, but it is the recommended approach to developing your UI because it's often more succinct, more visually coherent, and has tooling support. XAML is also well suited for use with the Model-View-ViewModel (MVVM) pattern, where XAML defines the view that is linked to viewmodel code through XAML-based data bindings.", "Label displays single-line and multi-line text. Text displayed by a Label can be colored, spaced, and can have text decorations. The properties of the label are backed by BindableProperty objects, which means that they can be targets of data bindings, and styled.", "Button displays text and responds to a tap or click that directs the app to carry out a task. Button defines Clicked, Pressed, and Released events. The Clicked event is raised when a Button tap with a finger or mouse pointer is released from the button's surface. The Pressed event is raised when a finger presses on a Button, or a mouse button is pressed with the pointer positioned over the Button. The Released event is raised when the finger or mouse button is released.", "Image displays an image that can be loaded from a local file, a URI, an embedded resource, or a stream. The standard platform image formats are supported, including animated GIFs, and local SVG files are also supported. Image defines Aspect, IsAnimationPlaying, IsLoading, IsOpaque, Source." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[4];


    public FS_UserInterface()
    {
        InitializeComponent();

        img[0] = "first_steps.png";
        img[1] = "label.png";
        img[2] = "button.png";
        img[3] = "button.png";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        IMage1.Source = img[0];

        UpdateQ();

        Questions questions = new Questions();

        questions.QuestionsChange(0, headText, mainText, img, First_Text, Second_Text, IMage1, 4);
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

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    private void UpdateQ()
    {
        question.Text = clicks.ToString() + " / " + headText.Length.ToString() + " Questions";
    }
}