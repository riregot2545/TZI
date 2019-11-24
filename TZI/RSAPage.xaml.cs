using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Логика взаимодействия для RSAPage.xaml
    /// </summary>
    public partial class RSAPage : Page
    {

        CipherRSA rSA;
        public RSAPage()
        {
            InitializeComponent();
            rSA = new CipherRSA();
        }

        private void Crypt_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Encrypt_Rbtn.IsChecked == true)
            {
                if ((KeyPD_Tb.Text.Length > 0) && (KeyQN_Tb.Text.Length > 0))
                {
                    long p = Convert.ToInt64(KeyPD_Tb.Text);
                    long q = Convert.ToInt64(KeyQN_Tb.Text);

                    string[] result;

                    if (rSA.IsTheNumberSimple(p) && rSA.IsTheNumberSimple(q))
                    {
                        result = rSA.Encrypt(Input_Tb.Text, p, q);
                        Output_Tb.Text = result[0];
                        KeyPD_Tb.Text = result[1];
                        KeyQN_Tb.Text = result[2];
                    }
                    else
                        MessageBox.Show("p или q - не простые числа!");
                }
                else
                    MessageBox.Show("Введите p и q!");
            }
            else if (Decrypt_Rbtn.IsChecked == true)
            {
                if ((KeyPD_Tb.Text.Length > 0) && (KeyQN_Tb.Text.Length > 0))
                {
                    long d = Convert.ToInt64(KeyPD_Tb.Text);
                    long n = Convert.ToInt64(KeyQN_Tb.Text);

                    Output_Tb.Text = rSA.Decrypt(Input_Tb.Text.Split(' '), d, n);
                }
                else
                    MessageBox.Show("Введите d и n!");
            }
            else
                MessageBox.Show("Выберите расшифрование или зашифрование");
        }

        private void Swap_Btn_Click(object sender, RoutedEventArgs e)
        {
            Input_Tb.Text = Output_Tb.Text;
            Output_Tb.Clear();
        }

        private void Encrypt_Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            if (PD_Label != null && QN_Label != null)
            {
                PD_Label.Content = "p = ";
                QN_Label.Content = "q = ";
            }
        }

        private void Decrypt_Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            if (PD_Label != null && QN_Label != null)
            {
                PD_Label.Content = "d = ";
                QN_Label.Content = "n = ";
            }
        }
    }
}
