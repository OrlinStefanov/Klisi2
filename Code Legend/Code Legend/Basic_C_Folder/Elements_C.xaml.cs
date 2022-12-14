namespace Code_Legend;

public partial class Elements_C : ContentPage
{
    public string[] headText = { "List<T>", "C# FileStream", "C# TextWriter", "C# TextReader" };

    public string[] mainText = { "C# List<T> class is used to store and fetch elements. It can have duplicate elements. It is found in System.Collections.Generic namespace.", "C# FileStream class provides a stream for file operation. It can be used to perform synchronous and asynchronous read and write operations. By the help of FileStream class, we can easily read and write data into file. Let's see the example of FileStream class to read data from the file. Here, ReadByte() method of FileStream class returns single byte. To all read all the bytes, you need to use loop.", "C# TextWriter class is an abstract class. It is used to write text or sequential series of characters into file. It is found in System.IO namespace.Let's see the simple example of TextWriter class to write two lines data.", "C# TextReader class is found in System.IO namespace. It represents a reader that can be used to read text or sequential series of characters. Let's see the simple example of TextReader class that reads data till the end of file." };

    public int clicks = 0;

    public int num;

    public string[] img = new string[6];

    public Elements_C()
	{
		InitializeComponent();
        img[0] = "mylists_basic.png";
        img[1] = "filestream_basic.jpg";
        img[2] = "streamreader_basic.png";
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