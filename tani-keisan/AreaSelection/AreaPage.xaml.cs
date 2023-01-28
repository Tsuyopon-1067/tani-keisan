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
    /// Area.xaml の相互作用ロジック
    /// </summary>
    // 地方を選択するページ
    public partial class Area : Page
    {
        private AreaSelectorMain mainWindow;
        public Area(AreaSelectorMain mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        // 地方名の列挙型
        enum Areas
        {
            Hokkaido,
            Tohoku,
            Kanto,
            Chubu,
            Kinki,
            Chugoku,
            Shikoku,
            Kyushu
        }
        // 押されたボタンのContent<strin>から地方名の列挙型に変換するmap
        static Dictionary<string, Areas> areaNameToNum
            = new Dictionary<string, Areas> {
                { "hokkaido", Areas.Hokkaido } ,
                { "tohoku", Areas.Tohoku } ,
                { "kanto", Areas.Kanto } ,
                { "chubu", Areas.Chubu } ,
                { "kinki", Areas.Kinki } ,
                { "chugoku", Areas.Chugoku } ,
                { "shikoku", Areas.Shikoku } ,
                { "kyushu", Areas.Kyushu }
            };

        /// <summary>
        /// 地方選択ボタンが押されたときに呼び出されるメソッド
        /// </summary>
        /// <param name="sender">object型だがButtonのみを受け取る前提</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string str = (string)btn.Content;
                Areas area = areaNameToNum[str];
                int n = (int)area;
                AreaSelection.PrefecturePage p 
                    = new AreaSelection.PrefecturePage(mainWindow, AreaSelection.AreaInformation.prefecture[n]);
                mainWindow.contentFrame.Navigate(p);
            }
        }
    }
}
