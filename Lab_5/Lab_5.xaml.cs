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

namespace WpfApp_Labs.Lab_5
{
    /// <summary>
    /// Логика взаимодействия для Lab_5.xaml
    /// </summary>
    public partial class Lab_5 : Window
    {
        public Lab_5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int[] array = Function.Lab_5().Trim().Split().Select(int.Parse).ToArray();
            int square = (int)Math.Ceiling(Math.Sqrt(array.Length));

            for (int i = 0; i < square; i++)
            {
                // каждую итерацию указываю на новый конструктор, ибо при попытка впихнуть один элемент не может быть в разных частях окна WPF
                if (ResultGrid.RowDefinitions.Count < square)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    ResultGrid.RowDefinitions.Add(rowDefinition);
                }
                if (ResultGrid.ColumnDefinitions.Count < square)
                {
                    ColumnDefinition columnDefinition = new ColumnDefinition();
                    ResultGrid.ColumnDefinitions.Add(columnDefinition);
                }
            }

            int counter = 0;
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    if (counter < array.Length)
                    {
                        Label label = new Label();
                        label.Content = array[counter++];
                        label.HorizontalContentAlignment = HorizontalAlignment.Center;
                        ResultGrid.Children.Add(label);
                        Grid.SetRow(label, i);
                        Grid.SetColumn(label, j);

                    }
                }
            }


        }
    }
}
