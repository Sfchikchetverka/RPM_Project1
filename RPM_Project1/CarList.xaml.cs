using System;
using System.Windows;
using System.Windows.Media.Imaging;
namespace RPM_Project1
{
    public partial class CarList : Window
    {
        public CarList()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
            CarAdd carAdd = new CarAdd();
           
            carAdd.ShowDialog();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                foreach (Car car in db.Cars)
                {
                        CarsRedact carsRedact = new CarsRedact();
                        carsRedact.Id.Text = car.Id.ToString();
                        carsRedact.TextBox.Text = car.Model;
                        carsRedact.Image.Source = new BitmapImage(new Uri(car.Photo, UriKind.RelativeOrAbsolute));
                        List.Children.Add(carsRedact);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string src = Search.Text;
            if(Search.Text == "") {
                MessageBox.Show("Введите запрос!");
            }
            else
            {
                CarSearch carSearch = new CarSearch(src);
                this.Hide();
                carSearch.ShowDialog();
                this.Close();
            }
        }
    }
}
