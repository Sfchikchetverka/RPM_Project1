using System;
using System.Windows;
using System.Windows.Controls;

namespace RPM_Project1
{
    public partial class CarsRedact : UserControl
    {
       
        public CarsRedact()
        {
            InitializeComponent();

            Id.Visibility= Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(Id.Text);
            CarList carList = new CarList();
            carList.Hide();
            CarRedaction carRedaction = new CarRedaction(id);
            carRedaction.ShowDialog();
            carList.Close();
        }
    }
}
