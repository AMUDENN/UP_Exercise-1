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
        public static int accuracy = 0;
        public Menu()
        {
            InitializeComponent();
            accuracy_slyder.Value = accuracy;
            MainWindow.Change_Title("Меню 2ПКС-220 Демьянов Артём");
            Accuracy_Print();
        }
        private void Change_Light_Theme(object sender, RoutedEventArgs e)
        {
            MainWindow.Change_Theme("Light");
        }
        private void Change_Dark_Theme(object sender, RoutedEventArgs e)
        {
            MainWindow.Change_Theme("Dark");
        }

        private void Accuracy_Print()
        {
            print_accuracy.Content = $"Точность: {accuracy}"; 
        }

        private void Accuracy_Slyder_Change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            accuracy = (int)e.NewValue;
            Accuracy_Print();
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
