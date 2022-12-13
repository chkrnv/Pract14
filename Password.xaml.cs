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

namespace Pract14
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Window_Activate(object sender, EventArgs e)
        {
            inputPassword.Focus();
        }

        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            if (inputPassword.Password == "123")
            {
                Close();
            }
            else
            {
                MessageBox.Show("Пароль неверен. Повторите ввод.");
                inputPassword.Clear();
                inputPassword.Focus();
            }
        }

        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }
    }
}
