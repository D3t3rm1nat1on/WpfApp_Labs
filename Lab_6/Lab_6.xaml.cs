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

namespace WpfApp_Labs.Lab_6
{
    /// <summary>
    /// Логика взаимодействия для Lab_6.xaml
    /// </summary>
    public partial class Lab_6 : Window
    {
        public Lab_6()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Проверка - является ли строка натуральным числом
            if (int.TryParse(TextBox.Text, out int n) && n > 0)
            {
                // Проверка на полиндром (идем посимвольно, т.к. может начинаться с 0)
                string str = TextBox.Text.Trim();
                for (int i = 0; i <= str.Length / 2; i++)
                {
                    if (str[i] != str[str.Length - i - 1])
                    {
                        Label.Content = "Это число не полиндром";
                        return;
                    }
                }
                // Вызов диалога подтверждения записи в файл
                Dialog_window window = new Dialog_window();
                if (window.ShowDialog() == true)
                {
                    StreamWriter writer = new StreamWriter("result.txt");
                    writer.Write(str);
                    writer.Close();
                    MessageBox.Show("Успешная запись в\n" + Environment.CurrentDirectory + "\\result.txt");
                    Label.Content = "Запись произведена успешно";
                }
                else
                {
                    MessageBox.Show("Ну как хотите");
                    Label.Content = "Отмена записи";
                }
            }
            else
            {
                Label.Content = "Ошибка ввода";
            }
        }
    }
}
