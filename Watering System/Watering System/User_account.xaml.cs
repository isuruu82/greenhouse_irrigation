using SAP.Middleware.Connector;
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

namespace Watering_System
{
    /// <summary>
    /// Interaction logic for User_account.xaml
    /// </summary>
    public partial class User_account : Window
    {
        string name;
        public User_account(string user_name)
        {
            InitializeComponent();
            name = user_name;
            Loaded += User_account_Loaded;
        }

        private void User_account_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_acc = repo.CreateFunction("ZGET_ACOUNT");
                fn_acc.SetValue("IM_USER_NAME", name);
                fn_acc.Invoke(dest);
                var status = fn_acc.GetStructure("EX_USR");

                txt_usrid.Text = status.GetString("USERNAME");
                txt_name.Text = status.GetString("NAME");
                txt_email.Text = status.GetString("EMAIL");
                txt_level.Text = status.GetString("USER_LEVEL");
                txt_log.Text = status.GetString("LAST_LOGIN");
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
