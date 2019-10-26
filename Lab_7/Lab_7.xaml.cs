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

namespace WpfApp_Labs.Lab_7
{
    /// <summary>
    /// Логика взаимодействия для Lab_7.xaml
    /// </summary>
    public partial class Lab_7 : Window
    {
        public Lab_7()
        {
            InitializeComponent();
        }

        TextBox[,] textBoxes;
        List<List<string>> list;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dialog_Window window = new Dialog_Window();
            if (window.ShowDialog() == true)
            {
                //Парсинг строк файла в List
                list = new List<List<string>>();
                StreamReader reader = new StreamReader("students.txt");
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    List<string> temp = str.Trim().Split('"').ToList();
                    temp.RemoveAll(stroka => stroka.Trim() == "");
                    list.Add(temp);
                }
                reader.Close();

                for (int i = 1; i <= list.Count; i++)
                {
                    // каждую итерацию указываю на новый конструктор, ибо при попытка впихнуть один элемент не может быть в разных частях окна WPF
                    if (Stud_Grid.RowDefinitions.Count <= list.Count)
                    {
                        RowDefinition rowDefinition = new RowDefinition();
                        Stud_Grid.RowDefinitions.Add(rowDefinition);
                    }
                    if (Stud_Grid.ColumnDefinitions.Count < list.Count)
                    {
                        ColumnDefinition columnDefinition = new ColumnDefinition();
                        Stud_Grid.ColumnDefinitions.Add(columnDefinition);
                    }
                }

                textBoxes = new TextBox[list.Count, 5];



                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        string temp = list[i][j];
                        textBoxes[i, j] = new TextBox();
                        textBoxes[i, j].Text = temp;
                        textBoxes[i, j].Background = Brushes.AntiqueWhite;
                        Stud_Grid.Children.Add(textBoxes[i, j]);
                        Grid.SetRow(textBoxes[i, j], i + 1);
                        Grid.SetColumn(textBoxes[i, j], j);
                    }
                }
                this.SizeToContent = SizeToContent.WidthAndHeight;


                MessageBox.Show("Успешная чтение из\n" + Environment.CurrentDirectory + "\\sutents.txt");
            }
            else
            {
                MessageBox.Show("Ну как хотите");
            }
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxes == null)
            {
                Label_Debug.Content = "Нечего сохранять";
            }
            else
            {
                StreamWriter writer = new StreamWriter("students.txt", false);
                for (int i = 0; i < list.Count; i++)
                {
                    string line = null;
                    for (int j = 0; j < 5; j++)
                    {
                        line += $"\"{textBoxes[i, j].Text}\" ";
                    }
                    writer.WriteLine(line);
                }

                writer.Close();
                Label_Debug.Content = "Сохранение прошло успешно";
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
