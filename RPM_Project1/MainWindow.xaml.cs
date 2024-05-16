using System.Windows;
namespace RPM_Project1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                foreach (Admin admin in db.Admins)
                {
                    if (Login.Text == admin.Login && Password.Password == admin.Password)
                    {
                        MessageBox.Show("Добро пожаловать");
                        CarList carList = new CarList();
                        this.Hide();
                        carList.ShowDialog();
                        this.Close();
                        return;
                    }
                }
                MessageBox.Show("Логин или пароль указан неверно!");
            }

        }
    }
}
