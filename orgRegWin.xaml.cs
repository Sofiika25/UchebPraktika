using System.Windows;

namespace UchebPraktika
{
    /// <summary>
    /// Логика взаимодействия для orgRegWin.xaml
    /// </summary>
    /// 
    public partial class orgRegWin : Window
    {
        private Polzovateli currentUser;

        public orgRegWin()
        {
            InitializeComponent();
        }
        public void NavigateOrgWIn()
        {
            OrganizatorWindow organizatorWindow = new OrganizatorWindow(currentUser);
            organizatorWindow.Show();
            this.Close();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigateOrgWIn();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigateOrgWIn();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateOrgWIn();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            MessageBox.Show("Вы вышли из аккаунта");
            this.Close();
        }
    }
}
