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
        
        // Массив текстбоксов, которые будут вставляться в таблицу (создаем его вне функций для возможности обращения к нему из них)
        TextBox[,] textBoxes;
        // Массив полей, считанных из файла
        List<List<string>> list;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Очистка таблицы от полей со студентами (название столбцов не трогаем)
            if (Stud_Grid.RowDefinitions.Count > 1)
            {
                // Первые пять Children'ов это названия столбцов, созданных в конструкторе WPF, их трогать не нужно
                Stud_Grid.Children.RemoveRange(5, Stud_Grid.Children.Count - 5);
                // Удаляем все строки кроме 1й, поэтому не Clear()
                Stud_Grid.RowDefinitions.RemoveRange(1, Stud_Grid.RowDefinitions.Count - 1);
            }

            // Вызов диалога подтверждения считывания карточек студентов из файла
            Dialog_Window window = new Dialog_Window();
            if (window.ShowDialog() == true)
            {
                // присваеваем переменной list конструктор (т.к. до этого list == null)
                list = new List<List<string>>();
                StreamReader reader = new StreamReader("students.txt");
                string str;
                // Записываем каждую не пустую карточку (строку)
                while ((str = reader.ReadLine()) != null)
                {
                    // Специфичный парсинг строки. Split('"') и RemoveAll потому, что каждая запись хранится внутри ковычек ==> "Имя" "Пол" и т.д.
                    List<string> temp = str.Trim().Split('"').ToList();
                    temp.RemoveAll(stroka => stroka.Trim() == "");
                    list.Add(temp);
                }
                reader.Close();

                // Создание таблицы (пока пустой)
                for (int i = 1; i <= list.Count; i++)
                {
                    // каждую итерацию указываю на новый конструктор, ибо при попытке впихнуть один элемент не может быть в разных частях окна WPF
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
                
                // Задаем необходимое количество textBox'ов
                textBoxes = new TextBox[list.Count, 5];

                // Запись результата в таблицу
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

                MessageBox.Show("Успешная чтение из\n" + Environment.CurrentDirectory + "\\sutents.txt");
            }
            else
            {
                MessageBox.Show("Ну как хотите");
            }

            // После изменения размера внутренних элементов, размеры окна подстроятся
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем есть ли что сохранять
            if (textBoxes == null)
            {
                MessageBox.Show("Нечего сохранять");
            }
            else
            {
                StreamWriter writer = new StreamWriter("students.txt", false); // false для перезаписи файла
                for (int i = 0; i < list.Count; i++)
                {
                    string line = null;
                    // Запись в формате "фио" "возраст" "пол" "специальность" "курс"
                    for (int j = 0; j < 5; j++)
                    {
                        line += $"\"{textBoxes[i, j].Text}\" ";
                    }
                    writer.WriteLine(line);
                }

                writer.Close();
                MessageBox.Show("Сохранение прошло успешно");
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // По закрытию формы запрашиваем у пользователя подтверждение
            // 1) Текст в окне   2 )Название окна   3) Кнопки "Да" и "Нет"
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "Закрытие формы", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
