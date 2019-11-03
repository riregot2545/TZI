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
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ReplacementPage());
        }

        private void PerestanovkaBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReplacementPage());
        }

        private void VishenerBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PermutationPage());
        }
    }
}
