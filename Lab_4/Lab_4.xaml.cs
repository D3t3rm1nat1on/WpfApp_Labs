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

namespace WpfApp_Labs.Lab_4
{
    /// <summary>
    /// Логика взаимодействия для Lab_4.xaml
    /// </summary>
    public partial class Lab_4 : Window
    {
        public Lab_4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox1.Text, out int n) && int.TryParse(TextBox2.Text, out int m))
            {
                Result_form window = new Result_form();
                window.Label.Content = Function.Lab_4(n, m);
                window.ShowDialog();
            }
            else
            {
                Label.Content = "Ошибка ввода";
            }
        }
    }
}
