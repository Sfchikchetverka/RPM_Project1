using System;
using System.Collections.Generic;
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

namespace RPM_Project1
{
    public partial class CarSearch : Window
    {
        private string src;
        public CarSearch(string src)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.src=src;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CarList carList = new CarList();
            carList.ShowDialog();
            this.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                foreach (Car car in db.Cars)
                {
                    if (car.Model == src)
                    {
                        CarsRedact carsRedact = new CarsRedact();
                        carsRedact.Id.Text = car.Id.ToString();
                        carsRedact.TextBox.Text = car.Model;
                        carsRedact.Image.Source = new BitmapImage(new Uri(car.Photo, UriKind.RelativeOrAbsolute));
                        List.Children.Add(carsRedact);
                    }
                }
            }

        }
    }
}
