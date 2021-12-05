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
using SAP.Middleware.Connector;

namespace Watering_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            ECCDestinationConfig cfg = new ECCDestinationConfig();
            RfcDestinationManager.RegisterDestinationConfiguration(cfg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction testfn = repo.CreateFunction("ZGET_USER");
                testfn.SetValue("IV_USER", txt_usnam.Text);
                testfn.SetValue("IV_PASSWORD", txt_pw.Password);
                testfn.Invoke(dest);
                char status = testfn.GetChar("EX_STAT");
                string level = testfn.GetString("EX_LVL");
                string username = testfn.GetString("EX_NAME");
                if (status == '1')
                {
                    Main_Window mw = new Main_Window(int.Parse(level), username);
                    mw.Show();
                    this.Close();
                }
                else
                {
                    txtbl_ststus.Text = "Invalid User Name Or Password";
                }
            }
            catch (Exception)
            {

                txtbl_ststus.Text = "SAP System Not Connected";
            }

        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_1(sender, e);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}