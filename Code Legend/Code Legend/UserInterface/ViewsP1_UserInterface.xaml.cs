namespace Code_Legend;

public partial class ViewsP1_UserInterface : ContentPage
{
    public string[] headText = { "Frame", "ImageButton", "RadioButton", "CheckBox", "BoxView" };

    public string[] mainText = { "Frame is used to wrap a view or layout with a border that can be configured with color, shadow, and other options. Frames can be used to create borders around controls but can also be used to create more complex UI.", "ImageButton view combines the Button view and Image view to create a button whose content is an image. When you press the ImageButton with a finger or click it with a mouse, it directs the app to carry out a task. However, unlike the Button the ImageButton view has no concept of text and text appearance. The ImageButton has the same defines like a normal Button.", "RadioButton is a type of button that allows users to select one option from a set. Each option is represented by one radio button, and you can only select one radio button in a group. RadioButton also defines a CheckedChanged event that's raised when the IsChecked property changes, either through user or programmatic manipulation.", "CheckBox is a type of button that can either be checked or empty. When a checkbox is checked, it's considered to be on. When a checkbox is empty, it's considered to be off. CheckBox defines IsChecked, of type bool, which indicates whether the CheckBox is checked. This property has a default binding mode of TwoWay. Color, of type Color, which indicates the color of the CheckBox. CheckBox defines a CheckedChanged event that's raised when the IsChecked property changes, either through user manipulation or when an application sets the IsChecked property.", "BoxView draws a simple rectangle or square, of a specified width, height, and color. BoxView defines the following properties: Color, of type Color, which defines the color of the BoxView. CornerRadius, of type CornerRadius, which defines the corner radius of the BoxView. This property can be set to a single double uniform corner radius value, or a CornerRadius structure defined by four double values that are applied to the top left, top right, bottom left, and bottom right of the BoxView." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[5];


    public ViewsP1_UserInterface()
    {
        InitializeComponent();

        img[0] = "frame.png";
        img[1] = "imagebutton.png";
        img[2] = "radiobutton.png";
        img[3] = "checkbox.png";
        img[4] = "boxview.png";
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

        progressBar.Progress += 0.18;

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