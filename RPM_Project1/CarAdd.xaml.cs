using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RPM_Project1
{
    public partial class CarAdd : Window
    {
        private readonly OpenFileDialog opf = new OpenFileDialog();
        
        private string path = "";
        public CarAdd()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Model.MaxLength = 20;
            Cost.MaxLength= 10;
            Description.MaxLength= 100;
            Year.MaxLength= 4;
            Charact.MaxLength= 50;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string mdl = Model.Text;
                decimal cst = Convert.ToDecimal(Cost.Text);
                string desc = Description.Text;
                int yr = Convert.ToInt32(Year.Text);
                string chr = Charact.Text;
                if (yr<1950 || yr>DateTime.Today.Year)
                {
                    throw new Exception("Неверный год!");
                }
                if (path=="")
                {
                    throw new Exception("Добавьте фото!");
                }
                if (Model.Text[0].ToString() == " " ||Cost.Text[0].ToString() == " " ||Year.Text[0].ToString() == " " ||Charact.Text[0].ToString() == " " ||Description.Text[0].ToString() == " ")
                {
                    MessageBox.Show("Пожалуйсте уберите пробелы в начале строк!");
                }
                if (Model.Text == "" ||Year.Text == "" ||Cost.Text == "" ||Charact.Text == "" ||Description.Text == "")
                {
                    MessageBox.Show("Пожалуйста заполните пустые строки");
                }
                
                using (AppContext db = new AppContext())
                {
                    foreach(Car car in db.Cars)
                    {
                        if(car.Model == mdl) 
                        {
                            throw new Exception("Такая машина уже есть!");
                        }
                    }
                    if (Cost.Text=="")
                    {
                        throw new Exception("Введите цену!");
                    }
                    if (cst<=0)
                    {
                        throw new Exception("Неверная цена!");
                    }

                    if(mdl == "")
                    {
                        throw new Exception("Введите навзание модели!");
                    }
                    Car car1 = new Car(mdl,cst,yr,desc,chr,path);
                    db.Cars.Add(car1);
                    db.SaveChanges();
                    MessageBox.Show("Машина успешно добавлена!");
                    this.Close();
                    CarList carList = new CarList();
                 
                    carList.ShowDialog();
                    
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            opf.Filter = "Image Files|*.jpg; *.jpeg; *.png;";
            if (opf.ShowDialog() == false)
            {
                return;
            }
            path = opf.FileName;
            Image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));

        }
        
    }
}
