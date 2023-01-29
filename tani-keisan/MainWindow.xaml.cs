using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using tani_keisan.Properties;

namespace tani_keisan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// 時刻表示用タイマー
        /// </summary>
        private DispatcherTimer timer; // 時計更新に使う
        public DisplayedCredit dc; // 画面下部に表示する合計単位情報

        public MainWindow()
        {
            InitializeComponent();

            timer = CreateTimer();

            timer.Start();

            setDate();
            moveHandle.MouseLeftButtonDown += (o, e) => DragMove(); // ウィンドウ移動ハンドルの追加

            dc = SettingsSave.ReadDisplayedCredit();
            CreditResister cr = new(this);
            cr.SetDisplayedCreditToMainWindow();
        }
        // solution : https://qiita.com/Kosen-amai/items/88b3d987b41f46ebea4b
        /// <summary>
        /// タイマー生成処理
        /// </summary>
        /// <returns>生成したタイマー</returns>
        private DispatcherTimer CreateTimer()
        {
            var t = new DispatcherTimer(DispatcherPriority.SystemIdle);

            // タイマーイベントの発生間隔を100ミリ秒に設定
            t.Interval = TimeSpan.FromMilliseconds(100);

            // タイマーイベントの定義
            t.Tick += (sender, e) => {
                // タイマーイベント発生時の処理をここに書く

                // 現在の時分秒をテキストに設定
                clock.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            // 生成したタイマーを返す
            return t;
        }

        private void setDate()
        {
            var now = System.DateTime.Now;
            date.Text = now.ToString("yyyy/MM/dd");
        }


        /// <summary>
        /// ウィンドウを画面四隅（左上・右上・左下・右下）に移動するメソッド
        /// </summary>
        /// <param name="sender">object型だがMenuIteのみを受け取る前提</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>

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
                    this.Top = ScreenHeight - this.Height;
                    this.Left = ScreenWidth - this.Width;
                    break;
                case "左下":
                    this.Top = ScreenHeight - this.Height;
                    this.Left = 0;
                    break;
            }
        }
        /// <summary>
        /// アプリケーションを終了するメソッド
        /// </summary>
        /// <param name="sender">おまじない イベントハンドラとして必要</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            this.Close();
            Environment.Exit(0);
        }

        SolidColorBrush bottomBarColor = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0x00, 0x00)); // 通常時の色(透明にしておく)
        SolidColorBrush bottomBarSelectedColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xD9, 0xB5, 0xD4)); // 選択時の色 FF D9 B5 D4

        /// <summary>
        /// 下部のボタンにマウスが重なった時に色を変えるメソッド
        /// </summary>
        /// <remarks> 背景色を選択時の色に変更する </remarks>
        /// <param name="sender">おまじない イベントハンドラとして必要</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void ButtomButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = bottomBarSelectedColor;
        }
        /// <summary>
        /// 下部のボタンからマウスが離れた時に色を戻すメソッド
        /// </summary>
        /// <remarks> 背景色を透明にする </remarks>
        /// <param name="sender">おまじない イベントハンドラとして必要</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void ButtomButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = bottomBarColor;
        }

        /// <summary>
        /// 位置ボタンが左クリックされた時にコンテキストメニューを表示するメソッド
        /// </summary>
        /// <remarks> 受け取ったButtonのContextMenuのIsOpenプロパティをtrueにする </remarks>
        /// <param name="sender">object型だがButtonのみを受け取る前提</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void OpenContextMenu(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                ContextMenu contextMenu = btn.ContextMenu;
                contextMenu.PlacementTarget = btn;
                contextMenu.IsOpen = true;
                e.Handled = true;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // https://learn.microsoft.com/ja-jp/windows/win32/inputdev/wm-nchittest
        private void ChangeWindowSize(int n)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            PostMessage(hwnd, 0xA1, (IntPtr)n, IntPtr.Zero);
        }
        private void WindowSizeLeft(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(10);
        }
        private void WindowSizeRight(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(11);
        }
        private void WindowSizeTop(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(12);
        }
        private void WindowSizeLeftTop(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(13);
        }
        private void WindowSizeRightTop(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(14);
        }
        private void WindowSizeBottom(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(15);
        }
        private void WindowSizeLeftBottom(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(16);
        }
        private void WindowSizeRightBottom(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(17);
        }


        /// <summary>
        /// メイン画面下部の合計単位情報を表示するメソッド
        /// CrediResiterから呼ばれるからpublic
        /// </summary>
        public void SetCreditInfo()
        {
            /// <summary>
            /// 画面に表示するフォーマットを作るローカル関数
            /// </summary>
            /// <param name="x">取得単位</param>
            /// <param name="xAll">必要単位</param>
            /// <param name="s">単位カテゴリ名</param>
            string f(int x, int xAll, string s) => s + " " + x.ToString() + "/" + xAll.ToString();

            kyouyouA.Text = f(dc.kyouyouA, dc.kyouyouAAll, "教養A");
            kyouyouB.Text = f(dc.kyouyouB, dc.kyouyouBAll, "教養B");
            gakusaiA.Text = f(dc.gakusaiA, dc.gakusaiAAll, "学際A");
            kyouyouSum.Text = f(dc.kyouyouSum, dc.kyouyouSumAll, "教養合計");
            specialA.Text = f(dc.specialA, dc.specialAAll, "必修");
            specialB.Text = f(dc.specialB, dc.specialBAll, "選必");
            specialC.Text = f(dc.specialC, dc.specialCAll, "選択");
            specialSum.Text = f(dc.specialSum, dc.specialSumAll, "専門合計");
            creditFree.Text = f(dc.free, dc.freeAll, "自由科目");
            creditSum.Text = f(dc.sum, dc.sumAll, "合計");
        }

        /// <summary>
        /// 単位登録ボタンがクリックされた時に単位登録ウィンドウを表示するメソッド
        /// </summary>
        /// <param name="sender">おまじない イベントハンドラとして必要</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void CreditResisterButton_Click(object sender, RoutedEventArgs e)
        {
            CreditResister cr = new CreditResister(this);
            cr.Show();
        }
        /// <summary>
        /// 天気予報設定ボタンがクリックされた時に天気予報設定ウィンドウを表示するメソッド
        /// </summary>
        /// <param name="sender">おまじない イベントハンドラとして必要</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void AreaSelectorButton_Click(object sender, RoutedEventArgs e)
        {
            AreaSelectorMain ar = new AreaSelectorMain(weatherDisplay);
            ar.Show();
        }
    }
}
