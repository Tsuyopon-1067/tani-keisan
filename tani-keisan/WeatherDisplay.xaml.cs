using AngleSharp;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net;



namespace tani_keisan
{
    /// <summary>
    /// WeatherDisplay.xaml の相互作用ロジック
    /// </summary>
    public partial class WeatherDisplay : UserControl
    {
        public WeatherDisplay()
        {
            InitializeComponent();
            SetWeather();
        }
        public void SetWeather()
        {
            string htmlUrl = Properties.Settings.Default.weatherUrl;
            int countSlash = htmlUrl.Length - htmlUrl.Replace("/".ToString(), "").Length;
            if (countSlash != 1 && countSlash != 2)
            {
                htmlUrl = "";
            }
            if (htmlUrl == "")
            {
                htmlUrl = "13/4410/13104";
            }
            string weather = "";
            if (countSlash == 2)
            {
                // 取得対象の設定
                htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/" + htmlUrl + ".html";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                WebClient wc = new WebClient();
                System.IO.Stream st = wc.OpenRead(htmlUrl);
                var parser = new AngleSharp.Html.Parser.HtmlParser();
                var doc    = parser.ParseDocument(st);

                // classを指定してElementを取得
                var classpList = doc.GetElementsByClassName("yjw_table2");
                string str = classpList[0].TextContent;
                string[] arr =  str.Split(' ');

                // 天気を取り出して配列に入れる
                string[] weatherList = new string[8];
                weatherList[0] = arr[564];
                weatherList[1] = arr[642];
                weatherList[2] = arr[720];
                weatherList[3] = arr[798];
                weatherList[4] = arr[876];
                weatherList[5] = arr[954];
                weatherList[6] = arr[1032];
                weatherList[7] = arr[1110];
                // 温度を取り出して配列に入れる
                string[] temperatureList = new string[8];
                temperatureList[0] = arr[1188];
                temperatureList[1] = arr[1246];
                temperatureList[2] = arr[1304];
                temperatureList[3] = arr[1362];
                temperatureList[4] = arr[1420];
                temperatureList[5] = arr[1478];
                temperatureList[6] = arr[1536];
                temperatureList[7] = arr[1594];

                // 最低・最高気温を取得
                int highTemperature = -100;
                int lowTemperature = 100;
                foreach (string t in temperatureList) {
                    int n;
                    if(int.TryParse(t, out n)) {
                        if (highTemperature < n) highTemperature = n;
                        else if (lowTemperature > n) lowTemperature = n;
                    }
                }
                // 地名を取得
                var areaLine = doc.GetElementById("cat-pass");
                str = areaLine.TextContent;
                string[] areaList = str.Split('\n');
                string area = areaList[19];
                area = Regex.Match(area, @"\S*$").ToString(); // 正規表現使う機会あるやん！ 前側の空白を削除
                DateTime dt = DateTime.Now;
                int hour = dt.Hour;
                weather = weatherList[hour / 3];
                weather = weather.Replace("\n", ""); // [スペースいっぱい]晴れ\n みたいになってるので修正
                weather = weather.Replace(" ", "");
                this.areaName.Text = area;
                this.weatherText.Text = "";
                this.highTemperature.Text = highTemperature.ToString() + "℃";
                this.lowTemperature.Text = lowTemperature.ToString() + "℃";
            } 
            else if (countSlash == 1)
            {
                // 取得対象の設定 
                htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/" + htmlUrl + ".html";
                // htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/22/5040.html";
                var querySelectorArea = $"div.yjw_sub_md_lined > div > h2";
                var querySelectorWeather = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > p.pict";
                var querySelectorHighTemerature = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.high > em";
                var querySelectorLowTemerature = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.low > em";
                // HTMLドキュメントの取得
                var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
                // クエリセレクタでデータの取得
                var elementArea = document.QuerySelector(querySelectorArea);
                var elementWeather = document.QuerySelector(querySelectorWeather);
                var elementHighTemperature = document.QuerySelector(querySelectorHighTemerature);
                var elementLowTemperature = document.QuerySelector(querySelectorLowTemerature);
                /// 天気の文字列を取得
                string area = elementArea != null ? elementArea.TextContent : "未取得";
                weather = elementWeather != null ? elementWeather.TextContent : "未取得";
                string highTemperature = elementHighTemperature != null ? elementHighTemperature.TextContent : "未取得";
                string hlowTemperature = elementLowTemperature != null ? elementLowTemperature.TextContent : "未取得";

                area = Regex.Match(area, @"（.*?）").ToString(); // 正規表現使う機会あるやん！ 「西部（浜松）」なら「（浜松）」を取り出す
                area = area.Substring(1, area.Length - 2); // 「（浜松）」->「浜松」
                weather = weather.Replace("\n", ""); // [スペースいっぱい]晴れ\n みたいになってるので修正
                weather = weather.Replace(" ", "");
                this.areaName.Text = area;
                this.highTemperature.Text = highTemperature + "℃";
                this.lowTemperature.Text = hlowTemperature + "℃";
            }
            this.weatherText.Text = "";

            switch (weather)
            {
                case "晴":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/suny.png", UriKind.Relative));
                    break;
                case "晴れ":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/suny.png", UriKind.Relative));
                    break;
                case "曇":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                case "曇り":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                case "雨":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    break;
                case "大雨":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/hardRainy.png", UriKind.Relative));
                    break;
                default:
                    if (weather.Contains("雪"))
                    {
                        weatherImg.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    }
                    else if (weather.Contains("晴"))
                    {
                        weatherImg.Source = new BitmapImage(new Uri("/weatherIco/suny.png", UriKind.Relative));
                    }
                    else if (weather.Contains("曇"))
                    {
                        weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    }
                    else if (weather.Contains("雨"))
                    {
                        weatherImg.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    }
                    else
                    {
                        weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    }
                    break;
            }
        }

        private void TextBlock_LayoutUpdated(object sender, EventArgs e)
        {
            weatherImg.Height = areaName.Height;
        }
    }
}
