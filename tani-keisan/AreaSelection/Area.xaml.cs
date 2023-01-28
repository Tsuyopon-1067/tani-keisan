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
    public partial class Area : Page
    {
        public Area(Frame f)
        {
            InitializeComponent();
            contentFrame = f;
        }
        private Frame contentFrame;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string str = (string)btn.Content;
                Areas tmp = areaNameToNum[str];
                switch (tmp)
                {
                    case Areas.Hokkaido:
                        break;
                    case Areas.Tohoku:
                        {
                        }
                        break;
                    case Areas.Kanto:
                        break;
                    case Areas.Chubu:
                        break;
                    case Areas.Kinki:
                        break;
                    case Areas.Chugoku:
                        break;
                    case Areas.Shikoku:
                        break;
                    case Areas.Kyushu:
                        break;
                }
            }
        }
    }
}
