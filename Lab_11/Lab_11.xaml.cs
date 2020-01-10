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

namespace WpfApp_Labs.Lab_11
{
    /// <summary>
    /// Логика взаимодействия для Lab_11.xaml
    /// </summary>
    public partial class Lab_11 : Window
    {
        public Lab_11()
        {
            InitializeComponent();
            WebBrowser.Navigate("http://google.com");
            List<string> history = new List<string>() { "http://google.com" };
        }

        private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            MessageBox.Show("Navigated");
        }

    }
}
