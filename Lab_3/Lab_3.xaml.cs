using Microsoft.Win32;
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

namespace WpfApp_Labs.Lab_3
{
    /// <summary>
    /// Логика взаимодействия для Lab_3.xaml
    /// </summary>
    public partial class Lab_3 : Window
    {
        public Lab_3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string res = null;
            int n;
            if (int.TryParse(TextBox.Text, out n) && n > 0)
            {
                res = Function.Lab_3(n);
                Label.Content = res;
            }
            else
            {
                Label.Content = "Ошибка ввода";
                return;
            }


            Dialog_Window window = new Dialog_Window();

            if (window.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter("output.txt");
                writer.Write(res);
                MessageBox.Show("Успешная запись в" + Environment.CurrentDirectory + "\\output.txt");
                writer.Close();
            }
            else
            {
                MessageBox.Show("Ну как хотите");
            }
        }
    }
}
