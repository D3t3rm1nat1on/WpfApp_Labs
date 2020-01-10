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
    /// Логика взаимодействия для Lab_9.xaml
    /// </summary>
    public partial class Lab_9 : Window
    {
        // Массив панелей, которые будет содержать ComboBox
        List<StackPanel> list_StackPanels = new List<StackPanel>();
        // Дополнительный повторяющийся массив картинок, т.к. из StackPanel вытащить картинку не получится
        List<Image> list_images = new List<Image>();

        public Lab_9()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dialog_Window dialog = new Dialog_Window();
            if (dialog.ShowDialog() == true)
            {
                list_images.Clear();
                ComboBox.ItemsSource = null;

                MessageBox.Show("Корректный путь");

                // Очистка заполняемых полей
                list_StackPanels.Clear();
                list_images.Clear();
                Image.Source = null;
                ComboBox.ItemsSource = null;
                ComboBox.Items.Clear();

                string path = dialog.TextBox_Path.Text;
                
                // Добавляем путь к каждой картинке в массив
                List<string> images_paths = Directory.GetFiles(path, "*jpg", SearchOption.TopDirectoryOnly).ToList();
                images_paths.AddRange(Directory.GetFiles(path, "*jpeg", SearchOption.TopDirectoryOnly).ToList());
                images_paths.AddRange(Directory.GetFiles(path, "*gif", SearchOption.TopDirectoryOnly).ToList());
                images_paths.AddRange(Directory.GetFiles(path, "*png", SearchOption.TopDirectoryOnly).ToList());

                // Обрабатываю каждую картинку
                foreach (var image_path in images_paths)
                {
                    // TextBlock нужен для отображения названия изображения
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = image_path.Substring(image_path.LastIndexOf('\\') + 1);

                    Image temp_image = new Image();
                    // Получение ресурса изображений (самой картинки для элемента Image)
                    temp_image.Source = new BitmapImage(new Uri(image_path));
                    list_images.Add(temp_image);
                    // Установка маленькой ширины картинки (для нормального отображения в ComboBox'е)
                    temp_image.Width = 60;

                    // Добавление изображения с его названием в панель
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Children.Add(temp_image);
                    stackPanel.Children.Add(textBlock);
                    list_StackPanels.Add(stackPanel);
                }

                // Используем список с панелями как элементы ComboBox'а
                ComboBox.ItemsSource = list_StackPanels;
            }
            else
            {
                MessageBox.Show("Неверный путь");
            }

            // Подстройка размеров окна под содержимое
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // При выборе картинки в ComboBox'е она отобразится на форме
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex > -1)
                Image.Source = list_images[comboBox.SelectedIndex].Source;

        }
    }
}
