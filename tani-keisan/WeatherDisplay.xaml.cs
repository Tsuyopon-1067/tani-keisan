using AngleSharp;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


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
        bool flag = false;
        public void SetWeather()
        {
            string htmlUrl = Properties.Settings.Default.weatherUrl;
            if (htmlUrl == "")
            {
                htmlUrl = "13/4410";
            }
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
            string weather = elementWeather != null ? elementWeather.TextContent : "未取得";
            string highTemperature = elementHighTemperature != null ? elementHighTemperature.TextContent : "未取得";
            string hlowTemperature = elementLowTemperature != null ? elementLowTemperature.TextContent : "未取得";

            area = Regex.Match(area, @"（.*?）").ToString(); // 正規表現使う機会あるやん！ 「西部（浜松）」なら「（浜松）」を取り出す
            area = area.Substring(1, area.Length - 2); // 「（浜松）」->「浜松」
            weather = weather.Replace("\n", ""); // [スペースいっぱい]晴れ\n みたいになってるので修正
            weather = weather.Replace(" ", "");
            this.areaName.Text = area;
            this.weatherText.Text = weather;
            this.highTemperature.Text = highTemperature + "℃";
            this.lowTemperature.Text = hlowTemperature + "℃";

            switch (weather)
            {
                case "晴れ" or "晴":
                    flag = false;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    break;
                case "曇り" or "曇":
                    flag = false;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                case "雨":
                    flag = false;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    break;
                case "大雨" or "暴風雨":
                    flag = false;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/hardRainy.png", UriKind.Relative));
                    break;
                case "雪" or "大雪" or "暴風雨":
                    flag = false;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    break;
                case "晴のち曇" or "晴時々曇" or "晴一時曇":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                case "曇のち晴" or "曇時々晴" or "曇一時晴":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    break;
                case "晴れのち雨" or "晴時々雨" or "晴一時雨":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    break;
                case "雨のち晴" or "雨時々晴" or "雨一時晴":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    break;
                case "晴のち雪" or "晴時々雪" or "晴一時雪":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    break;
                case "雪のち晴" or "雪時々晴" or "雪一時晴":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/sunny.png", UriKind.Relative));
                    break;
                case "曇のち雨" or "曇時々雨" or "曇一時雨":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    break;
                case "雨のち曇" or "雨時々曇" or "雨一時曇":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                case "曇のち雪" or "曇時々雪" or "曇一時雪":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    break;
                case "雪のち曇" or "雪時々曇" or "雪一時曇":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                case "雨のち雪" or "雨時々雪" or "雨一時雪":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    break;
                case "雪のち雨" or "雪時々雨" or "雪一時雨":
                    flag = true;
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/snowy.png", UriKind.Relative));
                    weatherImg2.Source = new BitmapImage(new Uri("/weatherIco/rainy.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void TextBlock_LayoutUpdated(object sender, EventArgs e)
        {
            if (flag) // todo: 二つ天気を表示する場合50%サイズで二つ並べたい
            {
                weatherImg.Height = areaName.Height / 2;
                weatherImg.Width = areaName.Height / 2;
                weatherImg2.Height = areaName.Height / 2;
                weatherImg2.Width = areaName.Height / 2;
            } else
            {
                weatherImg.Height = areaName.Height;
                weatherImg.Width = areaName.Height;
            }
        }
    }
}
