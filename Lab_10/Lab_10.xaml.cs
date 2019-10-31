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

namespace WpfApp_Labs.Lab_10
{
    /// <summary>
    /// Логика взаимодействия для Lab_10.xaml
    /// </summary>
    public partial class Lab_10 : Window
    {
        public Lab_10()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = TextBox_Path.Text.Trim().Trim('\\');
            Grid_Directory.Children.Clear();                                    // ради удаления последнего элемента
            Grid_Directory.RowDefinitions.Clear();
            if (Directory.Exists(path))
            {
                int idx = 0;
                Label.Content = path;
                DirectoryInfo info = new DirectoryInfo(path);

                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Вложенные папки";
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Background = Brushes.AntiqueWhite;

                Grid_Directory.RowDefinitions.Add(new RowDefinition());
                Grid_Directory.Children.Add(textBlock);
                Grid.SetRow(textBlock, idx++);

                foreach (var item in info.GetDirectories())
                {
                    Grid_Directory.RowDefinitions.Add(new RowDefinition());
                    TextBlock file_textBlock = new TextBlock();
                    file_textBlock.Text = item.Name;
                    file_textBlock.TextAlignment = TextAlignment.Center;
                    file_textBlock.Background = Brushes.Beige;
                    Grid_Directory.Children.Add(file_textBlock);
                    Grid.SetRow(file_textBlock, idx++);
                }

                textBlock = new TextBlock();
                textBlock.Text = "Вложенные файлы";
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Background = Brushes.AntiqueWhite;

                Grid_Directory.RowDefinitions.Add(new RowDefinition());
                Grid_Directory.Children.Add(textBlock);
                Grid.SetRow(textBlock, idx++);

                foreach (var item in info.GetFiles())
                {
                    Grid_Directory.RowDefinitions.Add(new RowDefinition());
                    TextBlock file_textBlock = new TextBlock();
                    file_textBlock.Text = item.Name;
                    file_textBlock.TextAlignment = TextAlignment.Center;
                    file_textBlock.Background = Brushes.Beige;
                    Grid_Directory.Children.Add(file_textBlock);
                    Grid.SetRow(file_textBlock, idx++);
                }

                Grid_Actions.Visibility = Visibility.Visible;
            }
            else
            {
                Label.Content = "Ошибка ввода";
                Grid_Actions.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            string path = $"{Label.Content}\\{TextBox_Delete.Text.Trim()}";
            if (Directory.Exists(path))
                Directory.Delete(path);
            else
                if (File.Exists(path))
                File.Delete(path);
            else
                MessageBox.Show("Такой папки/файла не существует");

            MessageBox.Show($"Успешное удаление {TextBox_Delete.Text.Trim()}");
            Button_Click(sender, e);
        }

        private void Button_AddFile_Click(object sender, RoutedEventArgs e)
        {
            string path = $"{Label.Content}\\{TextBox_AddFile.Text.Trim()}";
            if (File.Exists(path))
            {
                MessageBox.Show("Файл с таким именем уже существует");
            }
            else
            {
                File.Create(path);
                MessageBox.Show("Файл успешно создан");
            }
            Button_Click(sender, e);
        }

        private void Button_AddDirectory_Click(object sender, RoutedEventArgs e)
        {
            string path = $"{Label.Content}\\{TextBox_AddDirectory.Text.Trim()}";
            if (Directory.Exists(path))
            {
                MessageBox.Show("Директория с таким именем существует");
            }
            else
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Директория успешно создана");
            }
            Button_Click(sender, e);
        }
    }
}
