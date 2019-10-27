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

namespace WpfApp_Labs.Lab_9
{
    /// <summary>
    /// Логика взаимодействия для Dialog_Window.xaml
    /// </summary>
    public partial class Dialog_Window : Window
    {
        public Dialog_Window()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            string path = TextBox_Path.Text.Trim();
            if (Directory.Exists(path))
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
