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
    /// Interaction logic for Line_Panel.xaml
    /// </summary>
    public partial class Line_Panel : UserControl
    {
        int gv_tot_users = 2;
        public Line_Panel()
        {
            InitializeComponent();
            Loaded += LinePanel_Loaded;
        }

        private void LinePanel_Loaded(object sender, RoutedEventArgs e)
        {
            UserGridPanel.Children.Add(new Line_Tile("Line 1", gv_tot_users));
            UserGridPanel.Children.Add(new Line_Tile("Line 2", gv_tot_users));
            //UserGridPanel.Children.Add(new Line_Tile("Line 3", gv_tot_users));
            //UserGridPanel.Children.Add(new Line_Tile("Line 4", gv_tot_users));
            //UserGridPanel.Children.Add(new Line_Tile("Line 5", gv_tot_users));
            //UserGridPanel.Children.Add(new Line_Tile("Line 6", gv_tot_users));
        }
    }
}
