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
            MainWindow.Change_Title("Усечённый конус");
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
                    double square_first = Math.Round(Math.PI * Math.Pow(radius_top, 2), accuracy);
                    double square_second = Math.Round(Math.PI * Math.Pow(radius_bottom, 2), accuracy);
                    double square_side = Math.Round(Math.PI * l * (radius_top + radius_bottom), accuracy);
                    truncatedcone_square_top.Text = Convert.ToString(square_first);
                    truncatedcone_square_bottom.Text = Convert.ToString(square_second);
                    truncatedcone_square_side.Text = Convert.ToString(square_side);
                    truncatedcone_square_total.Text = Convert.ToString(square_first + square_second + square_side);
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
                truncatedcone_square_top.Text = "Введите корректные значения";
                truncatedcone_square_bottom.Text = "Введите корректные значения";
                truncatedcone_square_side.Text = "Введите корректные значения";
                truncatedcone_square_total.Text = "Введите корректные значения";
                truncatedcone_volume.Text = "Введите корректные значения";
            }
        }
        private void Truncatedcone_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
