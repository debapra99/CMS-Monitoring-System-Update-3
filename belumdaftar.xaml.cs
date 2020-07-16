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
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace WPF6
{
    /// <summary>
    /// Interaction logic for belumdaftar.xaml
    /// </summary>
    public partial class Belumdaftar : Window
    {
        public Belumdaftar()
        {

        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "OMVEAkainCWyOtukgBgmsCLDy42Wxglh16GbBMlS",
            BasePath = "https://wpfloginregislupapassword.firebaseio.com/"
        };
        IFirebaseClient client;
        private void Belumdaftar1(object sender, EventArgs e)
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






    }
}
