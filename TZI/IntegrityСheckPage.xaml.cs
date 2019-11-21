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
    /// Логика взаимодействия для IntegrityСheck.xaml
    /// </summary>
    public partial class IntegrityСheckPage : Page
    {
        LunSimple Lun = new LunSimple();
        public IntegrityСheckPage()
        {
            InitializeComponent();

        }
        private void InvokeBtn_Click(object sender, RoutedEventArgs e)
        {
            inputCorrectLabel.Visibility = Visibility.Hidden;
            inputNOTCorrectLabel.Visibility = Visibility.Hidden;
            sumResultTxtBox.Text = String.Empty;
            if (inputTxtBox.Text.Length != 0)
            {
                if (!isOnlyDigit(inputTxtBox.Text))
                {
                    MessageBox.Show("Введите исключительно числовые данные с возможными пробелами");
                    return;
                }
                if (Lun.Check(inputTxtBox.Text))
                {
                    inputCorrectLabel.Visibility = Visibility.Visible;
                    sumResultTxtBox.Text = Lun.Sum.ToString();
                }
                else
                {
                    inputNOTCorrectLabel.Visibility = Visibility.Visible;
                    sumResultTxtBox.Text = Lun.Sum.ToString();
                }
            }
        }

        private bool isOnlyDigit(string input)
        {
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i]!= 32 && (charArray[i] < 48 || charArray[i]>57))
                    return false;
            }
            return true;
        }
    }
}
