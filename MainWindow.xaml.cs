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
            Lab_1.Lab_1 window = new Lab_1.Lab_1();
            window.Show();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            Lab_2.Lab_2 window = new Lab_2.Lab_2();
            window.Show();
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            Lab_3.Lab_3 window = new Lab_3.Lab_3();
            window.Show();
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            Lab_4.Lab_4 window = new Lab_4.Lab_4();
            window.Show();
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            Lab_5.Lab_5 window = new Lab_5.Lab_5();
            window.Show();
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            Lab_6.Lab_6 window = new Lab_6.Lab_6();
            window.Show();
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            Lab_7.Lab_7 window = new Lab_7.Lab_7();
            window.Show();
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            Lab_8.Lab_8 window = new Lab_8.Lab_8();
            window.Show();
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            Lab_9.Lab_9 window = new Lab_9.Lab_9();
            window.Show();
        }

        private void Button_10_Click(object sender, RoutedEventArgs e)
        {
            Lab_10.Lab_10 window = new Lab_10.Lab_10();
            window.Show();
        }

        private void Button_11_Click(object sender, RoutedEventArgs e)
        {
            Lab_11.Lab_11 window = new Lab_11.Lab_11();
            window.Show();
        }

        private void Button_12_Click(object sender, RoutedEventArgs e)
        {
            Lab_12.Lab_12 window = new Lab_12.Lab_12();
            window.Show();
        }
    }

    /// <summary>
    /// Класс описывающий логику для вычесления результата
    /// </summary>
    public static class Function
    {
        public static string Lab_1(int a, int b)
        {
            int sum = 0;
            int max = Math.Max(a, b);
            int min = Math.Max(0, Math.Min(a, b));

            for (int i = min; i <= max; i += 4)
            {
                sum += i;
            }

            return sum.ToString();
        }

        public static string Lab_2(int[] mas)
        {
            int sum = 0;
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
