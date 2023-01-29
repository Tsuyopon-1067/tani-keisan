using System.Windows;
using System.Windows.Controls;

namespace tani_keisan
{
    /// <summary>
    /// CreditInput.xaml の相互作用ロジック
    /// </summary>
    public partial class CreditInput : UserControl
    {
        /// <summary>
        /// TextBlock（左側）を変更するメソッド
        /// </summary>
        public string Text
        {
            get { return tb.Text; }
            set { tb.Text = value; }
        }

        /// <summary>
        /// TextBox（右側）を変更するメソッド
        /// </summary>
        public int Number
        {
            get
            {
                int tmp = 0;
                int.TryParse(input.Text, out tmp);
                return tmp;
            }
            set
            {
                input.Text = value.ToString();
            }
        }
        public CreditInput()
        {
            InitializeComponent();
            tb.DataContext = Text;
            input.DataContext = Number.ToString();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            int tmp = 0;
            int.TryParse(input.Text, out tmp);
            Number = tmp;
        }
    }
}
