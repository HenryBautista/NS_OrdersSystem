using CrystalDecisions.CrystalReports.Engine;
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
using CrystalDecisions.Shared;
using NS_OrdersSystem.Services;
namespace NS_OrdersSystem
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Loaded += Window1_Loaded;    
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1 ds = Services.OrdersServices.FindThisOrderToReport(Data.SessionData.selectedToReport);
            CrystalReport1 objrpt = new CrystalReport1();
            objrpt.SetDataSource(ds.Tables[0]);
            this.crystalReportsViewer1.ViewerCore.ReportSource = objrpt;
            
        }

        
    }
}
