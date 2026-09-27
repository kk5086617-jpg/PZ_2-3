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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ListBox1.ItemsSource = null;

            
            string input = TextBox1.Text;

            
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Пожалуйста, введите число!");
                return;
            }

            
            var duplicate = input.GroupBy(c => c)
                                       .Where(g => g.Count() > 1)
                                       .Select(g => $"Цифра '{g.Key}' повторяется {g.Count()} раз(а)");
            

            
            ListBox1.ItemsSource = duplicate.ToList();
        }
    }
}
