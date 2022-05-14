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
            MainWindow.Change_Title("Сфера");
        }

        private void Sphere_calc_Click(object sender, RoutedEventArgs e)
        {
            Exception[] ex = new Exception[2];
            ex[0] = ExceptionFunctions.Ex_Double(sphere_radius.Text,"\"R\"", 0);
            ex[1] = ExceptionFunctions.Ex_Int(sphere_accuracy.Text, "\"Точность\"", 0, 15);


            if (ex[0] == null && ex[1] == null)
            {

                double radius = Convert.ToDouble(sphere_radius.Text);
                int accuracy = Convert.ToInt32(sphere_accuracy.Text);
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
                sphere_volume.Text = "Введите корректные значения";
                sphere_square.Text = "Введите корректные значения";
            }

        }
        private void Sphere_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.Main_Menu_Back(this);
        }
    }
}
