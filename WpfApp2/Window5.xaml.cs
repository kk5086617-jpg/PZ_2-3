using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            // 1. Валидация ввода размеров матрицы
            if (!int.TryParse(TxtRows.Text, out int n) || !int.TryParse(TxtCols.Text, out int m) || n <= 0 || m <= 0)
            {
                MessageBox.Show("Введите корректные положительные числа для строк и столбцов.", "Ошибка");
                return;
            }

            // 2. Генерация исходного массива случайных чисел от -10 до 10
            Random rnd = new Random();
            int[,] originalMatrix = new int[n, m];
            List<int> flatList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int value = rnd.Next(-10, 11);
                    originalMatrix[i, j] = value;
                    flatList.Add(value);
                }
            }

            // 3. Поиск минимального и максимального элементов
            int minVal = flatList.Min();
            int maxVal = flatList.Max();
            TxtMin.Text = $"Минимум: {minVal}";
            TxtMax.Text = $"Максимум: {maxVal}";

            // 4. Сортировка данных
            List<int> ascList = flatList.OrderBy(x => x).ToList();
            List<int> descList = flatList.OrderByDescending(x => x).ToList();

            // 5. Отображение результатов в таблицах DataGrid
            GridOriginal.ItemsSource = CreateDataTable(originalMatrix, n, m).DefaultView;
            GridAscending.ItemsSource = CreateDataTableFromList(ascList, n, m).DefaultView;
            GridDescending.ItemsSource = CreateDataTableFromList(descList, n, m).DefaultView;
        }

        // Вспомогательный метод: преобразование двумерного массива в DataTable для DataGrid
        private DataTable CreateDataTable(int[,] matrix, int rows, int cols)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < cols; j++) dt.Columns.Add($"C{j}");

            for (int i = 0; i < rows; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    dr[j] = matrix[i, j];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        // Вспомогательный метод: заполнение DataTable структуры NxM из отсортированного одномерного списка
        private DataTable CreateDataTableFromList(List<int> list, int rows, int cols)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < cols; j++) dt.Columns.Add($"C{j}");

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    if (index < list.Count)
                    {
                        dr[j] = list[index++];
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
