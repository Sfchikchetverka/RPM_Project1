using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    public partial class InfRedaction : Window
    {
        private readonly OpenFileDialog opf = new OpenFileDialog();

        private string path = "";
        private int Id;
        public InfRedaction(int id)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Model.MaxLength = 20;
            Cost.MaxLength= 10;
            Desc.MaxLength= 100;
            Year.MaxLength= 4;
            Char.MaxLength= 50;
            Id= id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            opf.Filter = "Image Files|*.jpg; *.jpeg; *.png;";
            if (opf.ShowDialog() == false)
            {
                return;
            }
            path = opf.FileName;
            Image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string mdl = Model.Text;
                decimal cst = Convert.ToDecimal(Cost.Text);
                string desc = Desc.Text;
                int yr = Convert.ToInt32(Year.Text);
                string chr = Char.Text;
                if (yr<1950 || yr>DateTime.Today.Year)
                {
                    throw new Exception("Неверный год!");
                }
                if (path=="")
                {
                    throw new Exception("Добавьте фото!");
                }
                if (Model.Text[0].ToString() == " " ||Cost.Text[0].ToString() == " " ||Year.Text[0].ToString() == " " ||Char.Text[0].ToString() == " " ||Desc.Text[0].ToString() == " ")
                {
                    MessageBox.Show("Пожалуйсте уберите пробелы в начале строк!");
                }
                if (Model.Text == "" ||Year.Text == "" ||Cost.Text == "" ||Char.Text == "" ||Desc.Text == "")
                {
                    MessageBox.Show("Пожалуйста заполните пустые строки");
                }

                using (AppContext db = new AppContext())
                {
                    foreach (Car car in db.Cars)
                    {
                        if (car.Model == mdl)
                        {
                            throw new Exception("Это название уже занято!");
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

                    if (mdl == "")
                    {
                        throw new Exception("Введите навзание модели!");
                    }
                    foreach(Car car in db.Cars)
                    {
                        if(car.Id == Id)
                        {
                            car.Model = mdl;
                            car.Cost = cst;
                            car.Description = desc;
                            car.Characteristics = chr;
                            car.Year = yr;
                            car.Photo = path;


                        }
                    }
                    db.SaveChanges();
                    MessageBox.Show("Машина успешно обновлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                foreach (Car car in db.Cars)
                {
                    if (car.Id == Id)
                    {
                        Model.Text = car.Model;
                        Cost.Text = car.Cost.ToString();
                        Desc.Text = car.Description;
                        Year.Text = car.Year.ToString();
                        Image.Source = new BitmapImage(new Uri(car.Photo,UriKind.RelativeOrAbsolute));
                        Char.Text = car.Characteristics;


                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
