using Obligatorisk_Opgave1.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Obligatorisk_Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel model = new MainViewModel();

        public MainWindow()
        {
            DataContext = model;
            model.CallFailed += delegate(Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
            InitializeComponent();
        }
    }
}
