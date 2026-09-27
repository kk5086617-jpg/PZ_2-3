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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        // метод проверки является ли число простым
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // метод проверки является ли число совершенным
        private bool IsPerfect(int number)
        {
            if (number <= 1) return false;
            int sum = 1; 
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                    if (i * i != number)
                    {
                        sum += number / i;
                    }
                }
            }
            return sum == number;
        }

        public Window4()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox4.ItemsSource = null;
            ListBox4.Items.Clear();

            // парсим введенную строку в список чисел
            string input = TextBox4.Text;
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> A = new List<int>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    A.Add(number);
                }
            }

            int primeIndex = -1;
            int perfectIndex = -1;

            // ищем индексы первого простого и первого совершенного чисел
            for (int i = 0; i < A.Count; i++)
            {
                if (primeIndex == -1 && IsPrime(A[i]))
                {
                    primeIndex = i;
                }
                if (perfectIndex == -1 && IsPerfect(A[i]))
                {
                    perfectIndex = i;
                }
            }

            // если оба числа найдены меняем их местами
            if (primeIndex != -1 && perfectIndex != -1)
            {
                int temp = A[primeIndex];
                A[primeIndex] = A[perfectIndex];
                A[perfectIndex] = temp;

                // выводим измененный массив в листбокс
                foreach (int num in A)
                {
                    ListBox4.Items.Add(num);
                }
            }
            else
            {
                // если какое-то из чисел не найдено
                ListBox4.Items.Add("Ошибка: В массиве отсутствуют");
                if (primeIndex == -1) ListBox4.Items.Add("- простые числа");
                if (perfectIndex == -1) ListBox4.Items.Add("- совершенные числа (например: 6, 28, 496)");
            }
        }
    }
}
