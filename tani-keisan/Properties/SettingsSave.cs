﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tani_keisan.Properties
{
    static class SettingsSave
    {
        //保存先のファイル名
        private static string dcFileName = @"./settings/DisplayedCredit.xml";
        static DisplayedCredit dc;

        public static void SaveDisplayedCredit()
        {

            if (dc == null)
            {
                dc = new DisplayedCredit();
            }

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
            //読み込むファイルを開く
            System.IO.StreamReader sr = new System.IO.StreamReader(
                dcFileName, new System.Text.UTF8Encoding(false));
            //XMLファイルから読み込み、逆シリアル化する
            DisplayedCredit obj = (DisplayedCredit)serializer.Deserialize(sr);
            //ファイルを閉じる
            sr.Close();

            if (obj == null)
            {
                return new DisplayedCredit();
            }
            return obj;
        }
    }
}
