using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Legend;

internal class Questions
{
    public void QuestionsChange(int clicks, string[] headText, string[] mainText, string[] img, Label head, Label main, Image mainIMg, int num)
    {
        try
        {
            if (clicks < num && clicks >= 0)
            {
                if (mainIMg.IsVisible == false)
                {
                    mainIMg.IsVisible = true;
                    head.VerticalOptions = LayoutOptions.Start;
                }

                head.Text = headText[clicks];
                main.Text = mainText[clicks];

                mainIMg.Source = img[clicks];
            }

            if (clicks == num)
            {
                Random r = new Random();

                string[] finals = { "Keep going and on every 3 lessons do the tests!", "Congratulations you passed this! On every 3 lessons do the tests!", "You are advancing quickly but you better do the tests on every 3 lessons!"};

                head.Text = finals[r.Next(3)];
                head.VerticalOptions = LayoutOptions.Center;

                main.Text = "";

                mainIMg.IsVisible = false;
            }

        } catch
        {

        }
    }

    public async void CheckTheme(int num)
    {
        num = Convert.ToInt16(await SecureStorage.GetAsync("num"));

        if (num == 1)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }

        if (num == 2)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            num = 0;
        }
    }
}