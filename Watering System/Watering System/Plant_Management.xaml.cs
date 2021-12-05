using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SAP.Middleware.Connector;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Watering_System
{
    /// <summary>
    /// Interaction logic for User_Management.xaml
    /// </summary>
    /// 

    public partial class Plant_Management : MetroWindow
    {
        char gv_type;
        public Plant_Management(char type)
        {
            InitializeComponent();
            Loaded += User_Management_Loaded;
            gv_type = type;
        }

        private void User_Management_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            get_plants();
            get_types();
            //cmb_typ.SelectedIndex = -1;
            if (gv_type == 'P')
            {
                txt_hum.Visibility = Visibility.Hidden;
                txt_temp.Visibility = Visibility.Hidden;
                lbl_crop.Visibility = Visibility.Hidden;
                lbl_pest.Visibility = Visibility.Hidden;
            }
            if (gv_type == 'M')
            {
                lbl_pty.Visibility = Visibility.Hidden;
                cmb_typ.Visibility = Visibility.Hidden;
                txt_hum.Visibility = Visibility.Hidden;
                lbl_crop.Visibility = Visibility.Hidden;
                btn_creat.Visibility = Visibility.Hidden;
                btn_delete.Visibility = Visibility.Hidden;
            }
            if (gv_type == 'C')
            {
                lbl_pty.Visibility = Visibility.Hidden;
                cmb_typ.Visibility = Visibility.Hidden;
                txt_temp.Visibility = Visibility.Hidden;
                lbl_pest.Visibility = Visibility.Hidden;
                btn_creat.Visibility = Visibility.Hidden;
                btn_delete.Visibility = Visibility.Hidden;
            }

        }

        private void txt_usr_id_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txt_pln_id.Text = txt_pln_id.Text.Replace(" ", "_");
            txt_pln_id.CaretIndex = txt_pln_id.Text.Length;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Regex rgx = new Regex("[^A-Za-z0-9]");
            //bool containsSpecialCharacter = rgx.IsMatch(txt_pln_id.Text);
            //if (txt_pln_id.Text == "")
            //{
            //    txt_usr_id.Focus();
            //}
            //else
            //{
            //    if (containsSpecialCharacter)
            //    {
            //        txt_usr_id.Foreground = new SolidColorBrush(Colors.Red);
            //        txt_usr_id.Focus();
            //    }
            //    else
            //    {
            //        txt_usr_id.Foreground = new SolidColorBrush(Colors.Black);
            //        if (new EmailAddressAttribute().IsValid(txt_email.Text))
            //        {
            //            txt_email.Foreground = new SolidColorBrush(Colors.Black);
            //            if (txt_name.Text == "" || txt_pw.Password == "" || cmb_lvl.SelectedIndex == -1)
            //            {
            //                if (txt_name.Text == "")
            //                {
            //                    txt_name.Focus();
            //                }

            //                if (txt_pw.Password == "")
            //                {
            //                    txt_pw.Focus();
            //                }

            //                if (cmb_lvl.SelectedIndex == -1)
            //                {
            //                    cmb_lvl.Focus();
            //                }
            //            }
            //            else
            //            {
            //                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            //                RfcRepository repo = dest.Repository;
            //                IRfcFunction fn_user = repo.CreateFunction("ZMOIDFY_USR");
            //                fn_user.SetValue("IM_USERNAME", txt_usr_id.Text);
            //                fn_user.SetValue("IM_NAME", txt_name.Text);
            //                fn_user.SetValue("IM_PASSWORD", txt_pw.Password);
            //                fn_user.SetValue("IM_EMAIL", txt_email.Text);
            //                fn_user.SetValue("IM_USER_LEVEL", cmb_lvl.SelectedValue);
            //                fn_user.SetValue("IM_FUNC", "C");
            //                fn_user.Invoke(dest);
            //                char msg_typ = fn_user.GetChar("ET_MSG_TYP");
            //                if (msg_typ == '1')
            //                {
            //                    await this.ShowMessageAsync("Successfully Created User", txt_usr_id.Text);
            //                    get_users();
            //                    lst_users.Items.Refresh();
            //                }
            //                else
            //                {
            //                    await this.ShowMessageAsync("User Creation Unsuccessful", txt_usr_id.Text);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            txt_email.Foreground = new SolidColorBrush(Colors.Red);
            //            txt_email.Focus();
            //        }
            //    }
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btn_update.IsEnabled = false;
            btn_delete.IsEnabled = false;
            txt_pln_id.IsEnabled = true;
            txt_pln_id.Text = "";
            txt_name.IsEnabled = true;
            txt_name.Text = "";
            txt_temp.IsEnabled = true;
            txt_temp.Text = "";
            txt_hum.IsEnabled = true;
            txt_hum.Text = "";
            cmb_typ.IsEnabled = true;
            cmb_typ.Text = "";
            btn_save.IsEnabled = true;
            btn_cansel.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn_creat.IsEnabled = false;
            btn_delete.IsEnabled = false;

            txt_name.IsEnabled = true;
            txt_temp.IsEnabled = true;
            txt_hum.IsEnabled = true;
            cmb_typ.IsEnabled = true;
            cmb_typ.SelectedItem = -1;

            btn_save.IsEnabled = true;
            btn_cansel.IsEnabled = true;
        }

        private void lst_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataRowView d1 = lst_plants.SelectedItem as DataRowView;
            //txt_pln_id.Text = d1["USERNAME"].ToString();
            //txt_name.Text = d1["NAME"].ToString();
            //txt_pw.Password = d1["PASSWORD"].ToString();
            //txt_email.Text = d1["EMAIL"].ToString();
            //cmb_lvl.SelectedValue = d1["USER_LEVEL"];
        }

        private void btn_cansel_Click(object sender, RoutedEventArgs e)
        {
            btn_creat.IsEnabled = true;
            btn_update.IsEnabled = true;
            btn_delete.IsEnabled = true;
            txt_pln_id.IsEnabled = false;
            txt_pln_id.Text = "";
            txt_name.IsEnabled = false;
            txt_name.Text = "";
            txt_hum.IsEnabled = false;
            txt_hum.Text = "";
            txt_temp.IsEnabled = false;
            txt_temp.Text = "";
            cmb_typ.IsEnabled = false;
            cmb_typ.Text = "";
            btn_save.IsEnabled = false;
            btn_cansel.IsEnabled = false;
        }
        private void get_plants()
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_plnts = repo.CreateFunction("ZGET_PLANTS");
                fn_plnts.Invoke(dest);
                var users = fn_plnts.GetTable("ET_PLANTS");

                DataTable plnttable = new DataTable("ZPLANTS");
                DataColumn plntcolumn;
                DataRow plntrow;

                plntcolumn = new DataColumn();
                plntcolumn.DataType = System.Type.GetType("System.Int32");
                plntcolumn.ColumnName = "PLANT_ID";

                plnttable.Columns.Add(plntcolumn);

                plntcolumn = new DataColumn();
                plntcolumn.DataType = System.Type.GetType("System.String");
                plntcolumn.ColumnName = "NAME";

                plnttable.Columns.Add(plntcolumn);

                plntcolumn = new DataColumn();
                plntcolumn.DataType = System.Type.GetType("System.Int32");
                plntcolumn.ColumnName = "PLANT_TYPE";

                plnttable.Columns.Add(plntcolumn);

                plntcolumn = new DataColumn();
                plntcolumn.DataType = System.Type.GetType("System.Int32");
                plntcolumn.ColumnName = "PEST";

                plnttable.Columns.Add(plntcolumn);

                plntcolumn = new DataColumn();
                plntcolumn.DataType = System.Type.GetType("System.Int32");
                plntcolumn.ColumnName = "CROP";

                plnttable.Columns.Add(plntcolumn);

                for (int i = 0; i < users.RowCount; i++)
                {
                    plntrow = plnttable.NewRow();
                    plntrow["PLANT_ID"] = users[i].GetString("PLANT_ID");
                    plntrow["NAME"] = users[i].GetString("NAME");
                    plntrow["PLANT_TYPE"] = users[i].GetString("PLANT_TYPE");
                    plntrow["PEST"] = users[i].GetString("PEST");
                    plntrow["CROP"] = users[i].GetString("CROP");
                    plnttable.Rows.Add(plntrow);
                }
                lst_plants.ItemsSource = plnttable.AsDataView();
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }
        }

        private void get_types()
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_typs = repo.CreateFunction("ZGET_PLANT_TYPS");
                fn_typs.Invoke(dest);
                var typs = fn_typs.GetTable("ET_TYPE");

                DataTable typtable = new DataTable("ZTYPS");
                DataColumn typcolumn;
                DataRow typrow;

                typcolumn = new DataColumn();
                typcolumn.DataType = System.Type.GetType("System.Int32");
                typcolumn.ColumnName = "PLANT_TYPE";

                typtable.Columns.Add(typcolumn);

                typcolumn = new DataColumn();
                typcolumn.DataType = System.Type.GetType("System.String");
                typcolumn.ColumnName = "DESCRIPTION";

                typtable.Columns.Add(typcolumn);

                for (int i = 0; i < typs.RowCount; i++)
                {
                    typrow = typtable.NewRow();
                    typrow["PLANT_TYPE"] = typs[i].GetInt("PLANT_TYPE");
                    typrow["DESCRIPTION"] = typs[i].GetString("DESCRIPTION");
                    typtable.Rows.Add(typrow);
                }
                cmb_typ.ItemsSource = typtable.AsDataView();
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }
        }

        private void lst_plants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView d1 = lst_plants.SelectedItem as DataRowView;
            txt_pln_id.Text = d1["PLANT_ID"].ToString();
            txt_name.Text = d1["NAME"].ToString();
            txt_temp.Text = d1["PEST"].ToString();
            txt_hum.Text = d1["CROP"].ToString();
            cmb_typ.SelectedValue = d1["PLANT_TYPE"];
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
