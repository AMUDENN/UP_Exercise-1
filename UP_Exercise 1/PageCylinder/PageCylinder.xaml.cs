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
    public partial class Cylinder : Page
    {
        public Cylinder()
        {
            InitializeComponent();
            accuracy_slyder.Value = Menu.accuracy;
            MainWindow.Change_Title("Цилиндр");
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
            Exception[] ex = new Exception[2];
            ex[0] = ExceptionFunctions.Ex_Double(cylinder_radius.Text, "\"R\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(cylinder_height.Text, "\"H\"", 0);
            if (ex[0] == null && ex[1] == null)
            {
                Cylinder_calc_Click(sender, e);
            }
        }
        private void Cylinder_calc_Click(object sender, RoutedEventArgs e)
        {
            Exception[] ex = new Exception[2];
            ex[0] = ExceptionFunctions.Ex_Double(cylinder_radius.Text, "\"R\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(cylinder_height.Text, "\"H\"", 0);

            if (ex[0] == null && ex[1] == null)
            {
                double radius = Convert.ToDouble(cylinder_radius.Text);
                double height = Convert.ToDouble(cylinder_height.Text);
                int accuracy = Menu.accuracy;
                try
                {
                    double square_foundation = Math.PI * Math.Pow(radius, 2);
                    double square_side = 2 * Math.PI * radius * height;
                    cylinder_square_foundation.Text = Convert.ToString(Math.Round(square_foundation, accuracy));
                    cylinder_square_side.Text = Convert.ToString(Math.Round(square_side, accuracy));
                    cylinder_square_total.Text = Convert.ToString(Math.Round(2 * square_foundation + square_side, accuracy));
                    cylinder_volume.Text = Convert.ToString(Math.Round(square_foundation * height, accuracy));
                }
                catch { }
            }
            else
            {
                string OutMessage = "Список ошибок: \n";
                for (int i = 0; i < ex.Length; i++)
                {
                    if (ex[i] != null)
                    {
                        OutMessage += ex[i].Message + "\n";
                    }
                }
                MessageBox.Show(OutMessage, "Ошибки", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Cylinder_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
