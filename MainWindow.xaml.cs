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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_Labs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    /// <summary>
    /// Класс описывающий логику для вычесления результата
    /// </summary>
    public static class Function
    {
        public static string Lab_1(int a, int b)
        {
            string result = null;
            int max = Math.Max(a, b);
            int min = Math.Max(0, Math.Min(a, b));

            for (int i = min; i <= max; i += 4)
            {
                result += $"{i} ";
            }

            return result;
        }

        public static string Lab_2(string str)
        {
            int sum = 0;
            int[] mas = str.Split().Select(int.Parse).ToArray();
            foreach (var a in mas)
            {
                if (a < 100 && a > 20 && a % 3 == 0)
                {
                    int last = a % 10;
                    if (last == 2 || last == 4 || last == 8)
                        sum += a;
                }
            }

            return sum.ToString();
        }

        public static string Lab_3(uint a)
        {
            string result = null;
            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                    result += $"{i} ";
            }

            return result;
        }

        public static string Lab_4(int n, int m)
        {
            string result = null;
            int a = Math.Max(n, m);
            int max = n * m;
            for (int i = a; i < max; i++)
            {
                if (i % n == 0 && i % m == 0)
                    result += $"{i} ";
            }
            return result;
        }

        public static string Lab_5()
        {
            string result = null;
            for (int a = 1; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        if (a + b + c == 7 && (a * 100 + b * 10 + c) % 7 == 0)
                        {
                            result += $"{a * 100 + b * 10 + c} ";
                        }
                    }
                }
            }

            return result;
        }
    }
}
