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
using System.Windows.Shapes;

namespace Pract14
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Сохранить_Настройки_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                int rowCount = Int32.Parse(inputRowCount.Text);
                int columnCount = Int32.Parse(inputColumnCount.Text);

                StreamWriter streamWriter = new("config.ini");
                using (streamWriter)
                {
                    streamWriter.WriteLine(rowCount);
                    streamWriter.WriteLine(columnCount);
                    Close();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
