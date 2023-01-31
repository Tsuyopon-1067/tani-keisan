using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tani_keisan.AreaSelection
{
    // 地方の情報
    // 都道府県を持つ
    /// <summary>
    /// 地方単位の情報を格納するクラス
    /// </summary>
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
                AreaInformationElement.shiga,
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
    /// <summary>
    /// 都道府県単位の情報インスタンスを格納するクラス
    /// </summary>
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
    /// <summary>
    /// 都道府県単位の情報を格納するクラス
    /// </summary>
    public class PrefectureInformation
    {
        public PrefectureInformation(string name, List<TownInformation> town)
        {
            this.name = name;
            this.town = town;
        }
        public override string ToString()
        {
            return name;
        }
        string name;
        public List<TownInformation> town;
        // 以下で頑張って市町村情報を定義していく
        public static List<TownInformation> hokkaidoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("稚内", "1a/1100"),
            new TownInformation("旭川", "1a/1200"),
            new TownInformation("留萌", "1a/1300"),
            new TownInformation("札幌", "1b/1400"),
            new TownInformation("岩見沢", "1b/1500"),
            new TownInformation("倶知安", "1b/1600"),
            new TownInformation("網走", "1c/1710"),
            new TownInformation("北見", "1c/1720"),
            new TownInformation("紋別", "1c/1730"),
            new TownInformation("根室", "1c/1800"),
            new TownInformation("釧路", "1c/1900"),
            new TownInformation("帯広", "1c/2000"),
            new TownInformation("室蘭", "1d/2100"),
            new TownInformation("浦河", "1d/2200"),
            new TownInformation("函館", "1d/2300"),
            new TownInformation("江差", "1d/2400"),
        };
        public static List<TownInformation> aomoriTown { get; } = new List<TownInformation>()
        {
            new TownInformation("青森", "2/3110"),
            new TownInformation("むつ", "2/3120"),
            new TownInformation("八戸", "2/3130"),
        };
        public static List<TownInformation> iwateTown { get; } = new List<TownInformation>()
        {
            new TownInformation("盛岡", "3/3310"),
            new TownInformation("宮古", "3/3320"),
            new TownInformation("大船渡", "3/3330"),
        };
        public static List<TownInformation> miyagiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("仙台", "4/3410"),
            new TownInformation("白石", "4/3420"),
        };
        public static List<TownInformation> akitaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("秋田", "5/3210"),
            new TownInformation("横手", "5/3220"),
        };
        public static List<TownInformation> yamagataTown { get; } = new List<TownInformation>()
        {
            new TownInformation("山形", "6/3510"),
            new TownInformation("米沢", "6/3520"),
            new TownInformation("酒田", "6/3530"),
            new TownInformation("新庄", "6/3540"),
        };
        public static List<TownInformation> fukushimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("福島", "7/3610"),
            new TownInformation("小名浜", "7/3620"),
            new TownInformation("若松", "7/3630"),
        };
        public static List<TownInformation> ibarakiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("水戸", "8/4010"),
            new TownInformation("土浦", "8/4020"),
            new TownInformation("笠間", "8/4010/8216"),
            new TownInformation("茨城", "8/4010/8302"),
            new TownInformation("日立", "8/4010/8202"),
            new TownInformation("ひたちなか", "8/4010/8221"),
            
        };
        public static List<TownInformation> tochigiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("宇都宮", "9/4110"),
            new TownInformation("大田原", "9/4120"),
        };
        public static List<TownInformation> gunmaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("前橋", "10/4210"),
            new TownInformation("みなかみ", "10/4220"),
        };
        public static List<TownInformation> saitamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("さいたま", "11/4310"),
            new TownInformation("熊谷", "11/4320"),
            new TownInformation("秩父", "11/4330"),
        };
        public static List<TownInformation> chibaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("千葉", "12/4510"),
            new TownInformation("銚子", "12/4520"),
            new TownInformation("館山", "12/4530"),
        };
        public static List<TownInformation> tokyoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("東京", "13/4410"),
            new TownInformation("大島", "13/4420"),
            new TownInformation("八丈島", "13/4430"),
            new TownInformation("父島", "13/4440"),
            new TownInformation("新宿", "13/4410/13104"),
            new TownInformation("多摩", "13/4410/13224"),
            new TownInformation("三鷹", "13/4410/13204"),
            new TownInformation("八王子", "13/4410/13201"),
        };
        public static List<TownInformation> kanagawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("横浜", "14/4610"),
            new TownInformation("小田原", "14/4620"),
            new TownInformation("川崎区", "14/4610/14131"),
            new TownInformation("横須賀", "14/4610/14201"),
            new TownInformation("鎌倉", "14/4610/14204"),
            new TownInformation("茅ヶ崎", "14/4610/14207"),
            new TownInformation("相模原", "14/4620/1415"),
            new TownInformation("海老名", "14/4610/14215"),
            new TownInformation("平塚", "14/4610/14203"),
        };
        public static List<TownInformation> nigataTown { get; } = new List<TownInformation>()
        {
            new TownInformation("新潟", "15/5410"),
            new TownInformation("長岡", "15/5420"),
            new TownInformation("高田", "15/5430"),
            new TownInformation("相川", "15.5440"),
        };
        public static List<TownInformation> toyamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("富山", "16/5510"),
            new TownInformation("伏木", "16/5520"),
        };
        public static List<TownInformation> ishikawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("金沢", "17/5610"),
            new TownInformation("輪島", "17/5620"),
        };
        public static List<TownInformation> fukuiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("福井", "18/5710"),
            new TownInformation("敦賀", "18/5720")
        };
        public static List<TownInformation> yamanashiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("甲府", "19/4910"),
            new TownInformation("河口湖", "19/4920"),
        };
        public static List<TownInformation> naganoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("長野", "20/4810"),
            new TownInformation("松本", "20/4820"),
            new TownInformation("飯田", "20/4830"),
        };
        public static List<TownInformation> gifuTown { get; } = new List<TownInformation>()
        {
            new TownInformation("岐阜", "21/5210"),
            new TownInformation("高山", "21/5220"),
            new TownInformation("大垣", "21/5210/21202"),
            new TownInformation("高山", "21/5220/21203"),
            new TownInformation("多治見", "21/5210/21204"),
            new TownInformation("関", "21/5210/21205"),
            new TownInformation("各務原", "21/5210/21213"),
        };
        public static List<TownInformation> shizuokaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("静岡", "22/5010"),
            new TownInformation("綱代", "22/5020"),
            new TownInformation("三島", "22/5030"),
            new TownInformation("浜松", "22/5040"),
            new TownInformation("島田", "22/5010/22209"),
            new TownInformation("藤枝", "22/5010/22214"),
            new TownInformation("熱海", "22/5020/22205"),
            new TownInformation("沼津", "22/5030/22203"),
            new TownInformation("富士宮", "22/5030/22207"),
            new TownInformation("富士", "22/5030/22210"),
            new TownInformation("焼津", "22/5040/22212"),
            new TownInformation("掛川", "22/5040/22213"),
            new TownInformation("袋井", "22/5040/22216"),
            new TownInformation("磐田", "22/5040/22211"),
            new TownInformation("湖西", "22/5040/22221"),
        };
        public static List<TownInformation> aichiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("名古屋", "23/5110"),
            new TownInformation("豊橋", "23/5120"),
            new TownInformation("岡崎", "23/5110/23202"),
            new TownInformation("一宮", "23/5110/23203"),
            new TownInformation("半田", "23/5110/23205"),
            new TownInformation("知多", "23/5110/23224"),
            new TownInformation("武豊", "23/5110/23447"),
            new TownInformation("豊川", "23/5120/23207"),
            new TownInformation("刈谷", "23/5110/23210"),
            new TownInformation("豊田", "23/5110/23211"),
            new TownInformation("安城", "23/5110/23212"),
            new TownInformation("西尾", "23/5110/23213"),
            new TownInformation("常滑", "23/5110/23216"),
            new TownInformation("大府", "23/5110/23223"),
            new TownInformation("弥富", "23/5110/23235"),
            new TownInformation("新城", "23/5120/23221"),
        };
        public static List<TownInformation> mieTown { get; } = new List<TownInformation>()
        {
            new TownInformation("津", "24/5310"),
            new TownInformation("尾鷲", "24/5320"),
            new TownInformation("四日市", "24/5310/24202"),
            new TownInformation("松阪", "24/5310/24204"),
            new TownInformation("鈴鹿", "24/5310/24207"),
            new TownInformation("亀山", "24/5310/24210"),
            new TownInformation("桑名", "24/5310/24205"),
            new TownInformation("多気", "24/5310/24441"),
            new TownInformation("伊勢", "24/5320/24203"),
            new TownInformation("志摩", "24/5320/24215"),
            new TownInformation("熊野", "24/5320/24543"),
            new TownInformation("紀北", "24/5320/24212"),
        };
        public static List<TownInformation> shigaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("大津", "25/6010"),
            new TownInformation("彦根", "25/6020"),

        };
        public static List<TownInformation> kyotoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("京都", "26/6110"),
            new TownInformation("舞鶴", "26/6220"),
            new TownInformation("福知山", "26/6120/26201"),
            new TownInformation("舞鶴市", "26/6120/26202"),
            new TownInformation("宇治市", "26/6110/26204"),
            new TownInformation("亀岡市", "26/6110/26206"),
            new TownInformation("城陽市", "26/6110/26207"),
            new TownInformation("長岡京", "26/6110/26209"),
        };
        public static List<TownInformation> osakaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("大阪", "27/6200"),
            new TownInformation("堺", "27/6200/27141"),
            new TownInformation("豊中", "27/6200/27203"),
            new TownInformation("吹田", "27/6200/27205"),
            new TownInformation("枚方", "27/6200/27210"),
            new TownInformation("茨木", "27/6200/27211"),
            new TownInformation("泉佐野", "27/6200/27213"),
            new TownInformation("寝屋川市", "27/6200/27215"),
            new TownInformation("東大阪", "27/6200/27227"),
        };
        public static List<TownInformation> hyogoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("神戸", "28/6310"),
            new TownInformation("豊岡", "28/6320"),
            new TownInformation("姫路", "28/6310/28201"),
            new TownInformation("尼崎", "28/6310/28202"),
            new TownInformation("明石", "28/6310/28203"),
            new TownInformation("芦屋", "28/6310/28206"),
            new TownInformation("加古川", "28/6310/28210"),
        };
        public static List<TownInformation> naraTown { get; } = new List<TownInformation>()
        {
            new TownInformation("奈良", "29/6410"),
            new TownInformation("風屋", "29/6420"),
            new TownInformation("天理", "29/6410/29204"),
            new TownInformation("橿原", "29/6410/29205"),
            new TownInformation("生駒", "29/6410/29209"),
            new TownInformation("明日香村", "29/6410/29402"),
            new TownInformation("河合", "29/6410/29427"),
        };
        public static List<TownInformation> wakayamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("和歌山", "30/6510"),
            new TownInformation("潮岬", "30/6520"),
        };
        public static List<TownInformation> tottoriTown { get; } = new List<TownInformation>()
        {
            new TownInformation("鳥取", "31/6910"),
            new TownInformation("米子", "31/6920"),
        };
        public static List<TownInformation> shimaneTown { get; } = new List<TownInformation>()
        {
            new TownInformation("松江", "32/6810"),
            new TownInformation("浜田", "32/6820"),
            new TownInformation("西郷", "32/6830"),
        };
        public static List<TownInformation> okayamaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("岡山", "33/6610"),
            new TownInformation("津山", "33/6620"),
        };
        public static List<TownInformation> hiroshimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("広島", "34/6710"),
            new TownInformation("庄原", "34/6720"),
        };
        public static List<TownInformation> yamaguchiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("下関", "35/8110"),
            new TownInformation("山口", "35/8120"),
            new TownInformation("柳井", "35/8130"),
            new TownInformation("萩", "35/8140"),
        };
        public static List<TownInformation> tokushimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("徳島", "36/7110"),
            new TownInformation("日和佐", "36/7120"),
        };
        public static List<TownInformation> kagawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("高松", "37/7200"),
        };
        public static List<TownInformation> ehimeTown { get; } = new List<TownInformation>()
        {
            new TownInformation("松山", "38/7310"),
            new TownInformation("新居浜", "38/7320"),
            new TownInformation("宇和島", "38/7330"),
        };
        public static List<TownInformation> kochiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("高知", "39/7410"),
            new TownInformation("室戸岬", "39/7420"),
            new TownInformation("清水", "39/7430"),
        };
        public static List<TownInformation> fukuokaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("福岡", "40/8210"),
            new TownInformation("八幡", "40/8220"),
            new TownInformation("飯塚", "40/8230"),
            new TownInformation("久留米", "40/8240"),
        };
        public static List<TownInformation> sagaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("佐賀", "41/8510"),
            new TownInformation("伊万里", "41/8520"),
        };
        public static List<TownInformation> nagasakiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("長崎", "42/8410"),
            new TownInformation("佐世保", "42/8420"),
            new TownInformation("厳原", "42/8430"),
            new TownInformation("福江", "42/8440"),
        };
        public static List<TownInformation> kumamotoTown { get; } = new List<TownInformation>()
        {
            new TownInformation("熊本", "43/8610"),
            new TownInformation("阿蘇乙姫", "43/8620"),
            new TownInformation("牛深", "43/8630"),
            new TownInformation("人吉", "43/8640"),
        };
        public static List<TownInformation> ooitaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("大分", "44/8310"),
            new TownInformation("中津", "44/8320"),
            new TownInformation("日田", "44/8330"),
            new TownInformation("佐伯", "44/8340"),
        };
        public static List<TownInformation> miyazakiTown { get; } = new List<TownInformation>()
        {
            new TownInformation("宮崎", "45/8710"),
            new TownInformation("延岡", "45/8720"),
            new TownInformation("都城", "45/8730"),
            new TownInformation("高千穂", "45/8740"),
        };
        public static List<TownInformation> kagoshimaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("鹿児島", "46/8810"),
            new TownInformation("鹿屋", "46/8820"),
            new TownInformation("種子島", "46/8830"),
            new TownInformation("名瀬", "46/1000"),
        };
        public static List<TownInformation> okinawaTown { get; } = new List<TownInformation>()
        {
            new TownInformation("那覇", "47/9110"),
            new TownInformation("名護", "47/9120"),
            new TownInformation("久米島", "47/9130"),
            new TownInformation("南大東", "47/9200"),
            new TownInformation("宮古島", "47/9300"),
            new TownInformation("石垣島", "47/9410"),
            new TownInformation("与那国島", "47/9420"),
        };
    }
    /// <summary>
    /// 市町村単位の情報を格納するクラス
    /// </summary>
    public class TownInformation
    {
        public TownInformation(string name, string url)
        {
            this.name = name;
            this.url = url;
        }
        string name;
        public string url { get; }
        public override string ToString()
        {
            return name;
        }
    }
}
