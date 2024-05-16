using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace RPM_Project1
{
    public partial class CarRedaction : Window
    {
        int i;
        public CarRedaction(int i)
        {
            InitializeComponent();
       
            this.i=i;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                foreach (Car car in db.Cars)
                {
                    if (car.Id==i)
                    {
                       Image.Source = new BitmapImage(new Uri(car.Photo,UriKind.RelativeOrAbsolute));
                        Model.Text = car.Model;
                        Year.Text = car.Year.ToString();
                        Desc.Text = car.Description;
                        Char.Text = car.Characteristics;
                        Cost.Text = car.Cost.ToString();
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(AppContext db = new AppContext())
            {
                foreach (Car car in db.Cars) { if (car.Id==i)
                    {
                        db.Cars.Remove(car);
                        break;
                    }
                }
                db.SaveChanges();

            }
            CarList carList = new CarList();
            this.Hide();
            carList.ShowDialog();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InfRedaction infRedaction = new InfRedaction(i);
            this.Hide();
            infRedaction.ShowDialog();
            this.Close();
        }
    }
}
