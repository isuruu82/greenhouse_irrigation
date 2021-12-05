using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Watering_System
{
    /// <summary>
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : UserControl
    {
        public Log()
        {
            InitializeComponent();
            Loaded += Log_Loaded;
        }

        private void Log_Loaded(object sender, RoutedEventArgs e)
        {
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;
            IRfcFunction fn_log = repo.CreateFunction("ZVALUE_LOG");
            fn_log.Invoke(dest);
            var valuelog = fn_log.GetTable("EX_LOG");

            int j = valuelog.RowCount;
            for (int i = 0; i < j; i++)

            {
                string linemois = valuelog[i].GetString("R_DATE") + " - " + valuelog[i].GetString("R_TIME") + " - Plant Line : " + valuelog[i].GetString("PLANT_LINE_ID")
                    + " - Moisture : " + valuelog[i].GetString("MOISTURE");
                soilListView.Items.Add(linemois);

                string linetemp = valuelog[i].GetString("R_DATE") + " - " + valuelog[i].GetString("R_TIME") + " - Plant Line : " + valuelog[i].GetString("PLANT_LINE_ID")
                    + " - Temperature : " + valuelog[i].GetString("TEMPERATURE");
                tempListView.Items.Add(linetemp);
            }
        }
    }
}
