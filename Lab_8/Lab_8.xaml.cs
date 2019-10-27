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

namespace WpfApp_Labs.Lab_8
{
    /// <summary>
    /// Логика взаимодействия для Lab_8.xaml
    /// </summary>
    public partial class Lab_8 : Window
    {
        List<string> questions = new List<string>();
        List<List<string>> answers = new List<List<string>>();
        List<string> random_questions = new List<string>();
        List<List<string>> random_answers = new List<List<string>>();
        int score = 0;
        public Lab_8()
        {
            InitializeComponent();
            // Чтение вопросов и ответов из файлов
            StreamReader q_reader = new StreamReader("Вопросы.txt");
            StreamReader a_reader = new StreamReader("Ответы.txt");
            for (int i = 0; i < 15; i++)
            {
                questions.Add(q_reader.ReadLine().Trim().Trim('"'));
                List<string> temp = a_reader.ReadLine().Trim().Split('"').ToList(); ;
                temp.RemoveAll(stroka => stroka.Trim() == "");
                answers.Add(temp);
            }

            Randomly_Sort();

        }

        /// <summary>
        /// Случайное перемешивание порядка вопросов
        /// </summary>
        private void Randomly_Sort()
        {
            random_answers.Clear();
            random_questions.Clear();
            var random = new Random();
            var range = Enumerable.Range(1, 15);
            range = range.OrderBy(k => random.Next());
            foreach (var item in range.ToList())
            {
                random_questions.Add(questions[item-1]);
                random_answers.Add(answers[item-1]);
            }
        }
       
        /// <summary>
        /// Обновляет текущий вопрос
        /// </summary>
        private void Get_Question()
        {
            if (score == 15)
            {
                Label_Score.Content = "Победа!";
                score = 0;
            }
            else
            {
                Label_Score.Content = $"Текущий счет: {score}";
            }
            TextBlock.Text = random_questions[score];

            // Ставим варианты ответа в случайном порядке
            var random = new Random();
            var range = Enumerable.Range(0, 4);
            int[] index = range.OrderBy(k => random.Next()).ToArray();
            Button1.Content = random_answers[score][index[0]];
            Button2.Content = random_answers[score][index[1]];
            Button3.Content = random_answers[score][index[2]];
            Button4.Content = random_answers[score][index[3]];

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (e.Source as Button).Content.ToString();
            if (name.Equals(random_answers[score][0]))
            {
                score++;
            }
            else
            {
                score = 0;
                Randomly_Sort();
            }
            Get_Question();
        }
    }
}
