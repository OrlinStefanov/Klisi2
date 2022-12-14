namespace Code_Legend;

public partial class Templates_Fundamentals : ContentPage
{
    public string[] headText = { "ControlTemplate", "ControlTemplate", "ControlTeplate", "DataTemplate", "DataTemplate", "InlineDataTemplate" };

    public string[] mainText = { "Control templates enable you to define the visual structure of ContentView derived custom controls, and ContentPage derived pages. Control templates separate the user interface (UI) for a custom control, or page, from the logic that implements the control or page. Additional content can also be inserted into the templated custom control, or templated page, at a pre-defined location.", "A control template is created with the ControlTemplate type. When you create a ControlTemplate, you combine View objects to build the UI for a custom control, or page. A ControlTemplate must have only one View as its root element. However, the root element usually contains other View objects. The combination of objects makes up the control's visual structure.", "A ControlTemplate can be applied to a ContentView derived custom control by setting its ControlTemplate property to the control template object. Similarly, a ControlTemplate can be applied to a ContentPage derived page by setting its ControlTemplate property to the control template object. At runtime, when a ControlTemplate is applied, all of the controls that are defined in the ControlTemplate are added to the visual tree of the templated custom control, or templated page.", "Data templates provide the ability to define the presentation of data on supported controls. Consider a CollectionView that displays a collection of Person objects. The picture shows the definition of the Person class. The Person class defines Name, Age, and Location properties, which can be set when a Person object is created. A control that displays collections, such as CollectionView, can be used to display Person objects. In this example, items are added to the CollectionView by initializing its ItemsSource property from an array of Person objects. CollectionView calls ToString when displaying the objects in the collection.", "A DataTemplate is used to specify the appearance of data, and typically uses data binding to display data. A common usage scenario for data templates is when displaying data from a collection of objects in a control such as a CollectionView or CarouselView. For example, when a CollectionView is bound to a collection of Person objects, the CollectionView.ItemTemplate property can be set to a DataTemplate that defines the appearance of each Person object in the CollectionView. The DataTemplate will contain objects that bind to property values of each Person object.", "An inline data template, which is one that's defined inline in a control, should be used if there's no need to reuse the data template elsewhere. The objects specified in the DataTemplate define the appearance of each item of data. A control such as CollectionView can then set its ItemTemplate property to the inline DataTemplate. In a CollectionView, the child of an inline DataTemplate must derive from BindableObject." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public Templates_Fundamentals()
    {
        InitializeComponent();

        img[0] = "controltemplates.png";
        img[1] = "controltemplates.png";
        img[2] = "controltemplatesresults.png";
        img[3] = "datatemplates.png";
        img[4] = "datatemplates2.png";
        img[5] = "datatemplates.png";
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

        progressBar.Progress += 0.14;

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

        progressBar.Progress -= 0.14;

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