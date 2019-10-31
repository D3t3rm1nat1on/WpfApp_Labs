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

namespace WpfApp_Labs.Lab_2
{
    /// <summary>
    /// Логика взаимодействия для Lab_2.xaml
    /// </summary>
    public partial class Lab_2 : Window
    {
        public Lab_2()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string str = TextBox.Text.Trim();
            // Проверяем все ли символы в строке это числа
            if (!str.Any(char.IsDigit))
            {
                Label.Content = "Ошибка ввода";
                return;
            }
            // Удаляем лишние пробелы из строки на случай для корректности парсинга
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            int[] mas = str.Split().Select(int.Parse).ToArray();
            Label.Content = Function.Lab_2(mas);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Позволяет вводить только числовые значения
            e.Handled = (!char.IsDigit(e.Text, 0));
        }
    }
}
