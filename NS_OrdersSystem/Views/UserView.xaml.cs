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
using MahApps.Metro.Controls;
using NS_OrdersSystem.Services;
using System.Data;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
namespace NS_OrdersSystem.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : MetroWindow
    {
        private int currentSelectedUser = -1;
        public UserView()
        {
            InitializeComponent();
            showAllUser();
        }

        private void showAllUser()
        {
            DGUsers.ItemsSource = UsersServices.GetAllUsers().DefaultView;

        }

        private void DGUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView r = (DataRowView)DGUsers.SelectedItem;
                currentSelectedUser = int.Parse(r["us_user"].ToString());
                fillSpacesUser(r["us_name"].ToString(), r["us_paterno"].ToString(), r["us_materno"].ToString(), r["us_login"].ToString(), r["us_password"].ToString());
            }
            catch (Exception)
            {

            }
        }

        private void fillSpacesUser(string p1, string p2, string p3, string p4, string p5)
        {
            TBName.Text = p1;
            TBPaterno.Text = p2;
            TBMaterno.Text = p3;
            TBlogin.Text = p4;
            TBPassword.Text = p5;
        }


        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (!UsersServices.ExistLogin(TBlogin.Text))
            {
                if (TBPaterno.Text != "" &&
                TBMaterno.Text != "" &&
                TBlogin.Text != "" &&
                TBPassword.Text != "")
                {
                UsersServices.AddThisUser(TBName.Text,
                TBPaterno.Text,
                TBMaterno.Text,
                TBlogin.Text,
                TBPassword.Text);

                }
                else
                    ShowMessage("Error", "No se puedo Agregar al Usuario");
                
                showAllUser();
                cleanFields();
            }
            else
            {
                ShowMessage("Error", "El usuario ya existe, use otro login");
            }
            
            
        }

        private void cleanFields()
        {
            TBName.Text = "";
            TBPaterno.Text = "";
            TBMaterno.Text = "";
            TBlogin.Text = "";
            TBPassword.Text = "";
            currentSelectedUser = -1;
        }

        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (TBName.Text != "" &&
           TBPaterno.Text != "" &&
           TBMaterno.Text != "" &&
           TBlogin.Text != "" &&
           TBPassword.Text != "")
            {
                UsersServices.UpdateThisUser(TBName.Text,
            TBPaterno.Text,
            TBMaterno.Text,
            TBlogin.Text,
            TBPassword.Text,
            currentSelectedUser);

            }
            else
                ShowMessage("Error", "No se puedo Actualizar al Usuario");
            showAllUser();
        }

        private void BEnable_Click(object sender, RoutedEventArgs e)
        {
            if (currentSelectedUser!=-1)
            {
                UsersServices.EnableThisUser(currentSelectedUser, 1);
                cleanFields();
            }
            showAllUser();
        }

        private void BUnenable_Click(object sender, RoutedEventArgs e)
        {
            if (currentSelectedUser != -1)
            {
                UsersServices.EnableThisUser(currentSelectedUser, 0);
                cleanFields();
            }
            showAllUser();
        }

        private async void ShowMessage(string title, string content)
        {
            await this.ShowMessageAsync(title, content);
        }
    }
}
