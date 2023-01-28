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
using System.Windows.Shapes;

namespace tani_keisan
{
    /// <summary>
    /// AreaSelectorMain.xaml の相互作用ロジック
    /// </summary>
    public partial class AreaSelectorMain : Window
    {
        public WeatherDisplay weatherDisplay;
        public AreaSelectorMain(WeatherDisplay weatherDisplay)
        {
            InitializeComponent();
            this.weatherDisplay = weatherDisplay;
            Area area = new Area(this);
            contentFrame.Navigate(area);
        }
        
    }
}
