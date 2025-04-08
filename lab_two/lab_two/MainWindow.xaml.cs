using System;
using System.Windows;
using System.Windows.Input;

namespace FortuneTeller
{
    public partial class MainWindow : Window
    {
        // Define a custom command for getting the answer.
        public static RoutedCommand GetAnswerCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
            // Bind the custom command to its execution method.
            CommandBindings.Add(new CommandBinding(GetAnswerCommand, ExecuteGetAnswerCommand));
        }

        private void ExecuteGetAnswerCommand(object sender, ExecutedRoutedEventArgs e)
        {
            // Check if a question has been entered.
            if (string.IsNullOrWhiteSpace(QuestionTextBox.Text))
            {
                AnswerLabel.Content = "Будь ласка, введіть питання.";
                return;
            }

            // Define possible answers.
            string[] answers = { "Так", "Ні", "Скоріше так", "Скоріше ні" };

            // Use Random to select an answer.
            Random rnd = new Random();
            int index = rnd.Next(answers.Length);
            AnswerLabel.Content = answers[index];
        }
    }
}
