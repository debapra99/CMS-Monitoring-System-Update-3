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

namespace WPF6
{
    /// <summary>
    /// Interaction logic for Halaman_home.xaml
    /// </summary>
    public partial class Halaman_home : Window
    {
        public Halaman_home()
        {
            InitializeComponent();
        }

        private void Btnbackkelogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
        }

        private void Btnkeluar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
        }
    }
}
