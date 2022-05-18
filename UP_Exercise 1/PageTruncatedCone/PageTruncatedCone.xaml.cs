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
    public partial class TruncatedCone : Page
    {
        public TruncatedCone()
        {
            InitializeComponent();
            accuracy_slyder.Value = Menu.accuracy;
            MainWindow.Change_Title("Усечённый конус");
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
            Exception[] ex = new Exception[3];
            ex[0] = ExceptionFunctions.Ex_Double(truncatedcone_radius_top.Text, "\"r\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(truncatedcone_radius_bottom.Text, "\"R\"", 0);
            ex[2] = ExceptionFunctions.Ex_Double(truncatedcone_height.Text, "\"H\"", 0);
            if (ex[0] == null && ex[1] == null && ex[2] == null)
            {
                Truncatedcone_calc_Click(sender, e);
            }
        }
        private void Truncatedcone_calc_Click(object sender, RoutedEventArgs e)
        {
            Exception[] ex = new Exception[3];
            ex[0] = ExceptionFunctions.Ex_Double(truncatedcone_radius_top.Text, "\"r\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(truncatedcone_radius_bottom.Text, "\"R\"", 0);
            ex[2] = ExceptionFunctions.Ex_Double(truncatedcone_height.Text, "\"H\"", 0);

            if (ex[0] == null && ex[1] == null && ex[2] == null)
            {
                double radius_top = Convert.ToDouble(truncatedcone_radius_top.Text);
                double radius_bottom = Convert.ToDouble(truncatedcone_radius_bottom.Text);
                double height = Convert.ToDouble(truncatedcone_height.Text);
                int accuracy = Menu.accuracy;
                try
                {
                    double l = Math.Sqrt(Math.Pow(radius_top - radius_bottom, 2) + Math.Pow(height, 2));
                    double square_first = Math.PI * Math.Pow(radius_top, 2);
                    double square_second = Math.PI * Math.Pow(radius_bottom, 2);
                    double square_side = Math.PI * l * (radius_top + radius_bottom);
                    truncatedcone_square_top.Text = Convert.ToString(Math.Round(square_first, accuracy));
                    truncatedcone_square_bottom.Text = Convert.ToString(Math.Round(square_second, accuracy));
                    truncatedcone_square_side.Text = Convert.ToString(Math.Round(square_side, accuracy));
                    truncatedcone_square_total.Text = Convert.ToString(Math.Round(square_first + square_second + square_side, accuracy));
                    truncatedcone_volume.Text = Convert.ToString(Math.Round(height * (square_first + square_second + Math.Sqrt(square_first * square_second)) / 3, accuracy));
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
        private void Truncatedcone_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
