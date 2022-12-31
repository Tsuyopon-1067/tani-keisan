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
    /// <remarks>
    /// 静的クラスにしてメイン画面から読む，画面遷移先から書き込めるようにする
    /// </remarks>
    public static class DisplayedCredit
    {
        // Application settingsの値で初期化する
        static int kyouyouA; // 教養A取得単位
        static int kyouyouAAll; // 教養A必要単位
        static int kyouyouB;
        static int kyouyouBAll;
        static int gakusaiA;
        static int gakusaiAAll;
        static int kyouyouSum;
        static int kyouyouSumAll;
        static int specialA; // 専門必修取得単位
        static int specialAAll;
        static int specialB; // 専門選択必修取得単位
        static int specialBAll;
        static int specialC; // 専門選択取得単位
        static int specialCAll;
        static int specialSum;
        static int specialSumAll;
        static int specialFree;
        static int specialFreeAll;
        static int sum;
        static int sumAll;
    }
}
