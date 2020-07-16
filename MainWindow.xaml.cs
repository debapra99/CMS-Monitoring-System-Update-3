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

//Library Firebase untuk C# Language (dinamakan Firesharp)
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace WPF6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // Konfigurasi awal Firesharp
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "OMVEAkainCWyOtukgBgmsCLDy42Wxglh16GbBMlS",
            BasePath = "https://wpfloginregislupapassword.firebaseio.com/"
        };
        IFirebaseClient client;
        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Tolong cek kembali koneksi internet anda");
            }
        }
        private void MsgError(string msg)
        {
            labelnotifikasi.Content = "" + msg;
            labelnotifikasi.Visibility = Visibility;
        }
        
        //Porgram Sistem Login
        private void Btnmasuk_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data()
            {
                Username = txtusername.Text,
                Password = txtpassword.Password
            };
            FirebaseResponse res = client.Get(@"Data/" + txtusername.Text);
            Data Reuser = res.ResultAs<Data>();

            if (Data.IsEqual(Reuser,data))
            {
                this.Hide();
                Halaman_home mainForm = new Halaman_home();
                mainForm.Show();
            }
            else
            {
                MsgError("Username atau Password anda tidak benar");
            }           
        }
        //Program button untuk ke halaman "Belum Daftar"
        private void Btndaftar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            belumdaftar2 mainForm = new belumdaftar2();
            mainForm.Show();
        }

        //Program button untuk ke halaman "Lupa Password"
        private void Btnlupapassword_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            lupapassword mainForm = new lupapassword();
            mainForm.Show();
        }
    }
}
