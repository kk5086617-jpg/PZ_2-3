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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ListBox3.ItemsSource = null;
            ListBox3.Items.Clear();

            // 1. Считываем строку из TextBox и разбиваем её на отдельные элементы по пробелам
            string input = TextBox3.Text;
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 2. Преобразуем массив строк в массив целых чисел
            List<int> A = new List<int>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    A.Add(number);
                }
            }

            // 3. Проверяем, достаточно ли элементов в массиве (минимум 10, чтобы существовали A[1] и A[10])
            if (A.Count < 10)
            {
                ListBox3.Items.Add("Ошибка: в массиве должно быть минимум 10 элементов!");
                return;
            }

            // Сохраняем значения A[1] и A[10] с учетом сдвига индексов C# (0-й и 9-й элементы)
            int firstElement = A[0];
            int tenthElement = A[9];

            int resultIndex = 0; // По умолчанию 0, если ничего не найдено

            // 4. Ищем первый элемент, удовлетворяющий двойному неравенству
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > firstElement && A[i] < tenthElement)
                {
                    resultIndex = i + 1; // +1, чтобы вывести порядковый номер (от 1), а не индекс C#
                    break; // Нам нужен только первый такой элемент, выходим из цикла
                }
            }

            // 5. Выводим результат в ListBox2
            ListBox3.Items.Add($"Номер элемента: {resultIndex}");
        }

    }
}

