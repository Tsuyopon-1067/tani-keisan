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
        public void SetWeather()
        {
            // 取得対象の設定 
            var htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/13/4410.html";
             htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/22/5040.html";
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
                case "晴れ":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/suny.png", UriKind.Relative));
                    break;
                case "曇り":
                    weatherImg.Source = new BitmapImage(new Uri("/weatherIco/cloudy.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void TextBlock_LayoutUpdated(object sender, EventArgs e)
        {
            weatherImg.Height = areaName.Height;
        }
    }
}
