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
    public partial class Sphere : Page
    {
        public Sphere()
        {
            InitializeComponent();
            accuracy_slyder.Value = Menu.accuracy;
            MainWindow.Change_Title("Сфера");
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
            print_accuracy.Content = $"Точность: {Menu.accuracy}";
        }
        private void Accuracy_Slyder_Change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Menu.accuracy = (int)e.NewValue;
            Accuracy_Print();
            Exception[] ex = new Exception[1];
            ex[0] = ExceptionFunctions.Ex_Double(sphere_radius.Text, "\"R\"", 0);
            if (ex[0] == null)
            {
                Sphere_calc_Click(sender, e);
            }
        }
        private void Sphere_calc_Click(object sender, RoutedEventArgs e)
        {
            Exception[] ex = new Exception[1];
            ex[0] = ExceptionFunctions.Ex_Double(sphere_radius.Text,"\"R\"", 0);

            if (ex[0] == null)
            {
                double radius = Convert.ToDouble(sphere_radius.Text);
                int accuracy = Menu.accuracy;
                try
                {
                    sphere_volume.Text = Convert.ToString(Math.Round(4 * Math.PI * Math.Pow(radius, 3) / 3, accuracy));
                    sphere_square.Text = Convert.ToString(Math.Round(4 * Math.PI * Math.Pow(radius, 2), accuracy));
                }
                catch { }
            }
            else
            {
                string OutMessage = "Список ошибок: \n";
                for (int i = 0; i < ex.Length; i++)
                {
                    if(ex[i] != null)
                    {
                        OutMessage += ex[i].Message + "\n";
                    }
                }
                MessageBox.Show(OutMessage, "Ошибки", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Sphere_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
