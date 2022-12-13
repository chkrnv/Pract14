using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using LibMatrix;

namespace Pract14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Matrix<int> matrix;

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Password pas = new();
            pas.ShowDialog();
            pas.Owner = this;
        }

        public void Выход_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы уверены, что хотите выйти?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        public void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = @".\matrix" + matrix.Extension;
                matrix.Save(path);
                MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Открыть_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = @".\matrix" + matrix.Extension;
                matrix.Open(path);
                dataGrid.ItemsSource = matrix.ToDataTable().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void О_Программе_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M * N." +
                 "Найти номер первого из ее столбцов,содержащих только нечетные числа." +
                 "Если таких столбцов нет, то вывести 0.", "О программе");
        }

        public void Очистить_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            result.Text = null;
        }

        public void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result.Text = null;

                StreamReader streamReader = new("config.ini");
                using (streamReader)
                {
                    int rowCount = Convert.ToInt32(streamReader.ReadLine());
                    int columnCount = Convert.ToInt32(streamReader.ReadLine());
                    int res = matrix.Calculate(rowCount, columnCount);
                    result.Text = res.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Настроить_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new();
            settings.ShowDialog();
            settings.Owner = this;
        }

        private void Создать_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader streamReader = new("config.ini");
                using (streamReader)
                {
                    int rowCount = Convert.ToInt32(streamReader.ReadLine());
                    int columnCount = Convert.ToInt32(streamReader.ReadLine());
                    int minValue = Convert.ToInt32(streamReader.ReadLine());
                    int maxValue = Convert.ToInt32(streamReader.ReadLine());

                    matrix = new Matrix<int>(rowCount, columnCount);
                    matrix.Fill(rowCount, columnCount, minValue, maxValue);
                    dataGrid.ItemsSource = matrix.ToDataTable().DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
