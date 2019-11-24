using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для HashPage.xaml
    /// </summary>
    public partial class HashPage : Page
    {
        PermutationHash hash;

        public HashPage()
        {
            InitializeComponent();
            hash = new PermutationHash();
        }

        private void AddText_Btn_Click(object sender, RoutedEventArgs e)
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
                hash.setKey(Key_Tb.Text);
                hash.AddText(Input_Tb.Text);
            }
        }

        private void TestText_Btn_Copy_Click(object sender, RoutedEventArgs e)
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
                Output_Tb.Text = hash.TestText(Input_Tb.Text);
            }
        }
    }
}
