using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tani_keisan
{
    /// <summary>
    /// メイン画面で表示されている単位情報を保存するクラス
    /// </summary>
    public class DisplayedCredit
    {
        // Application settingsの値で初期化する
        public int kyouyouA { get; set; } // 教養A取得単位
        public int kyouyouAAll { get; set; } // 教養A必要単位
        public int kyouyouB { get; set; }
        public int kyouyouBAll { get; set; }
        public int gakusaiA { get; set; }
        public int gakusaiAAll { get; set; }
        public int kyouyouSum { get; set; }
        public int kyouyouSumAll { get; set; }
        public int specialA { get; set; } // 専門必修取得単位
        public int specialAAll { get; set; }
        public int specialB { get; set; } // 専門選択必修取得単位
        public int specialBAll { get; set; }
        public int specialC { get; set; } // 専門選択取得単位
        public int specialCAll { get; set; }
        public int specialSum { get; set; }
        public int specialSumAll { get; set; }
        public int specialFree { get; set; }
        public int specialFreeAll { get; set; }
        public int sum { get; set; }
        public int sumAll { get; set; }
    }
}
