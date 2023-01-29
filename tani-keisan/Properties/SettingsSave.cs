using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace tani_keisan.Properties
{
    static class SettingsSave
    {
        //保存先のファイル名
        private static string dcFileName = @"./settings/DisplayedCredit.xml";
        static DisplayedCredit dc;

        public static void SaveDisplayedCredit(DisplayedCredit displayedCredit)
        {

            if (displayedCredit == null)
            {
                displayedCredit = new DisplayedCredit();
            }
            dc = displayedCredit;

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(DisplayedCredit));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                dcFileName, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, dc);
            //ファイルを閉じる
            sw.Close();
        }
        public static DisplayedCredit ReadDisplayedCredit() 
        {
            //XmlSerializerオブジェクトを作成
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(DisplayedCredit));
            System.IO.StreamReader sr;
            DisplayedCredit obj;
            try
            {
                //読み込むファイルを開く
                sr = new System.IO.StreamReader(
                    dcFileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                obj = (DisplayedCredit)serializer.Deserialize(sr);
                //ファイルを閉じる
            }
            catch (FileNotFoundException e)
            {
                dc = new DisplayedCredit();
                SaveDisplayedCredit(dc);
                return dc;
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory("./settings");
                dc = new DisplayedCredit();
                SaveDisplayedCredit(dc);
                return dc;
            }

            sr.Close();
            dc = obj;

            if (obj == null)
            {
                dc = new DisplayedCredit();
                return dc;
            }
            return dc;
        }
        //保存先のファイル名
        private static string clFileName = @"./settings/CreditList.xml";
        static ObservableCollection<Credit> cl;

        public static void SaveCreditList(ObservableCollection<Credit> credits)
        {
            if (credits == null)
            {
                credits = new ObservableCollection<Credit>();
            }
            cl = credits;

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<Credit>));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                clFileName, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, cl);
            //ファイルを閉じる
            sw.Close();
        }
        public static ObservableCollection<Credit> ReadCreditList()
        {
            //XmlSerializerオブジェクトを作成
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<Credit>));
            System.IO.StreamReader sr;
            ObservableCollection<Credit> obj;
            try
            {
                //読み込むファイルを開く
                sr = new System.IO.StreamReader(
                    clFileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                obj = (ObservableCollection<Credit>)serializer.Deserialize(sr);
                //ファイルを閉じる
            }
            catch (FileNotFoundException e)
            {
                //SaveDisplayedCredit();
                cl = new ObservableCollection<Credit>();
                return cl;
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory("./settings");
                //SaveDisplayedCredit();
                cl = new ObservableCollection<Credit>();
                return cl;
            }

            sr.Close();
            cl = obj;

            if (obj == null)
            {
                cl = new ObservableCollection<Credit>();
            }
            return cl;
        }
    }
}
