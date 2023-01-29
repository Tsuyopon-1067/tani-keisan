using AngleSharp.Io;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
    /// CreditResister.xaml の相互作用ロジック
    /// </summary>
    public partial class CreditResister : Window
    {
        private ObservableCollection<Credit> credits;
        private DisplayedCredit displayedCredit;
        private MainWindow mainWindow;
        public CreditResister(MainWindow mainWindow)
        {
            InitializeComponent();
            credits = Properties.SettingsSave.ReadCreditList();
            dataGrid.ItemsSource = credits;
            displayedCredit = Properties.SettingsSave.ReadDisplayedCredit();
            subjectCategoryColumn.ItemsSource = subjectCategory; // コンボボックス選択肢の登録
            SetDisplayedCredit();
            this.mainWindow = mainWindow;
        }

        /// <summary>
        /// enumの値をコンボボックスに表示する文字列に変換するディクショナリ mapみたいなやつ
        /// </summary>
        public Dictionary<SuubjectCategoryType, string> subjectCategory { get; } = new Dictionary<SuubjectCategoryType, string>
        {
            [SuubjectCategoryType.kyouyouA] = "教養(教養A)",
            [SuubjectCategoryType.kyouyouB] = "教養(教養B)",
            [SuubjectCategoryType.gakusaiA] = "教養(学際A)",
            [SuubjectCategoryType.kyouyouOther] = "教養(その他)",
            [SuubjectCategoryType.senmonA] = "専門(必修)",
            [SuubjectCategoryType.senmonB] = "専門(選択必修)",
            [SuubjectCategoryType.senmonC] = "専門(選択)",
            [SuubjectCategoryType.free] = "自由科目"
        };

        /// <summary>
        /// 単位登録ボタンが押された時に呼び出されるメソッド
        /// </summary>
        /// <param name="sender">おまじない イベントハンドラとして必要</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            credits.Add(new Credit("", 0, 0));
            dataGrid.ItemsSource = credits;
        }
        /// <summary>
        /// 登録済み単位削除ボタンが押された時に呼び出されるメソッド
        /// </summary>
        /// <param name="sender">object型だがCredit型インスタンスとして扱う このインスタンスがListの中の選択されている（削除対象である）要素</param>
        /// <param name="e">おまじない イベントハンドラとして必要</param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag as Credit;
            credits.Remove(tag);
        }

        /// <summary>
        /// 終了ボタンが押されたときに単位情報を保存して画面を閉じる
        /// </summary>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            // todo: 登録の実装
            SaveDisplayedCredit(); // このクラス内のメソッド この中でSettingsSaveが呼ばれてる
            Properties.SettingsSave.SaveCreditList(credits);

            SetDisplayedCreditToMainWindow();
            this.Close();
        }
        /// <summary>
        /// 取得したDisplayedCreditインスタンスの情報をMainWindowに反映する
        /// </summary>
        public void SetDisplayedCreditToMainWindow()
        {
            displayedCredit.kyouyouA = 0;
            displayedCredit.kyouyouB = 0;
            displayedCredit.gakusaiA = 0;
            //displayedCredit.kyouyouSum = 0; // 下で代入するから不要
            displayedCredit.specialA = 0;
            displayedCredit.specialB = 0;
            displayedCredit.specialC = 0;
            //displayedCredit.specialSum = 0; // 下で代入するから不要
            displayedCredit.free = 0;
            int kyouyouOther = 0; // DisplayCredit型にないから用意する
            // ここで各カテゴリの合計単位数を計算する
            foreach (var credit in credits)
            {
                switch (credit.category)
                {
                    case SuubjectCategoryType.kyouyouA:
                        displayedCredit.kyouyouA += credit.credit;
                        break;
                    case SuubjectCategoryType.kyouyouB:
                        displayedCredit.kyouyouB += credit.credit;
                        break;
                    case SuubjectCategoryType.gakusaiA:
                        displayedCredit.gakusaiA += credit.credit;
                        break;
                    case SuubjectCategoryType.kyouyouOther:
                        kyouyouOther += credit.credit;
                        break;
                    case SuubjectCategoryType.senmonA:
                        displayedCredit.specialA += credit.credit;
                        break;
                    case SuubjectCategoryType.senmonB:
                        displayedCredit.specialB += credit.credit;
                        break;
                    case SuubjectCategoryType.senmonC:
                        displayedCredit.specialC += credit.credit;
                        break;
                    case SuubjectCategoryType.free:
                        displayedCredit.specialC += credit.credit;
                        break;
                }
            }
            // それぞれの合計単位を求める
            displayedCredit.kyouyouSum
                = displayedCredit.kyouyouA + displayedCredit.kyouyouB + displayedCredit.gakusaiA + kyouyouOther;
            displayedCredit.specialSum
                = displayedCredit.specialA + displayedCredit.specialB + displayedCredit.specialC;
            displayedCredit.sum = displayedCredit.kyouyouSum + displayedCredit.specialSum + displayedCredit.free;

            mainWindow.dc = displayedCredit; // 表示する単位情報
            mainWindow.SetCreditInfo();
        }
        /// <summary>
        /// DisplayedCreditクラスのインスタンスから対応するテキストボックスに値を入れるメソッド
        /// </summary>
        private void SetDisplayedCredit()
        {
            kyouyouA.Number = displayedCredit.kyouyouAAll;
            kyouyouB.Number = displayedCredit.kyouyouBAll;
            gakusaiA.Number = displayedCredit.gakusaiAAll;
            kyouyouAll.Number = displayedCredit.kyouyouSumAll;
            senmonA.Number = displayedCredit.specialAAll;
            senmonB.Number = displayedCredit.specialBAll;
            senmonC.Number = displayedCredit.specialCAll;
            senmonAll.Number = displayedCredit.specialSumAll;
            free.Number = displayedCredit.freeAll;
            all.Number = displayedCredit.sumAll;
        }
        /// <summary>
        /// DisplayedCreditクラスのインスタンスに対応するテキストボックスの値を入れるメソッド
        /// </summary>
        private void SaveDisplayedCredit()
        {
            displayedCredit.kyouyouAAll = kyouyouA.Number;
            displayedCredit.kyouyouBAll = kyouyouB.Number;
            displayedCredit.gakusaiAAll = gakusaiA.Number;
            displayedCredit.kyouyouSumAll = kyouyouAll.Number;
            displayedCredit.specialAAll = senmonA.Number;
            displayedCredit.specialBAll = senmonB.Number;
            displayedCredit.specialCAll = senmonC.Number;
            displayedCredit.specialSumAll = senmonAll.Number;
            displayedCredit.freeAll = free.Number;
            displayedCredit.sumAll = all.Number;
            Properties.SettingsSave.SaveDisplayedCredit(displayedCredit);
        }
    }
}
