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
            MainWindow.Change_Title("Цилиндр");
        }
        private void Cylinder_calc_Click(object sender, RoutedEventArgs e)
        {
            Exception[] ex = new Exception[3];
            ex[0] = ExceptionFunctions.Ex_Double(cylinder_radius.Text, "\"R\"", 0);
            ex[1] = ExceptionFunctions.Ex_Double(cylinder_height.Text, "\"H\"", 0);
            ex[2] = ExceptionFunctions.Ex_Int(cylinder_accuracy.Text, "\"Точность\"", 0, 15);


            if (ex[0] == null && ex[1] == null && ex[2] == null)
            {

                double radius = Convert.ToDouble(cylinder_radius.Text);
                double height = Convert.ToDouble(cylinder_height.Text);
                int accuracy = Convert.ToInt32(cylinder_accuracy.Text);
                try
                {
                    double square_foundation = Math.Round(Math.PI * Math.Pow(radius, 2), accuracy);
                    double square_side = Math.Round(2 * Math.PI * radius * height, accuracy);
                    cylinder_square_foundation.Text = Convert.ToString(square_foundation);
                    cylinder_square_side.Text = Convert.ToString(square_side);
                    cylinder_square_total.Text = Convert.ToString(2 * square_foundation + square_side);
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
                cylinder_square_foundation.Text = "Введите корректные значения";
                cylinder_square_side.Text = "Введите корректные значения";
                cylinder_square_total.Text = "Введите корректные значения";
                cylinder_volume.Text = "Введите корректные значения";
            }
        }
        private void Cylinder_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
