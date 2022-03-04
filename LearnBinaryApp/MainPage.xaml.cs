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
        public MainPage()
        {
            this.InitializeComponent();

            //byte val1 = 10;
            //byte val2 = 20;
            //ushort val3 = 0;

            //val3 = Convert.ToUInt16(val1 + val2);

            //test.Text = Convert.ToString(val3, 2);

            //test.Text = Convert.ToString(val1, 2).PadLeft(8, '0');

            //test.Text = Convert.ToString((val1 - val2), 2);

        }

        private void NewQuestion_Click(object sender, RoutedEventArgs e)
        {
            Question question = new Question();

            test.Text = question.GenerateQuestion();
        }
    }
}
