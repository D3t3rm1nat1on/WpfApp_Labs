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
            string path = TextBox_Path.Text.Trim().TrimEnd('\\');

            // Очистка таблицы
            Grid_Directory.Children.Clear();
            Grid_Directory.RowDefinitions.Clear();

            if (Directory.Exists(path))
            {
                // Индекс для размещения элементов в нужной строке
                int idx = 0;
                // Показываем путь, который ввел пользователь
                Label.Content = path;
                // Переменная хранящая информацию о директории (включая папки и файлы)
                DirectoryInfo info = new DirectoryInfo(path);

                // Разделитель таблицы для вложенных папок
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Вложенные папки";
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Background = Brushes.AntiqueWhite;

                Grid_Directory.RowDefinitions.Add(new RowDefinition());
                Grid_Directory.Children.Add(textBlock);
                Grid.SetRow(textBlock, idx++);

                // Добавление в таблицу названий вложенных папок
                foreach (var item in info.GetDirectories())
                {
                    // Создание новой строки в таблице
                    Grid_Directory.RowDefinitions.Add(new RowDefinition());
                    TextBlock dir_textBlock = new TextBlock();
                    dir_textBlock.Text = item.Name;
                    dir_textBlock.TextAlignment = TextAlignment.Center;
                    dir_textBlock.Background = Brushes.Beige;
                    Grid_Directory.Children.Add(dir_textBlock);
                    Grid.SetRow(dir_textBlock, idx++);
                }

                // Разделитель таблицы для вложенных файлов
                textBlock = new TextBlock();
                textBlock.Text = "Вложенные файлы";
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Background = Brushes.AntiqueWhite;

                Grid_Directory.RowDefinitions.Add(new RowDefinition());
                Grid_Directory.Children.Add(textBlock);
                Grid.SetRow(textBlock, idx++);

                // Добавление в таблицу названий вложенных файлов
                foreach (var item in info.GetFiles())
                {
                    // Создание новой строки в таблице
                    Grid_Directory.RowDefinitions.Add(new RowDefinition());
                    TextBlock file_textBlock = new TextBlock();
                    file_textBlock.Text = item.Name;
                    file_textBlock.TextAlignment = TextAlignment.Center;
                    file_textBlock.Background = Brushes.Beige;
                    Grid_Directory.Children.Add(file_textBlock);
                    Grid.SetRow(file_textBlock, idx++);
                }

                // Делает видимой таблицу с действиями (удаление, создание)
                Grid_Actions.Visibility = Visibility.Visible;
            }
            else
            {
                Label.Content = "Ошибка ввода";
                Grid_Actions.Visibility = Visibility.Collapsed;
            }
            // Подстраивает размер окна под содержимое
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        // Удаляет папку или файл, в зависимости от введенного имени
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            // Функция содержит в себе проверку на удаление папки или файла (это важно)
            string path = $"{Label.Content}\\{TextBox_Delete.Text.Trim()}";
            if (Directory.Exists(path))
                Directory.Delete(path);
            else
                if (File.Exists(path))
            {
                File.Delete(path);
                MessageBox.Show($"Успешное удаление {TextBox_Delete.Text.Trim()}");
            }
            else
                MessageBox.Show("Такой папки/файла не существует");
            Button_Click(sender, e);
        }

        // Добавляет файл с указанным именем (если такого файла еще нет)
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

        // Добавляет директорию с указанным именем (если такой директории еще нет)
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
