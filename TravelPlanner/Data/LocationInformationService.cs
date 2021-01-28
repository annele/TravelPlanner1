using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TravelPlanner.Data
{
    public class LocationInformationService
    {
        public CafeResultService cafeResultService;
        public WeatherResultService weatherResultService;
        public CityResultService cityResultService;

       // public List<LocationInformation> _locationInformations = new List<LocationInformation>();
        private SqlDbContext _context;

        public LocationInformationService(CafeResultService cars, WeatherResultService wers, CityResultService cirs, SqlDbContext ctx)
        {
            cafeResultService = cars;
            weatherResultService = wers;
            cityResultService = cirs;
           // _locationInformations = Utils.XML.Load<List<LocationInformation>>(@"locationInformation.xml");
            _context = ctx;
        }

        //public void Add(LocationInformation locationInformation)
        //{
        //    _context.LocationInformations.Add(locationInformation);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LocationInformation GetByID(int id)
        {
            //var foundLocationInformation = _locationInformations.Find(l => l.ID == id);
            var foundLocationInformation = _context.LocationInformations.Find(id);

            if (foundLocationInformation == null)
            {
                var locationWeather = weatherResultService.GetWeatherFor5Days(id);
                var locationCityResult = cityResultService.GetById(id);//new CityResult(); // from cityresult storage, or from accuweather api above              
                var locationCafe = cafeResultService.GetCafeResults(locationCityResult);
                var locationCityName = locationCityResult.City;

                foundLocationInformation = new LocationInformation();
                foundLocationInformation.CafeResults = locationCafe;
                foundLocationInformation.WeatherResults = locationWeather;
                foundLocationInformation.ID = id;
                foundLocationInformation.City = locationCityName;

                //_locationInformations.Add(foundLocationInformation);
                _context.LocationInformations.Add(foundLocationInformation);
                _context.SaveChanges();
                //Utils.XML.Save<List<LocationInformation>>(@"locationInformation.xml", _locationInformations);

                return foundLocationInformation;
            }

            var storedWeather = foundLocationInformation.WeatherResults;
            var currWeatherResultDate = storedWeather[0].Date;

            DateTime today = DateTime.Today;
            var datesDifference = DateTime.Compare(currWeatherResultDate, today);

            if (datesDifference < 0)
            {
                var currentWeatherResults = weatherResultService.GetWeatherFor5Days(id);
                foundLocationInformation.WeatherResults = currentWeatherResults;
                _context.SaveChanges();
                //Utils.XML.Save<List<LocationInformation>>(@"locationInformation.xml", _locationInformations);
            }

            return foundLocationInformation;

        }

    }
}
