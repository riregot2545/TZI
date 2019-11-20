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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listNavigate;
        public MainWindow()
        {
            InitializeComponent();
            listNavigate = new List<string> { "Виженер", "Перестановка","Сумма по модулю 26", "Упр. алгоритм Луна" };
            Navi_Cmb.ItemsSource = listNavigate;
            Navi_Cmb.SelectedIndex = 0;
            //MainFrame.Navigate(new ReplacementPage());
        }

        private void Navi_Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Navi_Cmb.SelectedIndex)
            {
                case 0:
                    MainFrame.Navigate(new ReplacementPage());
                    break;
                case 1:
                    MainFrame.Navigate(new PermutationPage());
                    break;
                case 2:
                    MainFrame.Navigate(new GamuvannaPage());
                    break;
                case 3:
                    MainFrame.Navigate(new IntegrityСheck());
                    break;
                default:
                    MainFrame.Navigate(new ReplacementPage());
                    break;
            }
        }
    }
}
