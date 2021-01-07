using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class CityResultService
    {
        //private ObservableCollection<CityResult> _cityResults { get; set; } = new ObservableCollection<CityResult>();
        private List<CityResult> _cityResults { get; set; } = new List<CityResult>();

        public CityResultService()
        {
            string filename = @"cityResult.xml";
            if(File.Exists(filename))
            {
                _cityResults = Utils.XML.Load<List<CityResult>>(filename);

            } else
            {
                Utils.XML.Save<List<CityResult>>(@"cityResult.xml", _cityResults);

            }
        }

        public ObservableCollection<CityResult> GetByName(string cityname)
        {
            
            WebClient w = new WebClient();
            var locationsList = new ObservableCollection<CityResult>();

            var weatherApikey = Utils.APIKey.getAccuWeatherAPIKey();
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

                locationsList.Add(new CityResult(locationKey, city, country, administrativeArea, location, latidude, longitute));
            }

            return locationsList;
        }

        //implement a list of cityresult storage (like locationinformations)  (load and save XML)

        //public CityResult getByID
        // if we have it in storage, serve, if not:
        //lookup via (Accuweather ID to CityResult) https://developer.accuweather.com/accuweather-locations-api/apis/get/locations/v1/%7BlocationKey%7D
        //store

        //public obscollection<CityResult> getByName
        // if we have it in storage, serve, if not:
        //lookup via (Accuweather ID to CityResult) https://developer.accuweather.com/accuweather-locations-api/apis/get/locations/v1/%7BlocationKey%7D

        public CityResult GetById(int id)
        {
            var currentCityResult = _cityResults.Find(i => i.ID == id);

            if (currentCityResult == null)
            {
                WebClient w = new WebClient();
                
                var weatherApikey = Utils.APIKey.getAccuWeatherAPIKey();
                if (weatherApikey == null)
                {

                }
                var дщсфешщт = w.DownloadString($"https://developer.accuweather.com/accuweather-locations-api/apis/get/locations/v1/%7BlocationKey%7D");

                JArray o = JArray.Parse(дщсфешщт);

                //for (int i = 0; i < o.Count; i++)
                //  {
                var locationKey = Convert.ToInt32(o["Key"]);
                var city = o["LocalizedName"].ToString();
                var country = o["Country"]["LocalizedName"].ToString();
                var administrativeArea = o["AdministrativeArea"]["LocalizedName"].ToString();
                var latidude = (o["GeoPosition"]["Latitude"]).ToString();
                var longitute = (o["GeoPosition"]["Longitude"]).ToString();

                string location = city + ", " + country + ", " + administrativeArea;

                currentCityResult = new CityResult(locationKey, city, country, administrativeArea, location, latidude, longitute);
                _cityResults.Add(currentCityResult);
                Utils.XML.Save <List<CityResult>>(@"cityResult.xml", _cityResults);
                return currentCityResult;
                //}
            }
            else
            {
                return currentCityResult;
            }
        }
    }
}
