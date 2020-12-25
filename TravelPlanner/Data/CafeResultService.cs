using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Utils;
using System.Collections.ObjectModel;

namespace TravelPlanner.Data
{
    public class CafeResultService
    {

        public string getUrl(CityResult cityResult)
        {
            string url = "";
            string baseUrl = "https://www.thefork.de/search/?coordinates=";

            string lat = cityResult.Latitude;
            string lon = cityResult.Longitude;

            url = baseUrl + lon + "," + lat;

            return url;
        }


        public ObservableCollection<CafeResult> GetCafeResult(CityResult cityResult)
        {
            var cafeResult = new ObservableCollection<CafeResult>();
            var testURL = getUrl(cityResult);

            // var testURL = getUrl(new CityResult() { Latitude = "48.220778", Longitude = "16.3100205" });
            var wc = new GZipWebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.60");
            wc.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            wc.Headers.Add("Accept-Encoding", "gzip");
            var test = wc.DownloadString(testURL);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(test);

            string typeXpath = "//span[@class = 'enrzupw0 css-1ujxl3z ejesmtr0']";
            // string nameXpath = "//a[@class = 'css-1lxw1q9 ejesmtr0']";
            string nameXpath = "//div[@class = 'css-aycukd e6vs4hd0']/div/h2/a";
            string addressExpath = "//p[@class = 'css-axj1nn ejesmtr0']";
            string avPriceXpath = "//p[@class = 'css-a7e1wa ejesmtr0']/span[2]";
            string rateXpath = "//span[@class = 'css-17f8ytt e1l48fgb0']/span[1]";

            for (int i = 0; i < 5; i++)
            {

                var type = htmlDoc.DocumentNode.SelectNodes(typeXpath)[i].InnerText;
                var name = htmlDoc.DocumentNode.SelectNodes(nameXpath)[i].InnerText;
                var address = htmlDoc.DocumentNode.SelectNodes(addressExpath)[i].InnerText;
                var averagePrice = htmlDoc.DocumentNode.SelectNodes(avPriceXpath)[i].InnerText;
                var rate = htmlDoc.DocumentNode.SelectNodes(rateXpath)[i].InnerText;

                cafeResult.Add(new CafeResult(type, name, address, averagePrice, rate));

            }

            //var link = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'enrzupw0 css-1ujxl3z ejesmtr0']").InnerText;

            return cafeResult;
        }

    }
}
