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

namespace NS_OrdersSystem
{
    /// <summary>
    /// Interaction logic for QuoteReportWindow.xaml
    /// </summary>
    public partial class QuoteReportWindow : Window
    {
        public QuoteReportWindow()
        {
            InitializeComponent();
            Loaded += QuoteReportWindow_Loaded;
        }

        void QuoteReportWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1 ds = Services.QuotesServices.FindThisQuoteToReport(Data.SessionData.selectedQuoteToReport);
            QuoteReport objrpt = new QuoteReport();
            objrpt.SetDataSource(ds.Tables[1]);
            this.crystalReportsViewer1.ViewerCore.ReportSource = objrpt;

        }

    }
}
