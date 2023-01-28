using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tani_keisan.AreaSelection
{
    // 地方の情報
    // 都道府県を持つ
    public class AreaInformation
    {
        public static PrefectureInformation[][] prefecture = new PrefectureInformation[][]
        {
            new PrefectureInformation[] { AreaInformationElement.hokkaido},
            new PrefectureInformation[]
            {
                AreaInformationElement.aomori,
                AreaInformationElement.iwate,
                AreaInformationElement.miyagi,
                AreaInformationElement.akita,
                AreaInformationElement.yamagata,
                AreaInformationElement.fukushima,
            },
            new PrefectureInformation[]
            {
                AreaInformationElement.ibaraki,
                AreaInformationElement.tochigi,
                AreaInformationElement.gunma,
                AreaInformationElement.saitama,
                AreaInformationElement.chiba,
                AreaInformationElement.tokyo,
                AreaInformationElement.kanagawa,
            },
            new PrefectureInformation[]
            {
                AreaInformationElement.nigata,
                AreaInformationElement.toyama,
                AreaInformationElement.ishikawa,
                AreaInformationElement.fukui,
                AreaInformationElement.yamanashi,
                AreaInformationElement.nagano,
                AreaInformationElement.gifu,
                AreaInformationElement.shizuoka,
                AreaInformationElement.aichi,
                AreaInformationElement.mie,
            },
            new PrefectureInformation[]
            {
                AreaInformationElement.mie,
                AreaInformationElement.siga,
                AreaInformationElement.kyoto,
                AreaInformationElement.osaka,
                AreaInformationElement.hyogo,
                AreaInformationElement.nara,
                AreaInformationElement.wakayama,
            },
            new PrefectureInformation[]
            {
                AreaInformationElement.tottori,
                AreaInformationElement.shimane,
                AreaInformationElement.okayama,
                AreaInformationElement.hiroshima,
                AreaInformationElement.yamaguchi,
            },
            new PrefectureInformation[]
            {
                AreaInformationElement.tokushima,
                AreaInformationElement.kagawa,
                AreaInformationElement.ehime,
                AreaInformationElement.kochi,
            },
            new PrefectureInformation[]
            {
                AreaInformationElement.fukuoka,
                AreaInformationElement.saga,
                AreaInformationElement.nagasaki,
                AreaInformationElement.kumamoto,
                AreaInformationElement.ooita,
                AreaInformationElement.miyazaki,
                AreaInformationElement.kagoshima,
                AreaInformationElement.okinawa,
            },
        };
    }
    public class AreaInformationElement
    {
        // 以下で都道府県情報を定義していく
        // 都道府県の名前，関連付ける市町村List
        public static PrefectureInformation hokkaido { get; } = new PrefectureInformation("北海道", PrefectureInformation.hokkaidoTown);
        public static PrefectureInformation aomori { get; } = new PrefectureInformation("青森", PrefectureInformation.aomoriTown);
        public static PrefectureInformation iwate { get; } = new PrefectureInformation("岩手", PrefectureInformation.iwateTown);
        public static PrefectureInformation miyagi { get; } = new PrefectureInformation("宮城", PrefectureInformation.miyagiTown);
        public static PrefectureInformation akita { get; } = new PrefectureInformation("秋田", PrefectureInformation.akitaTown);
        public static PrefectureInformation yamagata { get; } = new PrefectureInformation("山形", PrefectureInformation.yamagataTown);
        public static PrefectureInformation fukushima { get; } = new PrefectureInformation("福島", PrefectureInformation.fukushimaTown);
        public static PrefectureInformation ibaraki { get; } = new PrefectureInformation("茨城", PrefectureInformation.ibarakiTown);
        public static PrefectureInformation tochigi { get; } = new PrefectureInformation("栃木", PrefectureInformation.tochigiTown);
        public static PrefectureInformation gunma { get; } = new PrefectureInformation("群馬", PrefectureInformation.gunmaTown);
        public static PrefectureInformation saitama { get; } = new PrefectureInformation("埼玉", PrefectureInformation.saitamaTown);
        public static PrefectureInformation chiba { get; } = new PrefectureInformation("千葉", PrefectureInformation.chibaTown);
        public static PrefectureInformation tokyo { get; } = new PrefectureInformation("東京", PrefectureInformation.tokyoTown);
        public static PrefectureInformation kanagawa { get; } = new PrefectureInformation("神奈川", PrefectureInformation.kanagawaTown);
        public static PrefectureInformation nigata { get; } = new PrefectureInformation("新潟", PrefectureInformation.nigataTown);
        public static PrefectureInformation toyama { get; } = new PrefectureInformation("富山", PrefectureInformation.toyamaTown);
        public static PrefectureInformation ishikawa { get; } = new PrefectureInformation("石川", PrefectureInformation.ishikawaTown);
        public static PrefectureInformation fukui { get; } = new PrefectureInformation("福井", PrefectureInformation.fukuiTown);
        public static PrefectureInformation yamanashi { get; } = new PrefectureInformation("山梨", PrefectureInformation.yamanashiTown);
        public static PrefectureInformation nagano { get; } = new PrefectureInformation("長野", PrefectureInformation.naganoTown);
        public static PrefectureInformation gifu { get; } = new PrefectureInformation("岐阜", PrefectureInformation.gifuTown);
        public static PrefectureInformation shizuoka { get; } = new PrefectureInformation("静岡", PrefectureInformation.shizuokaTown);
        public static PrefectureInformation aichi { get; } = new PrefectureInformation("愛知", PrefectureInformation.aichiTown);
        public static PrefectureInformation mie { get; } = new PrefectureInformation("三重", PrefectureInformation.mieTown);
        public static PrefectureInformation shiga { get; } = new PrefectureInformation("滋賀", PrefectureInformation.shigaTown);
        public static PrefectureInformation kyoto { get; } = new PrefectureInformation("京都", PrefectureInformation.kyotoTown);
        public static PrefectureInformation osaka { get; } = new PrefectureInformation("大阪", PrefectureInformation.osakaTown);
        public static PrefectureInformation hyogo { get; } = new PrefectureInformation("兵庫", PrefectureInformation.hyogoTown);
        public static PrefectureInformation nara { get; } = new PrefectureInformation("奈良", PrefectureInformation.naraTown);
        public static PrefectureInformation wakayama { get; } = new PrefectureInformation("和歌山", PrefectureInformation.wakayamaTown);
        public static PrefectureInformation tottori { get; } = new PrefectureInformation("鳥取", PrefectureInformation.tottoriTown);
        public static PrefectureInformation shimane { get; } = new PrefectureInformation("島根", PrefectureInformation.shimaneTown);
        public static PrefectureInformation okayama { get; } = new PrefectureInformation("岡山", PrefectureInformation.okayamaTown);
        public static PrefectureInformation hiroshima { get; } = new PrefectureInformation("広島", PrefectureInformation.hiroshimaTown);
        public static PrefectureInformation yamaguchi { get; } = new PrefectureInformation("山口", PrefectureInformation.yamaguchiTown);
        public static PrefectureInformation tokushima { get; } = new PrefectureInformation("徳島", PrefectureInformation.tokushimaTown);
        public static PrefectureInformation kagawa { get; } = new PrefectureInformation("香川", PrefectureInformation.kagawaTown);
        public static PrefectureInformation ehime { get; } = new PrefectureInformation("愛媛", PrefectureInformation.ehimeTown);
        public static PrefectureInformation kochi { get; } = new PrefectureInformation("高知", PrefectureInformation.kochiTown);
        public static PrefectureInformation fukuoka { get; } = new PrefectureInformation("福岡", PrefectureInformation.fukuokaTown);
        public static PrefectureInformation saga { get; } = new PrefectureInformation("佐賀", PrefectureInformation.sagaTown);
        public static PrefectureInformation nagasaki { get; } = new PrefectureInformation("長崎", PrefectureInformation.nagasakiTown);
        public static PrefectureInformation kumamoto { get; } = new PrefectureInformation("熊本", PrefectureInformation.kumamotoTown);
        public static PrefectureInformation ooita { get; } = new PrefectureInformation("大分", PrefectureInformation.ooitaTown);
        public static PrefectureInformation miyazaki { get; } = new PrefectureInformation("宮崎", PrefectureInformation.miyazakiTown);
        public static PrefectureInformation kagoshima { get; } = new PrefectureInformation("鹿児島", PrefectureInformation.kagoshimaTown);
        public static PrefectureInformation okinawa { get; } = new PrefectureInformation("沖縄", PrefectureInformation.okinawaTown);
    }
    public class PrefectureInformation
    {
        public PrefectureInformation(string name, List<TownInformation> town)
        {
            this.name = name;
            this.town = town;
        }
        string name;
        List<TownInformation> town;
        // 以下で頑張って市町村情報を定義していく
        public static List<TownInformation> hokkaidoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("稚内", "1a/1100"),
            new TownInformation("釧路", "1c/1900"),
            new TownInformation("根室", "1c/1800"),
            new TownInformation("根室", "1d/2300"),
            new TownInformation("札幌", "1b/1400"),
            new TownInformation("旭川", "1a/1200"),
            new TownInformation("函館", "1d/2300"),
        };
        public static List<TownInformation> aomoriTown { get; } = new List<TownInformation>()
        {
            new TownInformation("青森", "2/3110"),
        };
        public static List<TownInformation> iwateTown { get; } = new List<TownInformation>()
        {
            new TownInformation("盛岡", "3/3310"),
        };
        public static List<TownInformation> miyagiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("仙台", "4/3410"),
        };
        public static List<TownInformation> akitaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("秋田", "5/3210"),
        };
        public static List<TownInformation> yamagataTown { get; } = new List<TownInformation>()
        {
            new TownInformation("山形", "6/3510"),
        };
        public static List<TownInformation> fukushimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("福島", "7/3610"),
        };
        public static List<TownInformation> ibarakiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("水戸", "8/4010"),
        };
        public static List<TownInformation> tochigiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("宇都宮", "9/4110"),
        };
        public static List<TownInformation> gunmaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("前橋", "10/4210"),
        };
        public static List<TownInformation> saitamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("さいたま", "11/4310"),
        };
        public static List<TownInformation> chibaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("千葉", "12/4510"),
        };
        public static List<TownInformation> tokyoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("東京", "13/4410"),
        };
        public static List<TownInformation> kanagawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("横浜", "14/4610"),
        };
        public static List<TownInformation> nigataTown { get; } = new List<TownInformation>()
        {
            new TownInformation("新潟", "15/5410"),
        };
        public static List<TownInformation> toyamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("富山", "16/5510"),
        };
        public static List<TownInformation> ishikawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("金沢", "17/5610"),
        };
        public static List<TownInformation> fukuiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("福井", "18/5710"),
        };
        public static List<TownInformation> yamanashiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("甲府", "19/4910"),
        };
        public static List<TownInformation> naganoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("長野", "20/4810"),
        };
        public static List<TownInformation> gifuTown { get; } = new List<TownInformation>()
        {
            new TownInformation("岐阜", "21/5210"),
        };
        public static List<TownInformation> shizuokaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("静岡", "22/5010"),
        };
        public static List<TownInformation> aichiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("名古屋", "23/5110"),
        };
        public static List<TownInformation> mieTown { get; } = new List<TownInformation>()
        {
            new TownInformation("三重", "24/5310"),
        };
        public static List<TownInformation> shigaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("大津", "25/6010"),
        };
        public static List<TownInformation> kyotoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("京都", "26/6110"),
        };
        public static List<TownInformation> osakaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("大阪", "27/6200"),
        };
        public static List<TownInformation> hyogoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("神戸", "28/6310"),
        };
        public static List<TownInformation> naraTown { get; } = new List<TownInformation>()
        {
            new TownInformation("奈良", "29/6410"),
        };
        public static List<TownInformation> wakayamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("和歌山", "30/6510"),
        };
        public static List<TownInformation> tottoriTown { get; } = new List<TownInformation>()
        {
            new TownInformation("鳥取", "31/6910"),
        };
        public static List<TownInformation> shimaneTown { get; } = new List<TownInformation>()
        {
            new TownInformation("松江", "32/6810"),
        };
        public static List<TownInformation> okayamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("岡山", "33/6610"),
        };
        public static List<TownInformation> hiroshimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("広島", "34/6710"),
        };
        public static List<TownInformation> yamaguchiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("山口", "35/8120"),
        };
        public static List<TownInformation> tokushimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("徳島", "36/7110"),
        };
        public static List<TownInformation> kagawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("高松", "37/7200"),
        };
        public static List<TownInformation> ehimeTown { get; } = new List<TownInformation>()
        {
            new TownInformation("松山", "38/7310"),
        };
        public static List<TownInformation> kochiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("高知", "39/7410"),
        };
        public static List<TownInformation> fukuokaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("福岡", "40/8210"),
        };
        public static List<TownInformation> sagaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("佐賀", "41/8510"),
        };
        public static List<TownInformation> nagasakiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("長崎", "42/8410"),
        };
        public static List<TownInformation> kumamotoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("熊本", "43/8610"),
        };
        public static List<TownInformation> ooitaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("大分", "44/8310"),
        };
        public static List<TownInformation> miyazakiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("宮崎", "45/8710"),
        };
        public static List<TownInformation> kagoshimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("鹿児島", "46/8810"),
        };
        public static List<TownInformation> okinawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("那覇", "47/9110"),
        };
    }
    public class TownInformation
    {
        public TownInformation(string name, string url)
        {
            this.name = name;
            this.url = url;
        }
        string name;
        string url;
    }
}
