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
using System.Text.RegularExpressions;
using NS_OrdersSystem.Services;
using System.Data;
using NS_OrdersSystem.Data;
namespace NS_OrdersSystem.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : MetroWindow
    {
        private int currentItemSelected = new int();
        private int currentItemSelectedCoti = new int();
        private bool isMaster = false;
        public OrderView()
        {
            InitializeComponent();
            ShowAllOrders();
            ShowAllQuotes();
            ShowCurrentUser();
            DatePickerDate.SelectedDate = DateTime.Now;
            DatePickerDateCoti.SelectedDate = DateTime.Now;
        }

        private void ShowAllQuotes()
        {
            DataGridQuotes.ItemsSource = QuotesServices.GetAllQuotes().DefaultView;
        }

        private void ShowCurrentUser()
        {
            DataTable table = UsersServices.GetThisUser(SessionData.CurrentUser.ToString());
            string name = table.Rows[0]["us_name"] + " " + table.Rows[0]["us_paterno"];
            isMaster = (bool)table.Rows[0]["us_master"];
            if (!isMaster)
            {
                ButtonDelete.IsEnabled = false;
                ButtonUsuarios.Visibility = Visibility.Collapsed;
                ButtonDeleteCoti.IsEnabled = false;

            }
            TextBoxCurrentUser.Text = name.ToUpper();
        }

        private void ShowAllOrders()
        {
            DataGridOrders.ItemsSource = OrdersServices.GetAllOrders().DefaultView;
            
        }

        private void TextBoxPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    if (float.Parse(TextBoxPrecio.Text) >= float.Parse(TextBoxAnticipe.Text))
            //    {
            //        calcMoney();
            //    }
            //    else
            //    {
            //        TextBoxAnticipe.Text = "0.00";
            //        TextBoxSaldo.Text = "0.00";
            //        TextBoxAlert.Text = "Saldo superior al precio";
            //    }

            //}
            //catch (Exception)
            //{
                
               
            //}
            
        }

        private void calcMoney()
        {
            try
            {
                float saldo = new float();
                saldo = float.Parse(TextBoxPrecio.Text) - float.Parse(TextBoxAnticipe.Text);
                TextBoxSaldo.Text = saldo.ToString("00.00");
            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void Anticipe_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (TextBoxPrecio.Text != "" && TextBoxAnticipe.Text != "")
            //{


            //    if (float.Parse(TextBoxPrecio.Text) >= float.Parse(TextBoxAnticipe.Text))
            //    {
            //        calcMoney();
            //    }
            //    else
            //    {
            //        TextBoxAnticipe.Text = "0.00";
            //        TextBoxSaldo.Text = "0.00";
            //        TextBoxAlert.Text = "Saldo superior al precio";
            //    }
            //}
        }

        private void TextBoxPrecio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !isTextAllowed(e.Text);
        }

        private bool isTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            DateTime? date = new DateTime?();
            date = DatePickerDate.SelectedDate;
            bool state = false;
            if (ComboBoxState.SelectedIndex!=0)
            {
                state = true;
            }

            OrdersServices.InsertOrder(date, TextBoxName.Text, TextBoxPhone.Text, TextBoxProduct.Text, TextBoxPrecio.Text, TextBoxAnticipe.Text, TextBoxObservation.Text, state);
            TextBlockMessage.Text = "Guardado con exito...";
            cleanSpaces();
            ShowAllOrders();
            }
            catch (Exception)
            {
                
             
            }
            
        }

        private void cleanSpaces()
        {
            DatePickerDate.SelectedDate = DateTime.Now;
            TextBoxName.Text = "";
            TextBoxPhone.Text = "";
            TextBoxProduct.Text = "";
            TextBoxPrecio.Text = "0.00";
            TextBoxAnticipe.Text = "0.00";
            TextBoxSaldo.Text = "0.00";
            TextBoxObservation.Text = "";
            TextBoxNumeroRecibo.Text = "";
            ComboBoxState.SelectedIndex = 0;
            ButtonUpdate.IsEnabled = false;
            TextBoxUsuario.Text = "";
            currentItemSelected = -1;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? date = new DateTime?();
                date = DatePickerDate.SelectedDate;
                bool state = false;
                if (ComboBoxState.SelectedIndex != 0)
                {
                    state = true;
                }

                OrdersServices.UpdateThisOrder(date, TextBoxName.Text, TextBoxPhone.Text, TextBoxProduct.Text, TextBoxPrecio.Text, TextBoxAnticipe.Text, TextBoxObservation.Text, state,currentItemSelected);
                TextBlockMessage.Text = "Actualizado con exito...";
                cleanSpaces();
                ShowAllOrders();
                
            }
            catch (Exception)
            {
                TextBlockMessage.Text = "Ha Ocurrido un error...";

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            OrdersServices.DeleteThisOrder(currentItemSelected);
            cleanSpaces();
            ShowAllOrders();
            TextBlockMessage.Text = "Eliminado con exito...";
            }
            catch (Exception)
            {
                TextBlockMessage.Text = "No se pudo Elminar...";
                
            }
            
        }

        private void DataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            DataRowView r = (DataRowView)DataGridOrders.SelectedItem;
            currentItemSelected =int.Parse(r["or_order"].ToString());
            Data.SessionData.selectedToReport = currentItemSelected.ToString();
            fillSpacesOrder();
            calcMoney();
            if (!isMaster)
            {
               if (r["or_user_owner"].ToString()==SessionData.CurrentUser.ToString())
                {
                ButtonUpdate.IsEnabled = true;                           
                }
               else
               {
                   ButtonUpdate.IsEnabled = false;
               }
            }
            else
            {
                ButtonUpdate.IsEnabled = true; 
            }
            

            }
            catch (Exception)
            {
                
                
            }
            
           

        }

        private void fillSpacesOrder()
        {
            DataTable table = OrdersServices.GetThisOrder(currentItemSelected);
            DatePickerDate.SelectedDate = table.Rows[0]["or_date"] as DateTime?;
            TextBoxName.Text = table.Rows[0]["or_client_name"].ToString();
            TextBoxPhone.Text = table.Rows[0]["or_phone"].ToString();
            TextBoxProduct.Text = table.Rows[0]["or_product_description"].ToString();
            TextBoxPrecio.Text = table.Rows[0]["or_price"].ToString();
            TextBoxAnticipe.Text = table.Rows[0]["or_anticipe"].ToString();
            TextBoxObservation.Text = table.Rows[0]["or_observation"].ToString();
            TextBoxNumeroRecibo.Text = table.Rows[0]["or_order"].ToString();
            bool state = (bool)table.Rows[0]["or_state"];
            if (state)
                ComboBoxState.SelectedIndex = 1;
            else
                ComboBoxState.SelectedIndex = 0;
            DataTable userData= UsersServices.GetThisUser(table.Rows[0]["or_user_owner"].ToString());
            TextBoxUsuario.Text = userData.Rows[0]["us_name"].ToString() + " " + userData.Rows[0]["us_paterno"].ToString() + " " + userData.Rows[0]["us_materno"].ToString();

        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            TerminarSesion();
        }

        private void TerminarSesion()
        {
            SessionData.CurrentUser = -1;
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void ButtonClean_Click(object sender, RoutedEventArgs e)
        {
            cleanSpaces();
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = OrdersServices.FindThisOrder(TBSClientName.Text,TBSProduct.Text,DPSDate.Text);
            DataGridOrders.ItemsSource = table.DefaultView;
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            ShowAllOrders();
        }

        private void ButtonUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UserView user = new UserView();
            user.Show();
            
        }

        private void TextBoxPrecio_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (float.Parse(TextBoxPrecio.Text) >= float.Parse(TextBoxAnticipe.Text))
                {
                    calcMoney();
                }
                else
                {
                    TextBoxAnticipe.Text = "0.00";
                    TextBoxSaldo.Text = "0.00";
                    TextBoxAlert.Text = "Saldo superior al precio";
                }

            }
            catch (Exception)
            {


            }
            
        }

        private void TextBoxAnticipe_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPrecio.Text != "" && TextBoxAnticipe.Text != "")
            {


                if (float.Parse(TextBoxPrecio.Text) >= float.Parse(TextBoxAnticipe.Text))
                {
                    calcMoney();
                }
                else
                {
                    TextBoxAnticipe.Text = "0.00";
                    TextBoxSaldo.Text = "0.00";
                    TextBoxAlert.Text = "Saldo superior al precio";
                }
            }
        }

        private void ButtonAddCoti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? date = new DateTime?();
                date = DatePickerDateCoti.SelectedDate;
                QuotesServices.InsertQuote(date, TextBoxNameCoti.Text, TextBoxPhoneCoti.Text, TextBoxDetalle.Text, TextBoxPrecioCoti.Text, TextBoxProveedor.Text);
                TextBlockMessage.Text = "Guardado con exito...";
                cleanSpacesCoti();
                ShowAllQuotes();
            }
            catch (Exception)
            {


            }
        }

        private void cleanSpacesCoti()
        {
            DatePickerDateCoti.SelectedDate = DateTime.Now;
            TextBoxNameCoti.Text = "";
            TextBoxPhoneCoti.Text = "";
            TextBoxDetalle.Text = "";
            TextBoxPrecioCoti.Text = "0.00";
            TextBoxNumeroCoti.Text = "";
            ButtonUpdateCoti.IsEnabled = false;
            TextBoxUsuarioCoti.Text = "";
            currentItemSelectedCoti = -1;
        }

        private void DataGridQuotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView r = (DataRowView)DataGridQuotes.SelectedItem;
                currentItemSelectedCoti = int.Parse(r["qu_quote"].ToString());
                SessionData.selectedQuoteToReport = currentItemSelectedCoti.ToString();
                fillSpacesQuote();
                if (!isMaster)
                {
                    if (r["qu_user_owner"].ToString() == SessionData.CurrentUser.ToString())
                    {
                        ButtonUpdateCoti.IsEnabled = true;
                    }
                    else
                    {
                        ButtonUpdateCoti.IsEnabled = false;
                    }
                }
                else
                {
                    ButtonUpdateCoti.IsEnabled = true;
                }


            }
            catch (Exception)
            {


            }
        }

        private void fillSpacesQuote()
        {
            DataTable table = QuotesServices.GetThisQuote(currentItemSelectedCoti);
            DatePickerDateCoti.SelectedDate = table.Rows[0]["qu_date"] as DateTime?;
            TextBoxNameCoti.Text = table.Rows[0]["qu_client_name"].ToString();
            TextBoxPhoneCoti.Text = table.Rows[0]["qu_phone"].ToString();
            TextBoxDetalle.Text = table.Rows[0]["qu_detail"].ToString();
            TextBoxPrecioCoti.Text = table.Rows[0]["qu_price"].ToString();
            TextBoxProveedor.Text = table.Rows[0]["qu_supplier"].ToString();
            TextBoxNumeroCoti.Text = table.Rows[0]["qu_quote"].ToString();
            DataTable userData = UsersServices.GetThisUser(table.Rows[0]["qu_user_owner"].ToString());
            TextBoxUsuarioCoti.Text = userData.Rows[0]["us_name"].ToString() + " " + userData.Rows[0]["us_paterno"].ToString() + " " + userData.Rows[0]["us_materno"].ToString();

        }

        private void ButtonDeleteCoti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QuotesServices.DeleteThisQuote(currentItemSelectedCoti);
                cleanSpacesCoti();
                ShowAllQuotes();
                TextBlockMessage.Text = "Eliminado con exito...";
            }
            catch (Exception)
            {
                TextBlockMessage.Text = "No se pudo Elminar...";

            }
        }

        private void TextBoxPrecioCoti_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !isTextAllowed(e.Text);
        }

        private void ButtonUpdateCoti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? date = new DateTime?();
                date = DatePickerDateCoti.SelectedDate;
                

                QuotesServices.UpdateThisQuote(date, TextBoxNameCoti.Text, TextBoxPhoneCoti.Text, TextBoxDetalle.Text, TextBoxPrecioCoti.Text, TextBoxProveedor.Text, currentItemSelectedCoti);
                TextBlockMessage.Text = "Actualizado con exito...";
                cleanSpacesCoti();
                ShowAllQuotes();

            }
            catch (Exception)
            {
                TextBlockMessage.Text = "Ha Ocurrido un error...";

            }
        }

        private void ButtonCleanCoti_Click(object sender, RoutedEventArgs e)
        {
            cleanSpacesCoti();
        }

        private void ButtonBuscarCoti_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = QuotesServices.FindThisQuote(TBSClientNameCoti.Text, DPSDateCoti.Text);
            DataGridQuotes.ItemsSource = table.DefaultView;
        }

        private void ButtonShowAllCoti_Click(object sender, RoutedEventArgs e)
        {
            ShowAllQuotes();
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            Window1 a = new Window1();
            a.Show();
        }

        private void ButtonReportCoti_Click(object sender, RoutedEventArgs e)
        {
            QuoteReportWindow a = new QuoteReportWindow();
            a.Show();
        }

    }
}
