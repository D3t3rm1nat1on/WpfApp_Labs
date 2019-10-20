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

namespace WpfApp_Labs.Lab_6
{
    /// <summary>
    /// Логика взаимодействия для Dialog_window.xaml
    /// </summary>
    public partial class Dialog_window : Window
    {
        public Dialog_window()
        {
            InitializeComponent();
        }

        private void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_No_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
