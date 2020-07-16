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

//Library Firebase untuk C# Language (dinamakan Firesharp)
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Extensions;
using FireSharp.Response;

namespace WPF6
{
    /// <summary>
    /// Interaction logic for lupapassword.xaml
    /// </summary>
    public partial class lupapassword : Window
    {
        public lupapassword()
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
        private void Lupapassword_loaded (object sender, RoutedEventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Check kembali koneksi internet anda");
            }
        }
        private void MsgError (string msg)
        {
            labelnotifikasi.Content = "" + msg;
            labelnotifikasi.Visibility = Visibility;
        }
        private void MsgBerhasil (string msg)
        {
            labelberhasil.Content = "" + msg;
            labelberhasil.Visibility = Visibility;
        }
        //Program Sistem Lupa Password
        private void Btngantipassword_Click(object sender, RoutedEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Data/" + txtusername.Text);
            MyLupaPassword Reuser = res.ResultAs<MyLupaPassword>();

            MyLupaPassword Lupa = new MyLupaPassword()
            {
                Username = txtusername.Text,
                Email = txtemail.Text,
                NoTelepon = txtnotelepon.Text,
                Password = txtpassword.Password
            };
            if (MyLupaPassword.IsEqual(Reuser, Lupa))
            {
                MyLupaPassword user = new MyLupaPassword()
                {
                    Username = txtusername.Text,
                    Email = txtemail.Text,
                    NoTelepon = txtnotelepon.Text,
                    Password = txtpassword.Password
                };
                FirebaseResponse response = client.Update(@"Data/" + txtusername.Text, user);
                
                MsgError("Password anda telah diganti yang baru");                
            }
            else
            {
                
                MsgError("Check kembali akun anda");
            }               
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
        }
    }
}
