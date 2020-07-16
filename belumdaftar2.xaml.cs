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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace WPF6
{
    /// <summary>
    /// Interaction logic for belumdaftar2.xaml
    /// </summary>
    public partial class belumdaftar2 : Window
    {
        public belumdaftar2()
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
        private void Belumregis_Loaded(object sender, RoutedEventArgs e)
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

        //Program sistem Registrasi 
        private void Btndaftar_Click(object sender, RoutedEventArgs e)
        {
            #region                 
            if(txtusername.Text != "")
            {
                if(txtemail.Text != "")
                {
                    if(txtnotelepon.Text != "")
                    {
                        if (txtpassword.Password != "")
                        {
                            Data user = new Data()
                            {
                                Username = txtusername.Text,
                                Email = txtemail.Text,
                                NoTelepon = txtnotelepon.Text,
                                Password = txtpassword.Password
                            };
                            SetResponse set = client.Set(@"Data/" + txtusername.Text, user);

                            MsgError("akun anda telah terdaftar");                            
                        }
                        else MsgError("Lengkapi forms pendaftaran anda");                        
                    }
                    else MsgError("Lengkapi forms pendaftaran anda");
                }
                else MsgError("Lengkapi forms pendaftaran anda");
            }
            #endregion
        }

        //Program untuk kembali ke halaman sebelumnya
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
        }

       
    }
}
