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
        public CreditResister()
        {
            InitializeComponent();
            credits = new ObservableCollection<Credit>();
            subjectCategoryColumn.ItemsSource = subjectCategory;
            dataGrid.ItemsSource = credits;
        }
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

        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            credits.Add(new Credit("", 0, 0));
            dataGrid.ItemsSource = credits;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag as Credit;
            credits.Remove(tag);
        }
    }
}
