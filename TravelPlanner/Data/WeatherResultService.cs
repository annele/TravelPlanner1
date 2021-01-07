using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Collections.ObjectModel;

namespace TravelPlanner.Data
{
    public class WeatherResultService

    {


        /// <summary>
        /// getting APIKEY from config file
        /// </summary>
        /// <returns></returns>
      /*   private String getAccuWeatherAPIKey()  //put in utilities 
        {

            string filePath = @"config.txt";
            string weatherApikey = "";

            if (File.Exists(filePath))
            {
                string configs = File.ReadAllText(filePath);
                weatherApikey = configs.Split('=')[1];
            }
            else
            {
                return null;
            }
            return weatherApikey;
        }

        /// <summary>
        /// Getting data about target location (city) chosen by the user
        /// </summary>
        /// <param name="cityname"></param>
        /// <returns></returns>
       public ObservableCollection<CityResult> GetCityResults(string cityname)  // move this function to new CityResultService
        {

            var result = _cityResults.Find(c => c.CityName == cityname);
            if (result == null)
            {

            }


            WebClient w = new WebClient();
            var locationsList = new ObservableCollection<CityResult>();

            var weatherApikey = getAccuWeatherAPIKey();
            if (weatherApikey == null)
            {

            }
            var locations = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={weatherApikey}&q={cityname}");

            JArray o = JArray.Parse(locations);

            for (int i = 0; i < o.Count; i++)
            {
                var locationKey = Convert.ToInt32(o[i]["Key"]);
                var city = o[i]["LocalizedName"].ToString();
                var country = o[i]["Country"]["LocalizedName"].ToString();
                var administrativeArea = o[i]["AdministrativeArea"]["LocalizedName"].ToString();
                var latidude = (o[i]["GeoPosition"]["Latitude"]).ToString();
                var longitute = (o[i]["GeoPosition"]["Longitude"]).ToString();


                string location = city + ", " + country + ", " + administrativeArea;

                locationsList.Add(new CityResult(locationKey, location, latidude, longitute));
            }

            return locationsList;
        }*/


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
                var date = Convert.ToDateTime((o["DailyForecasts"][i]["Date"]));
                var tempDay = Convert.ToDouble(o["DailyForecasts"][i]["Temperature"]["Maximum"]["Value"]);
                var iconNumberDay = Convert.ToInt32(o["DailyForecasts"][i]["Day"]["Icon"]);
                var tempNight = Convert.ToDouble(o["DailyForecasts"][i]["Temperature"]["Minimum"]["Value"]);
                var iconNumbeNight = Convert.ToInt32(o["DailyForecasts"][i]["Night"]["Icon"]);

                weatherList.Add(new WeatherResult(headlineText, date, iconNumberDay, tempDay, iconNumbeNight,tempNight));

            }

            return weatherList;
        }





    }
}
