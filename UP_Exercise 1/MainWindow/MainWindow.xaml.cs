
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Menu();
        }
        static public void Change_Title(string title)
        {
            Application.Current.MainWindow.Title = title;
        }
        static public void Main_Menu_Back(Page ths)
        {
            ths.NavigationService.Navigate(new Menu());
        }
        static public void Main_Exit_Click()
        {
            Application.Current.MainWindow.Close();
        }

        
    }
}
