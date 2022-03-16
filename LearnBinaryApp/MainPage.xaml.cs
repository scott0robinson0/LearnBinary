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
        private static Question question = new Question();
        public MainPage()
        {
            this.InitializeComponent();

            txtQuestion.Text = question.ToString();

            int test = -2;

            txtQuestion.Text = Convert.ToString(test, 2);

            // Colour code binary and decimal numbers to differentiate them, e.g. 11 could be 3 or eleven.
        }

        private void NewQuestion_Click(object sender, RoutedEventArgs e)
        {
            question = new Question();
            txtQuestion.Text = question.ToString();
        }

        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            question.CheckAnswer(txtAnswer.Text);
        }

        private void btnRevealAnswer_Click(object sender, RoutedEventArgs e)
        {
            txtRevealAnswer.Text = question.CorrectAnswer.ToString();
        }
    }
}
