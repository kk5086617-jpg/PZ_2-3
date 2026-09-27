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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 Zadanie1 = new Window1();
            Zadanie1.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 Zadanie2 = new Window2();
            Zadanie2.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window3 Zadanie3 = new Window3();
            Zadanie3.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window4 Zadanie4 = new Window4();
            Zadanie4.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window5 Zadanie5 = new Window5();
            Zadanie5.Show();
        }

        private void Coc_Click(object sender, RoutedEventArgs e)
        {
             cat.Visibility = Visibility.Visible;
        }
    }
}
