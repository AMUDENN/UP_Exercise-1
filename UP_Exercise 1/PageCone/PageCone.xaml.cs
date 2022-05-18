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
    public partial class Cone : Page
    {
        public Cone()
        {
            InitializeComponent();
            accuracy_slyder.Value = Menu.accuracy;
            MainWindow.Change_Title("Конус");
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
            ex[0] = ExceptionFunctions.Ex_Double(cone_radius.Text, "\"R\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(cone_height.Text, "\"H\"", 0);
            if (ex[0] == null && ex[1] == null)
            {
                Cone_calc_Click(sender, e);
            }
        }
        private void Cone_calc_Click(object sender, RoutedEventArgs e)
        {
            Exception[] ex = new Exception[2];
            ex[0] = ExceptionFunctions.Ex_Double(cone_radius.Text, "\"R\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(cone_height.Text, "\"H\"", 0);

            if (ex[0] == null && ex[1] == null)
            {
                double radius = Convert.ToDouble(cone_radius.Text);
                double height = Convert.ToDouble(cone_height.Text);
                int accuracy = Menu.accuracy;
                try
                {
                    double square_foundation = Math.Round(Math.PI * Math.Pow(radius, 2), accuracy);
                    double square_side = Math.Round(Math.PI * radius * Math.Sqrt(Math.Pow(radius, 2) + Math.Pow(height, 2)), accuracy);
                    cone_square_foundation.Text = Convert.ToString(square_foundation);
                    cone_square_side.Text = Convert.ToString(square_side);
                    cone_square_total.Text = Convert.ToString(square_foundation + square_side);
                    cone_volume.Text = Convert.ToString(Math.Round(square_foundation * height / 3, accuracy));
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
        private void Cone_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
