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
    /// Interaction logic for Line_Value.xaml
    /// </summary>
    public partial class Action_Panel : UserControl
    {
        Plant_Management pm;
        public Action_Panel()
        {
            InitializeComponent();
            Loaded += Line_Value_Loaded;
        }

        private void Line_Value_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pm == null)
            {
                pm = new Plant_Management('P');
            }
            pm.Closed += delegate { pm = null; };

            if (pm.WindowState == WindowState.Minimized)
            {
                pm.WindowState = WindowState.Normal;
            }

            pm.Show();
            pm.Activate();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pm == null)
            {
                pm = new Plant_Management('M');
            }
            pm.Closed += delegate { pm = null; };

            if (pm.WindowState == WindowState.Minimized)
            {
                pm.WindowState = WindowState.Normal;
            }

            pm.Show();
            pm.Activate();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (pm == null)
            {
                pm = new Plant_Management('C');
            }
            pm.Closed += delegate { pm = null; };

            if (pm.WindowState == WindowState.Minimized)
            {
                pm.WindowState = WindowState.Normal;
            }

            pm.Show();
            pm.Activate();
        }
    }
}
