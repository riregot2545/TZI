using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TZI
{
    /// <summary>
    /// Логика взаимодействия для ReplacementPage.xaml
    /// </summary>
    public partial class ReplacementPage : Page
    {
        Vishener Vishener = new Vishener();
        public ReplacementPage()
        {
            InitializeComponent();
        }

        private void InvokeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (inputTxtBox.Text.Length != 0 &&
                keyTxtBox.Text.Length != 0)
            {
                string output;
                if (codeTypeRDBtn.IsChecked.Value)
                    output = Vishener.Encode(inputTxtBox.Text, keyTxtBox.Text);
                else
                    output = Vishener.Decode(inputTxtBox.Text, keyTxtBox.Text);
                outputTxtBox.Text = output;
            }
        }

        private void SwapBtn_Click(object sender, RoutedEventArgs e)
        { 
            inputTxtBox.Text = outputTxtBox.Text;
            outputTxtBox.Text = "";
        }
    }
}
