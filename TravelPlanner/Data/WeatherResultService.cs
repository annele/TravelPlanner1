using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Collections.ObjectModel;

namespace TravelPlanner.Data
{
    public class WeatherResultService
    {

        /// <summary>
        /// getting weather forecast for 5 days for the target location bz using the location key 
        /// </summary>
        /// <param name="locationkey"></param>
        /// <returns></returns>
        public ObservableCollection<WeatherResult> GetWeatherFor5Days(int locationkey)  // should just take in the location key 
        {

            var weatherList = new ObservableCollection<WeatherResult>();

            var weatherApikey = Utils.APIKey.getAccuWeatherAPIKey();
            WebClient w = new WebClient();

            var weatherData = w.DownloadString($"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{locationkey}?apikey={weatherApikey}&metric=true");

            JObject o = JObject.Parse(weatherData);

            for (int i = 0; i < o["DailyForecasts"].Count(); i++)
            {
                var headlineText = o["Headline"]["Text"].ToString();
                var date = Convert.ToDateTime( o["DailyForecasts"][i]["Date"]);
                var tempDay = Convert.ToDouble(o["DailyForecasts"][i]["Temperature"]["Maximum"]["Value"]);
                //  var iconNumberDay = Convert.ToInt32(o["DailyForecasts"][i]["Day"]["Icon"]);
                var tempNight = Convert.ToDouble(o["DailyForecasts"][i]["Temperature"]["Minimum"]["Value"]);
                // var iconNumbeNight = Convert.ToInt32(o["DailyForecasts"][i]["Night"]["Icon"]);
              

                weatherList.Add(new WeatherResult(headlineText, date, tempDay, tempNight));

            }

            return weatherList;
        }

    }
}
