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

namespace tani_keisan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Change_Pos(object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            double ScreenWidth = SystemParameters.WorkArea.Width;
            double ScreenHeight = SystemParameters.WorkArea.Height;
            switch (item.Header.ToString())
            {
                case "右上":
                    this.Top = 0;
                    this.Left = ScreenWidth - this.Width;
                    break;
                case "左上":
                    this.Top = 0;
                    this.Left = 0;
                    break;
                case "右下":
                    this.Top = ScreenHeight;
                    this.Left = ScreenWidth - this.Width;
                    break;
                case "左下":
                    this.Top = ScreenHeight;
                    this.Left = 0;
                    break;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
