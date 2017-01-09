using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using NS_OrdersSystem.Services;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using NS_OrdersSystem.Views;
using NS_OrdersSystem.Data;
namespace NS_OrdersSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PassWordBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginUser();
            }
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            loginUser();
        }

        private void loginUser()
        {
            if (TextBoxLogin.Text != "" && PassWordBoxPass.Password!="")
            {
                if (UsersServices.LogUser(TextBoxLogin.Text, PassWordBoxPass.Password))
                {
                    ShowOrderMenu();
                }
                else
                {
                    ShowMessage("Error", "usuario o contraseña incorrecta");
                }
            }
            else
            {
                ShowMessage("Error","Ingrese un usuario y contraseña");
            }
        }

        private void ShowOrderMenu()
        {
            OrderView or = new OrderView();
            or.Show();
            this.Close();
        }
        private async void ShowMessage(string title,string content)
        {
            await this.ShowMessageAsync(title,content);
        }

    }
}
