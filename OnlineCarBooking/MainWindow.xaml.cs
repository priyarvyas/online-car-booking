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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineCarBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listTime = new List<string>() { "10AM", "11AM", "12AM", "1PM", "2PM", "3PM", "4PM", "5PM", "6PM" };
        List<string> listSeatNo = new List<string>() { "2", "4", "5", "7","8" };
        List<string> listSearch = new List<string>() { "", "4", "5", "6" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmbPickupTime_Loaded(object sender, RoutedEventArgs e)
        {    
            var cmbPickTime = sender as ComboBox;
            cmbPickTime.ItemsSource = listTime;
            cmbPickTime.SelectedIndex = 0;
        }

        private void cmbDropOffTime_Loaded(object sender, RoutedEventArgs e)
        {
            var cmbDropTime = sender as ComboBox;
            cmbDropTime.ItemsSource = listTime;
            cmbDropTime.SelectedIndex = 0;
        }

        private void cmbSeatNo_Loaded(object sender, RoutedEventArgs e)
        {    
            var cmbSeatNo = sender as ComboBox;
            cmbSeatNo.ItemsSource = listSeatNo;
            cmbSeatNo.SelectedIndex = 0;
        }

        

    }
}
