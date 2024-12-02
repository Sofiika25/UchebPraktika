using System.Windows;

namespace UchebPraktika
{
    /// <summary>
    /// Логика взаимодействия для ZhuriWindow.xaml
    /// </summary>
    public partial class ZhuriWindow : Window
    {
        public ZhuriWindow()
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
