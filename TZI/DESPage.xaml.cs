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
    /// Логика взаимодействия для dESPage.xaml
    /// </summary>
    public partial class DESPage : Page
    {

        CipherDES dES;
        public DESPage()
        {
            InitializeComponent();
            dES = new CipherDES();
        }

        private void Crypt_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Key_Tb.Text.Length == 0 || Input_Tb.Text.Length == 0)
            {
                MessageBox.Show("Проверте правильность ввода ключа и текста");
                return;
            }
            else
            {
                string[] result = new string[2];
                if (Encrypt_Rbtn.IsChecked == true)
                {
                    result = dES.Encrypt(Input_Tb.Text, Key_Tb.Text);
                    Key_Tb.Text = result[0];
                    Output_Tb.Text = result[1];
                }
                else if (Decrypt_Rbtn.IsChecked == true)
                {
                    result = dES.Decrypt(Input_Tb.Text, Key_Tb.Text);
                    Key_Tb.Text = result[0];
                    Output_Tb.Text = result[1];
                }
                else
                    MessageBox.Show("Выберите расшифрование или зашифрование");
            }
        }

        private void Swap_Btn_Click(object sender, RoutedEventArgs e)
        {
            Input_Tb.Text = Output_Tb.Text;
            Output_Tb.Clear();
        }
    }
}
