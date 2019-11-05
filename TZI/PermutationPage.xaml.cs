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
    /// Логика взаимодействия для PermutationPage.xaml
    /// </summary>
    public partial class PermutationPage : Page
    {
        public PermutationPage()
        {
            InitializeComponent();
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
                string inKey = Key_Tb.Text;
                string[] token = inKey.Split(' ');
                for (int i = 0; i < token.Length; i++)
                {
                    for (int j = i + 1; j < token.Length; j++)
                    {
                        if (token[i] == token[j])
                            return;
                    }
                }


                SinglePermutation singlePermutation = new SinglePermutation();
                singlePermutation.setKey(Key_Tb.Text);
                if (Encrypt_Rbtn.IsChecked == true)
                    Output_Tb.Text = singlePermutation.Encrypt(Input_Tb.Text);
                else if (Decrypt_Rbtn.IsChecked == true)
                    Output_Tb.Text = singlePermutation.Decrypt(Input_Tb.Text);
                else
                    MessageBox.Show("Выберите расшифрование или зашифрование");
            }
        }
    }
}
