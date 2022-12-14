namespace Code_Legend;

public partial class DataBinding_Fundamentals : ContentPage
{
    public string[] headText = { "Basic bindings", "Basic bindings", "Binding mode", "Binding value converters", "Binding value converters", "Relative bindings" };

    public string[] mainText = { "Data binding links a pair of properties between two objects, at least one of which is usually a user-interface object. These two objects are called the target and the source. In the simplest case, data flows from the source to the target, which means that the value of the target property is set from the value of the source property.", " However, in some cases, data can alternatively flow from the target to the source, or in both directions. Without data bindings, you would set the ValueChanged event of the Slider to an event handler that accesses the Value property of the Slider and sets that value to the Rotation property of the Label. The data binding automates this task, and so the event handler and the code within it are no longer necessary.", "Bindable property has a default binding mode that is set when the bindable property is created, and which is available from the DefaultBindingMode property of the BindableProperty object. This default binding mode indicates the mode in effect when that property is a data-binding target. The default binding mode for most properties such as Rotation, Scale, and Opacity is OneWay. When these properties are data-binding targets, then the target property is set from the source.", "Data bindings usually transfer data from a source property to a target property, and in some cases from the target property to the source property. This transfer is straightforward when the source and target properties are of the same type, or when one type can be converted to the other type through an implicit conversion. When that is not the case, a type conversion must take place.", " In the String formatting article, you saw how you can use the StringFormat property of a data binding to convert any type into a string. For other types of conversions, you need to write some specialized code in a class that implements the IValueConverter interface. Classes that implement IValueConverter are called value converters, but they are also often referred to as binding converters or binding value converters.", "Relative bindings provide the ability to set the binding source relative to the position of the binding target. They are created with the RelativeSource markup extension, and set as the Source property of a binding expression. The RelativeSource markup extension is supported by the RelativeSourceExtension class, which defines Mode, AncestorLevel and AncestorType" };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public DataBinding_Fundamentals()
    {
        InitializeComponent();

        img[0] = ".png";
        img[1] = ".png";
        img[2] = ".png";
        img[3] = ".png";
        img[4] = ".png";
        img[5] = ".png";
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

        progressBar.Progress += 0.2;

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

        progressBar.Progress -= 0.2;

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