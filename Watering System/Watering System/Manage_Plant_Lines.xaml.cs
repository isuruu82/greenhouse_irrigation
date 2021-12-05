using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SAP.Middleware.Connector;
using System;
using System.Data;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace Watering_System
{
    public partial class Manage_Plant_Lines : MetroWindow
    {
        int user_level;
        char mode;

        SerialPort sp = new SerialPort();

        public Manage_Plant_Lines(int lvl)
        {
            InitializeComponent();
            Loaded += Manage_Plant_Lines_Loaded;
            user_level = lvl;
        }

        private void Manage_Plant_Lines_Loaded(object sender, RoutedEventArgs e)
        {
            get_plants();
            get_users();
            get_plines();
        }

        private void lst_plnt_lins_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lst_plnt_lins.SelectedIndex != -1)
            {
                DataRowView d1 = lst_plnt_lins.SelectedItem as DataRowView;
                txt_plnt_line_id.Text = d1["PLANT_LINE_ID"].ToString();
                lst_plant_id.SelectedValue = d1["PLANT_ID"];
                lst_users.SelectedValue = d1["USER_NAME"];
                txt_line_descptn.Text = d1["LINE_DESCRIPTION"].ToString();
                txt_mois.Text = d1["WTR_LVL"].ToString();

                btn_cmp.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mode = 'C';
            btn_updt.IsEnabled = false;
            btn_dlt.IsEnabled = false;
            btn_save.IsEnabled = true;
            btn_cansel.IsEnabled = true;
            btn_cmp.IsEnabled = false;

            txt_plnt_line_id.IsEnabled = true;
            txt_plnt_line_id.Text = "";
            txt_line_descptn.IsEnabled = true;
            txt_line_descptn.Text = "";
            lst_plant_id.IsEnabled = true;
            lst_plant_id.SelectedIndex = -1;
            lst_users.IsEnabled = true;
            lst_users.SelectedIndex = -1;
            txt_mois.IsEnabled = true;
            txt_mois.Text = "";

        }

        private void btn_cansel_Click(object sender, RoutedEventArgs e)
        {
            cancel_click();
        }

        private void btn_updt_Click(object sender, RoutedEventArgs e)
        {
            mode = 'U';
            btn_crt.IsEnabled = false;
            btn_dlt.IsEnabled = false;
            btn_save.IsEnabled = true;
            btn_cansel.IsEnabled = true;
            btn_cmp.IsEnabled = false;

            txt_plnt_line_id.IsEnabled = false;
            txt_line_descptn.IsEnabled = true;
            lst_plant_id.IsEnabled = true;
            lst_users.IsEnabled = true;
            txt_mois.IsEnabled = true;
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (lst_plant_id.SelectedIndex == -1)
            {
                lst_plant_id.Focus();
            }
            else
            {
                if (lst_users.SelectedIndex == -1)
                {
                    lst_plant_id.Focus();
                }
                else
                {
                    try
                    {
                        RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                        RfcRepository repo = dest.Repository;
                        IRfcFunction fn_plines = repo.CreateFunction("ZMOIDFY_PLINE");
                        fn_plines.SetValue("IM_PLINE_ID", txt_plnt_line_id.Text);
                        fn_plines.SetValue("IM_LINE_DESCRIPTION", txt_line_descptn.Text);
                        fn_plines.SetValue("IM_PLANT_ID", lst_plant_id.SelectedValue);
                        fn_plines.SetValue("IM_USER_NAME", lst_users.SelectedValue);
                        fn_plines.SetValue("IM_WTR_LVL", txt_mois.Text);
                        fn_plines.SetValue("IM_FUNC", mode);
                        fn_plines.Invoke(dest);
                        char msg_typ = fn_plines.GetChar("ET_MSG_TYP");
                        if (msg_typ == '1')
                        {
                            if (mode == 'U')
                            {
                                await this.ShowMessageAsync("Successfully Updated Plant Line", txt_line_descptn.Text);
                                get_plines();
                                cancel_click();
                                lst_plnt_lins.Items.Refresh();
                            }

                            if (mode == 'C')
                            {
                                await this.ShowMessageAsync("Successfully Created Plant Line", txt_line_descptn.Text);
                                get_plines();
                                cancel_click();
                                lst_plnt_lins.Items.Refresh();
                            }

                            if (mode == 'D')
                            {
                                await this.ShowMessageAsync("Successfully Deleted Plant Line", txt_line_descptn.Text);
                                get_plines();
                                cancel_click();
                                lst_plnt_lins.Items.Refresh();
                            }


                        }
                        else
                        {
                            if (mode == 'U')
                            {
                                await this.ShowMessageAsync("Plant Line Update Unsuccessful", txt_line_descptn.Text);
                            }

                            if (mode == 'C')
                            {
                                await this.ShowMessageAsync("Plant Line Creation Unsuccessful", txt_line_descptn.Text);
                            }

                            if (mode == 'D')
                            {
                                await this.ShowMessageAsync("Plant Line Deletion Unsuccessful", txt_line_descptn.Text);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Disconnected");
                    }
                }
            }
        }
        private void btn_dlt_Click(object sender, RoutedEventArgs e)
        {
            mode = 'D';
            btn_save_Click(sender, e);
        }

        private void get_plines()
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_plines = repo.CreateFunction("ZPLANT_LINES");
                fn_plines.Invoke(dest);
                var plant_lines = fn_plines.GetTable("ET_LINES");

                IRfcFunction fn_plnts = repo.CreateFunction("ZGET_PLANTS");
                fn_plnts.Invoke(dest);
                var plants = fn_plnts.GetTable("ET_PLANTS");

                DataTable table = new DataTable("ZPLANT_LINES");
                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "PLANT_LINE_ID";

                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "PLANT_ID";

                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "USER_NAME";

                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "LINE_DESCRIPTION";

                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "STATUS";

                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "WTR_LVL";

                table.Columns.Add(column);

                for (int i = 0; i < plant_lines.RowCount; i++)
                {
                    row = table.NewRow();
                    row["PLANT_LINE_ID"] = plant_lines[i].GetString("PLANT_LINE_ID");
                    row["PLANT_ID"] = plant_lines[i].GetString("PLANT_ID");
                    row["USER_NAME"] = plant_lines[i].GetString("USER_NAME");
                    row["LINE_DESCRIPTION"] = plant_lines[i].GetString("LINE_DESCRIPTION");
                    row["STATUS"] = plant_lines[i].GetString("STATUS");
                    row["WTR_LVL"] = plant_lines[i].GetString("WTR_LVL");
                    table.Rows.Add(row);
                }
                lst_plnt_lins.ItemsSource = table.AsDataView();
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }
        }
        private void get_users()
        {
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;
            IRfcFunction fn_users = repo.CreateFunction("ZGET_USERS");
            fn_users.Invoke(dest);
            var users = fn_users.GetTable("ET_USER");

            DataTable usertable = new DataTable("ZUSERS");
            DataColumn usercolumn;
            DataRow userrow;

            usercolumn = new DataColumn();
            usercolumn.DataType = System.Type.GetType("System.String");
            usercolumn.ColumnName = "USERNAME";

            usertable.Columns.Add(usercolumn);

            for (int i = 0; i < users.RowCount; i++)
            {
                userrow = usertable.NewRow();
                userrow["USERNAME"] = users[i].GetString("USERNAME");
                usertable.Rows.Add(userrow);
            }
            lst_users.ItemsSource = usertable.AsDataView();
        }

        private void get_plants()
        {
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;

            IRfcFunction fn_plnts = repo.CreateFunction("ZGET_PLANTS");
            fn_plnts.Invoke(dest);
            var plants = fn_plnts.GetTable("ET_PLANTS");


            DataTable plnttable = new DataTable("ZPLANT");
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

            for (int i = 0; i < plants.RowCount; i++)
            {
                plntrow = plnttable.NewRow();
                plntrow["PLANT_ID"] = plants[i].GetString("PLANT_ID");
                plntrow["NAME"] = plants[i].GetString("NAME");
                plnttable.Rows.Add(plntrow);
            }
            lst_plant_id.ItemsSource = plnttable.AsDataView();
        }

        private void cancel_click()
        {
            btn_crt.IsEnabled = true;
            btn_updt.IsEnabled = true;
            btn_dlt.IsEnabled = true;
            btn_save.IsEnabled = false;
            btn_cansel.IsEnabled = false;
            btn_cmp.IsEnabled = true;

            txt_plnt_line_id.IsEnabled = false;
            txt_line_descptn.IsEnabled = false;
            lst_plant_id.IsEnabled = false;
            lst_users.IsEnabled = false;
            txt_mois.IsEnabled = false;
            btn_cmp.IsEnabled = false;

            txt_plnt_line_id.Text = "";
            txt_line_descptn.Text = "";
            txt_line_descptn.Text = "";
            txt_mois.Text = "";
            lst_plant_id.SelectedIndex = -1;
            lst_users.SelectedIndex = -1;

            mode = ' ';
        }

        private async void btn_cmp_Click(object sender, RoutedEventArgs e)
        {
            mode = 'F';
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_plines = repo.CreateFunction("ZMOIDFY_PLINE");
                fn_plines.SetValue("IM_PLINE_ID", txt_plnt_line_id.Text);
                fn_plines.SetValue("IM_LINE_DESCRIPTION", txt_line_descptn.Text);
                fn_plines.SetValue("IM_PLANT_ID", lst_plant_id.SelectedValue);
                fn_plines.SetValue("IM_USER_NAME", lst_users.SelectedValue);
                fn_plines.SetValue("IM_WTR_LVL", txt_mois.Text);
                fn_plines.SetValue("IM_FUNC", mode);
                fn_plines.Invoke(dest);
                char msg_typ = fn_plines.GetChar("ET_MSG_TYP");
                if (msg_typ == '1')
                {
                    await this.ShowMessageAsync("Successfully Completed Plant Line", txt_plnt_line_id.Text);
                    get_plines();
                    cancel_click();
                    lst_plnt_lins.Items.Refresh();
                }
                else
                {
                    await this.ShowMessageAsync("Plant Line Complition Unsuccessful", txt_plnt_line_id.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Disconnected");
            }
        }
    }
}
