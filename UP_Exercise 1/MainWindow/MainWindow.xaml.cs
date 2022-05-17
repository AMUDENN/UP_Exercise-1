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
        public static void Change_Theme(string theme) {
            ResourceDictionary style = new ResourceDictionary();
            if(theme == "Light")
            {
                style = Application.Current.Resources.MergedDictionaries[1];
            }
            else if (theme == "Dark")
            {
                style = Application.Current.Resources.MergedDictionaries[0];
            }
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(style);
        }

        public static void Change_Title(string title)
        {
            Application.Current.MainWindow.Title = title;
        }
        public static void Main_Menu_Back(Page ths)
        {
            ths.NavigationService.Navigate(new Menu());
        }
        public static void Main_Exit_Click()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
