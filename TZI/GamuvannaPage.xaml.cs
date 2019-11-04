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
    /// Логика взаимодействия для GamuvannaPage.xaml
    /// </summary>
    public partial class GamuvannaPage : Page
    {
        ModueSum modueSum;
        public GamuvannaPage()
        {
            InitializeComponent();
            modueSum = new ModueSum();
        }
        private void InvokeBtn_Click(object sender, RoutedEventArgs e)
        {

            if (inputTxtBox.Text.Length != 0 &&
                keyTxtBox.Text.Length != 0)
            {
                string output;
                if (codeTypeRDBtn.IsChecked.Value)
                    output = modueSum.Encode(inputTxtBox.Text, keyTxtBox.Text);
                else
                    output = modueSum.Decode(inputTxtBox.Text, keyTxtBox.Text);
                outputTxtBox.Text = output;
            }
        }

        private void SwapBtn_Click(object sender, RoutedEventArgs e)
        {
            inputTxtBox.Text = outputTxtBox.Text;
            outputTxtBox.Text = "";
        }

        private void GenerateKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            keyTxtBox.Text = ModueSum.GenerateKey(6);
        }
    }
}
