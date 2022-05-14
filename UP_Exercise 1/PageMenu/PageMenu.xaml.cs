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

namespace UP_Exercise_1
{ 
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            MainWindow.Change_Title("Меню");
        }
        private void Sphere_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sphere());
        }
        private void Cone_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cone());
        }
        private void Cylinder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cylinder());
        }
        private void Truncated_cone_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TruncatedCone());
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Exit_Click();
        }
    }
}
