using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для DataCompressingPage.xaml
    /// </summary>
    public partial class DataCompressingPage : Page
    {
        RLECoder RLE;
        public DataCompressingPage()
        {
            InitializeComponent();
            RLE = new RLECoder();
        }
        private void InvokeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (inputTxtBox.Text.Length != 0)
            {
                inputSymbolsNumTxtBox.Text = inputTxtBox.Text.Length.ToString();
                string output;
                if (codeTypeRDBtn.IsChecked.Value)
                {
                    Regex rx = new Regex(@"(\d)");
                    if (rx.Match(inputTxtBox.Text).Success)
                    {
                        MessageBox.Show("Введите корректную последовательность без чисел");
                        return;
                    }
                    output = RLE.Encode(inputTxtBox.Text);
                   
                }
                else
                {
                    if (inputTxtBox.Text.Last() > 57 || inputTxtBox.Text.Last() < 48)
                    {
                        MessageBox.Show("Введите корректную последовательность");
                        return;
                    }
                    output = RLE.Decode(inputTxtBox.Text);
                }
                outputTxtBox.Text = output;
                outputSymbolsNumTxtBox.Text = output.Length.ToString();
                double compression = (double) output.Length / inputTxtBox.Text.Length;
                compressCoefTxtBox.Text = compression.ToString("0.00");
            }
        }

        private void SwapBtn_Click(object sender, RoutedEventArgs e)
        {
            inputTxtBox.Text = outputTxtBox.Text;
            outputTxtBox.Text = "";
        }

    }
}
