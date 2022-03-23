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
        private static ArithmeticQuestion question = new ArithmeticQuestion();
        public MainPage()
        {
            this.InitializeComponent();

            tbQuestion.Text = question.ToString();

            // Colour code binary and decimal numbers to differentiate them, e.g. 11 could be 3 or eleven.
        }

        private void BtnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            //question = new ConversionQuestion();
            question = new ArithmeticQuestion();
            tbQuestion.Text = question.ToString();
            tbResult.Text = "";
            tbRevealAnswer.Text = "";
            txtAnswer.Text = "";
        }

        private void BtnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = question.CheckAnswer(txtAnswer.Text) ? "Correct!" : "Incorrect.";
        }

        private void BtnRevealAnswer_Click(object sender, RoutedEventArgs e)
        {
            tbRevealAnswer.Text = question.CorrectAnswer.ToString();
        }
    }
}
