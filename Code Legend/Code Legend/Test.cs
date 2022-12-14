using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Legend
{
    internal class Test
    {
        public void SetQuestions(int num, string[] question, Label label)
        {
            if (num <= question.Length)
            {

                try
                {
                    label.Text = question[num + 1];
                }
                catch
                {

                }
            }
        }

        public void SetAnswers(int num, string[] ans1, string[] ans2, string[] ans3, Label answer1, Label answer2, Label answer3)
        {
            if (num <= ans1.Length)
            {
                try
                {
                    answer1.Text = ans1[num + 1];
                    answer2.Text = ans2[num + 1];
                    answer3.Text = ans3[num + 1];
                }
                catch
                {

                }
            }
        }
    }
}
