using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Timers;
using SAP.Middleware.Connector;
using System.IO.Ports;
using System;
using System.Threading;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Windows.Media;

namespace Watering_System
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        int user_level;
        public string user;
        User_Management um;
        Manage_Plant_Lines pl;

        public Dashboard(int lvl, string name)
        {
            InitializeComponent();
            Loaded += Dashboard_Loaded;
            user_level = lvl;
            user = name;
        }

        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            Total total = new Total();
            DataContext = new TotalViewModel1(total);


            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;
            IRfcFunction fn_plines = repo.CreateFunction("ZPLANT_LINES");
            fn_plines.Invoke(dest);
            double active = fn_plines.GetDouble("EX_ACTIVE");
            double warning = fn_plines.GetDouble("EX_WARNING");
            double inac = fn_plines.GetDouble("EX_INACTIVE");

            if (warning == 0)
            {
                wrn.Background = Brushes.Green;
            }
            else
            {
                wrn.Background = Brushes.Red;
            }



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pl == null)
            {
                pl = new Manage_Plant_Lines(user_level);
            }
            pl.Closed += delegate { pl = null; };

            if (pl.WindowState == WindowState.Minimized)
            {
                pl.WindowState = WindowState.Normal;
            }

            pl.Show();
            pl.Activate();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (um == null)
            {
                um = new User_Management(user_level);
            }
            um.Closed += delegate { um = null; };

            if (um.WindowState == WindowState.Minimized)
            {
                um.WindowState = WindowState.Normal;
            }

            um.Show();
            um.Activate();
        }


    }

    internal class TotalViewModel1
    {
        public List<Total> Total { get; private set; }

        public TotalViewModel1(Total total)
        {
            Total = new List<Total>();
            Total.Add(total);
        }

    }

    internal class Total
    {
        public string tot_crs { get; private set; }
        public double Precentage { get; private set; }

        public string tot_crsw { get; private set; }
        public double Precentagew { get; private set; }

        public string tot_crsi { get; private set; }
        public double Precentagei { get; private set; }

        public Total()
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_plines = repo.CreateFunction("ZPLANT_LINES");
                fn_plines.Invoke(dest);
                double active = fn_plines.GetDouble("EX_ACTIVE");
                double warning = fn_plines.GetDouble("EX_WARNING");
                double inac = fn_plines.GetDouble("EX_INACTIVE");

                double tot = active + warning + inac;

                tot_crs = "Active Lines - " + active;
                if (active != 0)
                {
                    Precentage = (active / tot) * 100;
                }

                tot_crsw = "Warning Lines - " + warning;
                if (warning != 0)
                {
                    Precentagew = (warning / tot) * 100;
                }

                if (inac != 0)
                {
                    Precentagei = (inac / tot) * 100;
                }
                tot_crsi = "Inactive Lines - " + inac;
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }

        }
    }


}
