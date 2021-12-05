using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Timers;
using SAP.Middleware.Connector;
using System.IO.Ports;
using System;
using System.Threading;
using System.Windows.Threading;
using System.Data;

namespace Watering_System
{
    public partial class Main_Window : Window
    {
        int user_level;
        string user_name;

        SerialPort sp = new SerialPort();
        User_account ua;

        public Main_Window(int lvl, string name)
        {
            user_level = lvl;
            user_name = name;
            InitializeComponent();
            Loaded += Main_Window_Loaded;
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            MenuListView.SelectedIndex = 0;
            this.txt_username.Text = user_name;
            if (user_level != 9)
            {
                this.listViewItem1.IsEnabled = false;
            }
            InitTimer();
        }

        public void InitTimer()
        {

            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.AutoReset = true;
            timer.Elapsed += timer_elapsed;
            timer.Start();

        }

        public void opn_con()
        {
            try
            {
                sp.PortName = "COM5";
                sp.BaudRate = 9600;
                sp.Open();
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    btn_bt.IsEnabled = false;
                    btn_bt.Content = "Connected";
                }), DispatcherPriority.Background);

                RfcDestination destu = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repou = destu.Repository;
                IRfcFunction fn_plines = repou.CreateFunction("ZPLANT_LINES");
                fn_plines.Invoke(destu);
                var users = fn_plines.GetTable("ET_LINES");

                for (int i = 0; i < users.RowCount; i++)
                {
                    sp.WriteLine("val" + users[i].GetString("PLANT_LINE_ID") + users[i].GetString("WTR_LVL"));
                    Thread.Sleep(5000);
                }

            }
            catch (Exception)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    btn_bt.IsEnabled = true;
                    btn_bt.Content = "Not Connected";
                }), DispatcherPriority.Background);
            }
        }

        private void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            if (sp.IsOpen)
            {
                if (sp.CDHolding.Equals(true))
                {
                    try
                    {
                        sp.Write("l1");
                        Thread.Sleep(5000);
                        string values = sp.ReadLine();
                        string[] sen_vals = values.Split(',');

                        double temp_val = double.Parse(sen_vals[0].Substring(1));
                        double humi_val = double.Parse(sen_vals[1].Substring(1));
                        double mois_val = double.Parse(sen_vals[2].Substring(1));
                        int wtr_val = int.Parse(sen_vals[3].Substring(1));

                        RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                        RfcRepository repo = dest.Repository;
                        IRfcFunction fn_update = repo.CreateFunction("ZUPDATE_SENSOR_VALUES");
                        fn_update.SetValue("IM_PLANT_ID", "001");
                        fn_update.SetValue("IM_TEMPERATURE", temp_val);
                        fn_update.SetValue("IM_HUMIDITY", humi_val);
                        fn_update.SetValue("IM_MOISTURE", mois_val);
                        fn_update.Invoke(dest);

                        IRfcFunction fn_wupdate = repo.CreateFunction("ZUPDATE_WATER");
                        fn_wupdate.SetValue("IM_PLANT_ID", "001");
                        fn_wupdate.SetValue("IM_WATER_COUNT", wtr_val);
                        fn_wupdate.Invoke(dest);

                        IRfcFunction fn_plines = repo.CreateFunction("ZPLANT_LINES");
                        fn_plines.Invoke(dest);
                        var users = fn_plines.GetTable("ET_LINES");

                        for (int i = 0; i < users.RowCount; i++)
                        {
                            sp.WriteLine("val" + users[i].GetString("PLANT_LINE_ID") + users[i].GetString("WTR_LVL"));
                            Thread.Sleep(100);
                        }

                    }
                    catch (Exception)
                    {

                    }

                    try
                    {



                    }
                    catch (Exception)
                    {

                    }

                }
                else
                {
                    sp.Close();
                    opn_con();
                }

            }
            else
            {
                sp.Close();
                opn_con();
            }
        }

        private void popopbtnlogoout_Click(object sender, RoutedEventArgs e)
        {

            sp.Close();
            Application.Current.Shutdown();

        }

        private void bntclosemenu_Click(object sender, RoutedEventArgs e)
        {
            bntopenmenu.Visibility = Visibility.Visible;
            bntclosemenu.Visibility = Visibility.Collapsed;
        }

        private void bntopenmenu_Click(object sender, RoutedEventArgs e)
        {
            bntopenmenu.Visibility = Visibility.Collapsed;
            bntclosemenu.Visibility = Visibility.Visible;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton.ToString() == "Left")
            {
                DragMove();
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = MenuListView.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Dashboard(user_level, user_name));
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Action_Panel());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Log());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Line_Panel());
                    break;
                default:
                    GridPrincipal.Children.Clear();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void btn_bt_Click(object sender, RoutedEventArgs e)
        {
            //sp.Write("Stop");
            sp.Close();
            opn_con();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ua == null)
            {
                ua = new User_account(user_name);
            }
            ua.Closed += delegate { ua = null; };

            if (ua.WindowState == WindowState.Minimized)
            {
                ua.WindowState = WindowState.Normal;
            }

            ua.Show();
            ua.Activate();
        }
    }
}
