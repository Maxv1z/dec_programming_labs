using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_two
{
    public partial class MainWindow : Window
    {
        public static RoutedCommand ClearCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            // Register command bindings
            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Save,
                SaveCommand_Execute,
                SaveCommand_CanExecute));

            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Open,
                OpenCommand_Execute,
                OpenCommand_CanExecute));

            CommandBindings.Add(new CommandBinding(
                ClearCommand,
                ClearCommand_Execute,
                ClearCommand_CanExecute));

            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Paste, 
                Paste_Execute, 
                Paste_CanExecute));
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(textBox.Text);
        }

        private void SaveCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            // Implement save functionality
            MessageBox.Show("Text saved!");
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            // Implement open functionality
            MessageBox.Show("Open file dialog!");
        }

        private void ClearCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(textBox.Text);
        }

        private void ClearCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void Paste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void Paste_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            textBox.Paste();
        }
    }
}