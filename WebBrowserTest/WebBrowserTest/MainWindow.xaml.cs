using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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

namespace WebBrowserTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Lib\\IETools.dll")]
        static extern void InitializeIE();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //InitializeIE();
            var name = Assembly.GetExecutingAssembly().Location;
            var f = new FileInfo(name);
            var html = System.IO.Path.Combine(f.DirectoryName, "Main.html");

            browser.ObjectForScripting=new HostObject();
            browser.Navigate(html);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            browser.InvokeScript("testfunc");
        }
    }

    [ComVisible(true)]
    public class HostObject
    {
        public HostObject()
        {
            Teststring = "Testvalue";
        }

        public string Teststring { get; set; }
        public void TestFunction()
        {
            MessageBox.Show("Testfunction in host");
        }
    }
}
