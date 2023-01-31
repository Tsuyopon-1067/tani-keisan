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

namespace tani_keisan.AreaSelection
{
    /// <summary>
    /// PrefecturePage.xaml の相互作用ロジック
    /// </summary>
    // 都道府県を選択するページ
    public partial class PrefecturePage : Page
    {
        PrefectureInformation[] lst;

        private AreaSelectorMain mainWindow;
        public PrefecturePage(AreaSelectorMain mainWindow, PrefectureInformation[] lst)
        {
            InitializeComponent();
            this.lst = lst;
            this.mainWindow = mainWindow;
            SetupPage();
        }
        private const int ROW = 7;
        /// <summary>
        /// 都道府県選択ボタンを配置するメソッド
        /// </summary>
        private void SetupPage()
        {
            int count = 0; // 今いくつ目のボタンを配置しているかを記憶する
            foreach (var item in lst)
            {
                int r = count % ROW;
                int c = count / ROW;
                Button btn = new();
                btn.Content = string.Format(item.ToString());
                Grid.SetRow(btn, r);
                Grid.SetColumn(btn, c);
                btn.Margin = new Thickness(10, 10, 10, 10);
                // クリックイベントに都道府県選択メソッドを登録する
                btn.Click += (sender, e) =>
                {
                    var town = item.town;
                    TownPage p
                        = new(mainWindow, town);
                    mainWindow.contentFrame.Navigate(p);
                };
                grid.Children.Add(btn);
                ++count;
            }
        }
    }
}
