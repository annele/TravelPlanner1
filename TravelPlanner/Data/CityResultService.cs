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
     //   private List<CityResult> _cityResults { get; set; } = new List<CityResult>();
        private SqlDbContext _context;

        public CityResultService(SqlDbContext ctx)
        {
            _context = ctx;
           // _cityResults = Utils.XML.Load<List<CityResult>>(@"cityResult.xml");
        }

        public void Add(CityResult cityResult)
        {
            _context.CityResults.Add(cityResult);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityname"></param>
        /// <returns></returns>
        public ObservableCollection<CityResult> GetByName(string cityname)
        {
            //handle error if cityname is nulll => return new empty list
            if (cityname == null)
            {
                return new ObservableCollection<CityResult>();
            }

            var foundCityResults = _context.CityResults.Where(c => c.City.ToLower() == cityname.ToLower()).ToList();

  

            if (foundCityResults.Count == 0)
            {
                WebClient w = new WebClient();
                var weatherApikey = Utils.APIKey.getAccuWeatherAPIKey();
                if (weatherApikey == "")
                {
                    return new ObservableCollection<CityResult>();                  
                }

                var locations = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={weatherApikey}&q={cityname}");
                JArray o = JArray.Parse(locations);

                for (int i = 0; i < o.Count; i++)
                {
                    var locationKey = Convert.ToInt32(o[i]["Key"]);
                    var city = o[i]["LocalizedName"].ToString();
                    var country = o[i]["Country"]["LocalizedName"].ToString();
                    var administrativeArea = o[i]["AdministrativeArea"]["LocalizedName"].ToString();
                    var latitude = (o[i]["GeoPosition"]["Latitude"]).ToString();
                    var longitude = (o[i]["GeoPosition"]["Longitude"]).ToString();

                    string location = city + ", " + country + ", " + administrativeArea;

                    //here we have 1 new result

                    foundCityResults.Add(new CityResult(locationKey, city, country, administrativeArea, location, longitude, latitude));
                }
                _context.CityResults.AddRange(foundCityResults);
                _context.SaveChanges();
                //Utils.XML.Save<List<CityResult>>(@"cityResult.xml", _cityResults);
            }
            return new ObservableCollection<CityResult>(foundCityResults);
        }

        /// <summary>
        /// checks by ID whether the cityResult is already in storage, if not gets from API and saves it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CityResult GetById(int id)
        {
            var foundCityResult = _context.CityResults.Find(id);

            if (foundCityResult == null)
            {
                WebClient w = new WebClient();

                var weatherApikey = Utils.APIKey.getAccuWeatherAPIKey();
                if (weatherApikey == null)
                {
                    return new CityResult();
                }
                var locations = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/{id}?apikey={weatherApikey}");

                JObject o = JObject.Parse(locations);

                var locationKey = Convert.ToInt32(o["Key"]);
                var city = o["LocalizedName"].ToString();
                var country = o["Country"]["LocalizedName"].ToString();
                var administrativeArea = o["AdministrativeArea"]["LocalizedName"].ToString();
                var latitude = (o["GeoPosition"]["Latitude"]).ToString();
                var longitude = (o["GeoPosition"]["Longitude"]).ToString();

                string location = city + ", " + country + ", " + administrativeArea;

                foundCityResult = new CityResult(locationKey, city, country, administrativeArea, location, longitude, latitude);

                _context.CityResults.Add(foundCityResult);
                _context.SaveChanges();
               // Utils.XML.Save<List<CityResult>>(@"cityResult.xml", _cityResults);
            }
            return foundCityResult;
        }
    }
}
