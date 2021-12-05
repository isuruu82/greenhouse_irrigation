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
    /// Interaction logic for Line_Tile.xaml
    /// </summary>
    public partial class Line_Tile : UserControl
    {
        String gv_user;
        int gv_index;
        public Line_Tile(string user, int index)
        {
            InitializeComponent();
            gv_user = user;
            gv_index = index;
            this.line_name.Text = gv_user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //((Panel)this.Parent).Children.Add(new Line_Panel(gv_user));
            //((Panel)this.Parent).Children.RemoveRange(1, gv_index);
        }
    }
}
