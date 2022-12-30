using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = CreateTimer();

            timer.Start();

            setDate();
            moveHandle.MouseLeftButtonDown += (o, e) => DragMove(); // ウィンドウ移動ハンドルの追加
        }
        // solution : https://qiita.com/Kosen-amai/items/88b3d987b41f46ebea4b
        /// <summary>
        /// タイマー生成処理
        /// </summary>
        /// <returns>生成したタイマー</returns>
        private DispatcherTimer CreateTimer()
        {
            var t = new DispatcherTimer(DispatcherPriority.SystemIdle);

            // タイマーイベントの発生間隔を300ミリ秒に設定
            t.Interval = TimeSpan.FromMilliseconds(200);

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
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        SolidColorBrush bottomBarColor = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0x00, 0x00)); // 通常時の色(透明にしておく)
        SolidColorBrush bottomBarSelectedColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xD9, 0xB5, 0xD4)); // 選択時の色 FF D9 B5 D4
        
        // 下部のボタンにマウスが重なると色が変わる
        private void ButtomButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = bottomBarSelectedColor;
        }
        // 下部のボタンからマウスが離れると色が戻る
        private void ButtomButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = bottomBarColor;
        }

        private void OpenContextMenu(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContextMenu contextMenu = btn.ContextMenu;
            contextMenu.PlacementTarget = btn;
            contextMenu.IsOpen = true;
            e.Handled = true;
        }

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        private void ChangeWindowSize(int n)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            PostMessage(hwnd, 0xA1, (IntPtr)n, IntPtr.Zero);
        }
        private void WindowSizeLeftTop(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(13);
        }
        private void WindowSizeRightTop(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(14);
        }
        private void WindowSizeLeftBottom(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(16);
        }
        private void WindowSizeRightBottom(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(17);
        }
        private void WindowSizeLeft(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(10);
        }
        private void WindowSizeTop(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(12);
        }
        private void WindowSizeRight(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(11);
        }
        private void WindowSizeBottom(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangeWindowSize(15);
        }
    }
}
