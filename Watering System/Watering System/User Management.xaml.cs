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
    public partial class User_Management : MetroWindow
    {
        int user_level;
        char mode;
        public User_Management(int lvl)
        {
            InitializeComponent();
            Loaded += User_Management_Loaded;
            user_level = lvl;
        }

        private void User_Management_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            get_users();
            get_usr_lvls();
        }

        private void txt_usr_id_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txt_usr_id.Text = txt_usr_id.Text.Replace(" ", "_");
            txt_usr_id.CaretIndex = txt_usr_id.Text.Length;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (txt_usr_id.Text == "")
            {
                txt_usr_id.Focus();
            }
            else
            {
                txt_usr_id.Foreground = new SolidColorBrush(Colors.Black);
                if (new EmailAddressAttribute().IsValid(txt_email.Text))
                {
                    txt_email.Foreground = new SolidColorBrush(Colors.Black);
                    if (txt_name.Text == "" || txt_pw.Password == "" || cmb_lvl.SelectedIndex == -1)
                    {
                        if (txt_name.Text == "")
                        {
                            txt_name.Focus();
                        }

                        if (txt_pw.Password == "")
                        {
                            txt_pw.Focus();
                        }

                        if (cmb_lvl.SelectedIndex == -1)
                        {
                            cmb_lvl.Focus();
                        }
                    }
                    else
                    {
                        RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                        RfcRepository repo = dest.Repository;
                        IRfcFunction fn_user = repo.CreateFunction("ZMOIDFY_USR");
                        fn_user.SetValue("IM_USERNAME", txt_usr_id.Text);
                        fn_user.SetValue("IM_NAME", txt_name.Text);
                        fn_user.SetValue("IM_PASSWORD", txt_pw.Password);
                        fn_user.SetValue("IM_EMAIL", txt_email.Text);
                        fn_user.SetValue("IM_USER_LEVEL", cmb_lvl.SelectedValue);
                        fn_user.SetValue("IM_FUNC", mode);
                        fn_user.Invoke(dest);
                        char msg_typ = fn_user.GetChar("ET_MSG_TYP");
                        if (msg_typ == '1')
                        {
                            if (mode == 'C')
                            {
                                await this.ShowMessageAsync("Successfully Created User", txt_usr_id.Text);
                                get_users();
                                lst_users.Items.Refresh();
                            }

                            if (mode == 'U')
                            {
                                await this.ShowMessageAsync("Successfully Updated User", txt_usr_id.Text);
                                get_users();
                                lst_users.Items.Refresh();
                            }
                        }
                        else
                        {
                            if (mode == 'C')
                            {
                                await this.ShowMessageAsync("User Creation Unsuccessful", txt_usr_id.Text);
                            }

                            if (mode == 'U')
                            {
                                await this.ShowMessageAsync("User Update Unsuccessful", txt_usr_id.Text);
                            }
                        }
                    }
                }
                else
                {
                    txt_email.Foreground = new SolidColorBrush(Colors.Red);
                    txt_email.Focus();
                }
            }
            btn_creat.IsEnabled = true;
            btn_update.IsEnabled = true;
            btn_delete.IsEnabled = true;
            txt_usr_id.IsEnabled = false;
            txt_usr_id.Text = "";
            txt_name.IsEnabled = false;
            txt_name.Text = "";
            txt_pw.IsEnabled = false;
            txt_pw.Password = "";
            txt_email.IsEnabled = false;
            txt_email.Text = "";
            cmb_lvl.IsEnabled = false;
            cmb_lvl.Text = "";
            btn_save.IsEnabled = false;
            btn_cansel.IsEnabled = false;
            lst_users.IsEnabled = true;

            txt_usr_id.Foreground = new SolidColorBrush(Colors.Black);
            txt_email.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mode = 'C';
            btn_update.IsEnabled = false;
            btn_delete.IsEnabled = false;
            txt_usr_id.IsEnabled = true;
            txt_usr_id.Text = "";
            txt_name.IsEnabled = true;
            txt_name.Text = "";
            txt_pw.IsEnabled = true;
            txt_pw.Password = "";
            txt_email.IsEnabled = true;
            txt_email.Text = "";
            cmb_lvl.IsEnabled = true;
            cmb_lvl.Text = "";
            btn_save.IsEnabled = true;
            btn_cansel.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mode = 'U';
            btn_creat.IsEnabled = false;
            btn_delete.IsEnabled = false;
            txt_usr_id.IsEnabled = true;
            txt_name.IsEnabled = true;
            txt_pw.IsEnabled = true;
            txt_email.IsEnabled = true;
            cmb_lvl.IsEnabled = true;
            cmb_lvl.SelectedItem = -1;
            btn_save.IsEnabled = true;
            btn_cansel.IsEnabled = true;
            lst_users.IsEnabled = false;

        }

        private void lst_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_users.SelectedIndex != -1)
            {
                DataRowView d1 = lst_users.SelectedItem as DataRowView;
                txt_usr_id.Text = d1["USERNAME"].ToString();
                txt_name.Text = d1["NAME"].ToString();
                txt_pw.Password = d1["PASSWORD"].ToString();
                txt_email.Text = d1["EMAIL"].ToString();
                cmb_lvl.SelectedValue = d1["USER_LEVEL"];
            }
        }

        private void btn_cansel_Click(object sender, RoutedEventArgs e)
        {
            btn_creat.IsEnabled = true;
            btn_update.IsEnabled = true;
            btn_delete.IsEnabled = true;
            txt_usr_id.IsEnabled = false;
            txt_usr_id.Text = "";
            txt_name.IsEnabled = false;
            txt_name.Text = "";
            txt_pw.IsEnabled = false;
            txt_pw.Password = "";
            txt_email.IsEnabled = false;
            txt_email.Text = "";
            cmb_lvl.IsEnabled = false;
            cmb_lvl.Text = "";
            btn_save.IsEnabled = false;
            btn_cansel.IsEnabled = false;
            lst_users.IsEnabled = true;

            txt_usr_id.Foreground = new SolidColorBrush(Colors.Black);
            txt_email.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void get_users()
        {
            try
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

                usercolumn = new DataColumn();
                usercolumn.DataType = System.Type.GetType("System.String");
                usercolumn.ColumnName = "NAME";

                usertable.Columns.Add(usercolumn);

                usercolumn = new DataColumn();
                usercolumn.DataType = System.Type.GetType("System.String");
                usercolumn.ColumnName = "PASSWORD";

                usertable.Columns.Add(usercolumn);

                usercolumn = new DataColumn();
                usercolumn.DataType = System.Type.GetType("System.String");
                usercolumn.ColumnName = "EMAIL";

                usertable.Columns.Add(usercolumn);

                usercolumn = new DataColumn();
                usercolumn.DataType = System.Type.GetType("System.String");
                usercolumn.ColumnName = "USER_LEVEL";

                usertable.Columns.Add(usercolumn);

                usercolumn = new DataColumn();
                usercolumn.DataType = System.Type.GetType("System.String");
                usercolumn.ColumnName = "LAST_LOGIN";

                usertable.Columns.Add(usercolumn);

                for (int i = 0; i < users.RowCount; i++)
                {
                    userrow = usertable.NewRow();
                    userrow["USERNAME"] = users[i].GetString("USERNAME");
                    userrow["NAME"] = users[i].GetString("NAME");
                    userrow["PASSWORD"] = users[i].GetString("PASSWORD");
                    userrow["EMAIL"] = users[i].GetString("EMAIL");
                    userrow["USER_LEVEL"] = users[i].GetString("USER_LEVEL");
                    userrow["LAST_LOGIN"] = users[i].GetString("LAST_LOGIN");
                    usertable.Rows.Add(userrow);
                }
                lst_users.ItemsSource = usertable.AsDataView();
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }
        }

        private void get_usr_lvls()
        {
            try
            {
                RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
                RfcRepository repo = dest.Repository;
                IRfcFunction fn_lvls = repo.CreateFunction("ZGET_USRLVL");
                fn_lvls.Invoke(dest);
                var levels = fn_lvls.GetTable("ET_USRLVL");

                DataTable lvltable = new DataTable("ZLEVELS");
                DataColumn lvlcolumn;
                DataRow lvlrow;

                lvlcolumn = new DataColumn();
                lvlcolumn.DataType = System.Type.GetType("System.String");
                lvlcolumn.ColumnName = "USER_LEVEL";

                lvltable.Columns.Add(lvlcolumn);

                lvlcolumn = new DataColumn();
                lvlcolumn.DataType = System.Type.GetType("System.String");
                lvlcolumn.ColumnName = "DESCRIPTION";

                lvltable.Columns.Add(lvlcolumn);

                for (int i = 0; i < levels.RowCount; i++)
                {
                    lvlrow = lvltable.NewRow();
                    lvlrow["USER_LEVEL"] = levels[i].GetString("USER_LEVEL");
                    lvlrow["DESCRIPTION"] = levels[i].GetString("DESCRIPTION");
                    lvltable.Rows.Add(lvlrow);
                }
                cmb_lvl.ItemsSource = lvltable.AsDataView();
            }
            catch (Exception)
            {

                MessageBox.Show("Disconnected");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;
            IRfcFunction fn_user = repo.CreateFunction("ZMOIDFY_USR");
            fn_user.SetValue("IM_USERNAME", txt_usr_id.Text);
            fn_user.SetValue("IM_NAME", txt_name.Text);
            fn_user.SetValue("IM_PASSWORD", txt_pw.Password);
            fn_user.SetValue("IM_EMAIL", txt_email.Text);
            fn_user.SetValue("IM_USER_LEVEL", cmb_lvl.SelectedValue);
            fn_user.SetValue("IM_FUNC", "D");
            fn_user.Invoke(dest);
            char msg_typ = fn_user.GetChar("ET_MSG_TYP");
            if (msg_typ == '1')
            {
                await this.ShowMessageAsync("Successfully Deleted User", txt_usr_id.Text);
                get_users();
                lst_users.Items.Refresh();
            }
            else
            {
                await this.ShowMessageAsync("User Not Deleted", txt_usr_id.Text);
            }

            txt_usr_id.Text = "";
            txt_name.Text = "";
            txt_pw.Password = "";
            txt_email.Text = "";
            cmb_lvl.Text = "";

        }
    }
}
