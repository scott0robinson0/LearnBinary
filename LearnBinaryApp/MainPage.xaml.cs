using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LearnBinaryLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LearnBinaryApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private static ConversionQuestion question = new ConversionQuestion();
        //private static ArithmeticQuestion question = new ArithmeticQuestion();

        private static Question question;

        private static void NewQuestion()
        {
            Random random = new Random();

            switch (random.Next(0, 2))
            {
                case 0:
                    question = new ArithmeticQuestion();
                    break;
                case 1:
                    question = new ConversionQuestion();
                    break;
            }

        }

        //private static Question GenertateRandomQuestion()
        //{
        //    Random random = new Random();

        //    switch (random.Next(0, 2))
        //    {
        //        case 0:
        //            ArithmeticQuestion question3 = new ArithmeticQuestion();
        //            return question3;
        //        case 1:
        //            ConversionQuestion question4 = new ConversionQuestion();
        //            return question4;
        //        default:
        //            throw new Exception("");
        //    }

        //}

        public Question test()
        {
            ArithmeticQuestion question2 = new ArithmeticQuestion();
            return question2;
        }

        public MainPage()
        {
            this.InitializeComponent();

            NewQuestion();

            tbQuestion.Text = question.ToString();

            // Colour code binary and decimal numbers to differentiate them? e.g. 11 could be 3 or eleven.
        }

        private void BtnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            //question = new ConversionQuestion();
            //question = new ArithmeticQuestion();
            NewQuestion();
            tbQuestion.Text = question.ToString();
            tbResult.Text = "";
            tbRevealAnswer.Text = "";
            txtAnswer.Text = "";
        }

        private void BtnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (question is ArithmeticQuestion)
            {
                ArithmeticQuestion arithmeticQuestion = (ArithmeticQuestion)question;
                tbResult.Text = arithmeticQuestion.CheckAnswer(txtAnswer.Text) ? "Correct!" : "Incorrect.";
            }
            else if (question is ConversionQuestion)
            {
                ConversionQuestion conversionQuestion = (ConversionQuestion)question;
                tbResult.Text = conversionQuestion.CheckAnswer(txtAnswer.Text) ? "Correct!" : "Incorrect.";
            }
            
        }

        private void BtnRevealAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (question is ArithmeticQuestion)
            {
                ArithmeticQuestion arithmeticQuestion = (ArithmeticQuestion)question;
                tbRevealAnswer.Text = Convert.ToString(arithmeticQuestion.CorrectAnswer, arithmeticQuestion.CorrectAnswerBase);
            }
            else if (question is ConversionQuestion)
            {
                ConversionQuestion conversionQuestion = (ConversionQuestion)question;
                tbRevealAnswer.Text = conversionQuestion.CorrectAnswer;
            }
        }

        private void txtAnswer_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
