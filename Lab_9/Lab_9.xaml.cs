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
        List<StackPanel> comboBoxItems = new List<StackPanel>();
        List<Image> show_images = new List<Image>();
        public Lab_9()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            show_images.Clear();
            Dialog_Window dialog = new Dialog_Window();
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.TextBox_Path.Text;
                MessageBox.Show("Корректный путь");
                string[] images = Directory.GetFiles(path, "*jpg", SearchOption.TopDirectoryOnly);
                foreach (var image in images)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = image.Substring(image.LastIndexOf('\\') + 1);
                    Image temp_image = new Image();
                    temp_image.Source = new BitmapImage(new Uri(image));
                    show_images.Add(temp_image);
                    temp_image.Width = 60;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Children.Add(temp_image);
                    stackPanel.Children.Add(textBlock);

                    comboBoxItems.Add(stackPanel);
                }
                ComboBox_Images.ItemsSource = comboBoxItems;

            }
            else
            {
                MessageBox.Show("Неверный путь");
            }
        }

        private void ComboBox_Images_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Image.Source = show_images[comboBox.SelectedIndex].Source;
        }
    }
}
