namespace Code_Legend;

public partial class Pages_UserInterface : ContentPage
{
    public string[] headText = { "ContentPage", "FlyoutPage", "NavigationPage", "TabbedPage" };

    public string[] mainText = { "ContentPage displays a single view, which is often a layout such as as Grid or StackLayout, and is the most common page type. ContentPage defines a Content property, of type View, which defines the view that represents the page's content. This property is backed by a BindableProperty object, which means that it can be the target of data bindings, and styled. In addition, ContentPage inherits Title, IconImageSource, BackgroundImageSource, IsBusy, and Padding bindable properties from the Page class.", "FlyoutPage is a page that manages two related pages of information – a flyout page that presents items, and a detail page that presents details about items on the flyout page. FlyoutPage defines Detail, Flyout, FlyoutLayoutBehavior, IsGestureEnabled, IsPresented. The IsGestureEnabled, IsPresented, and FlyoutLayoutBehavior properties are backed by BindableProperty objects, which means that they can be targets of data bindings, and styled. FlyoutPage also defines an IsPresentedChanged event, that's raised when the IsPresented property changes value.", "NavigationPage provides a hierarchical navigation experience where you're able to navigate through pages, forwards and backwards, as desired. NavigationPage provides navigation as a last-in, first-out (LIFO) stack of Page objects. NavigationPage defines BarBackground, BarBackgroundColor, BackButtonTitle, BarTextColor, CurrentPage, HasNavigationBar, NavigationPage, HasBackButton, IconColor, RootPage, TitleIconImageSource and TitleView. The NavigationPage class also defines three events: Pushed, Popped and PoppedToRoot.", "TabbedPage maintains a collection of children of type Page, only one of which is fully visible at a time. Each child is identified by a series of tabs across the top or bottom of the page. Typically, each child will be a ContentPage and when its tab is selected the page content is displayed. TabbedPage defines BarBackground, BarBackgroundColor, BarTextColor, SelectedTabColor and UnselectedTabColor" };

    public int clicks = 0;

    public int num;

    public string[] img = new string[4];

    public Pages_UserInterface()
    {
        InitializeComponent();

        img[0] = "contentpage.png";
        img[1] = "flayoutpage.png";
        img[2] = "navigationpage.png";
        img[3] = "tabbedpage.png";
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

        progressBar.Progress += 0.25;

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

        progressBar.Progress -= 0.25;

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