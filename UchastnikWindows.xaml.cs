using System.Windows;

namespace UchebPraktika
{
    /// <summary>
    /// Логика взаимодействия для UchastnikWindows.xaml
    /// </summary>
    public partial class UchastnikWindows : Window
    {
        public UchastnikWindows()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            MessageBox.Show("Вы вышли из аккаунта");
        }
    }
}
