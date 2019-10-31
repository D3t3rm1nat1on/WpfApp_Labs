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

namespace WpfApp_Labs.Lab_1
{
    /// <summary>
    /// Логика взаимодействия для Lab_1.xaml
    /// </summary>
    public partial class Lab_1 : Window
    {
        public Lab_1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a, b;
            // Проверка на числовое значение строк в текстбоксах
            if(int.TryParse(TextBox1.Text, out a) && int.TryParse(TextBox2.Text, out b))
            {
                Label.Content = Function.Lab_1(a, b);
            }
            else
            {
                Label.Content = "Ошибка ввода";
            }
        }
    }
}
