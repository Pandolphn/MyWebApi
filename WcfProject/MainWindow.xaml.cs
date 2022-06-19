using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utility.AOP;

namespace WcfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> _logger;
        public MainWindow()
        {
           
            InitializeComponent();
        }
        public MainWindow(ILogger<MainWindow> logger):this()
        {
            this._logger = logger;
            InitializeComponent();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _logger.LogInformation("测试");
        }
    }
}
