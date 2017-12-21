using Example._2_BLL;
using Example._2_BLL.ProxyContainer;
using Example.RSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            LogHelper.Execute(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    //ProxyResourceHelper.SearchResources("proxylist", "txt");
                    //ProxyResourceHelper.ExecuteAll();
                    //Thread.Sleep(60000);
                    AIHelper.Execute();
                });
            });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogHelper.Execute(() =>
            {
                myGrid.ItemsSource = Data.AvitoItems.ToArray();
                myProxyGrid.ItemsSource = Data.ProxyObjects.ToArray();
                textAvitoCount.Text = Data.AvitoItems.Count.ToString();
                textProxyCount.Text = Data.ProxyObjects.Count.ToString();
                textProxyResCount.Text = Data.ProxyResources.Count.ToString();
                textAvitoCheckCount.Text = Data.AvitoItems.Where(q=>q.IsChecked).Count().ToString();
            });
        }
    }
}
