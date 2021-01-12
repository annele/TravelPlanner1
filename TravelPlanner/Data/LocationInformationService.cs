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
        public CafeResultService cafeResultService = new CafeResultService();
        public WeatherResultService weatherResultService = new WeatherResultService();
        public CityResultService cityResultService = new CityResultService();
        public CityResult cityResult = new CityResult();

        public List<LocationInformation> _locationInformations = new List<LocationInformation>();

        public LocationInformationService()
        {
            _locationInformations = Utils.XML.Load<List<LocationInformation>>(@"locationInformation.xml");
        }

        public void Add(LocationInformation locationInformation)
        {
            _locationInformations.Add(locationInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LocationInformation GetByID(int id)
        {
            var currentLocationInformation = _locationInformations.Find(l => l.ID == id);


            if (currentLocationInformation == null)
            {

                var locationWeather = weatherResultService.GetWeatherFor5Days(id);
                var locationCityResult = cityResultService.GetById(id);//new CityResult(); // from cityresult storage, or from accuweather api above              
                var locationCafe = cafeResultService.GetCafeResult(locationCityResult);

                currentLocationInformation = new LocationInformation();
                currentLocationInformation.CafeResult = locationCafe;
                currentLocationInformation.WeatherResult = locationWeather;
                currentLocationInformation.ID = id;

                _locationInformations.Add(currentLocationInformation);
                Utils.XML.Save<List<LocationInformation>>(@"locationInformation.xml", _locationInformations);

                return currentLocationInformation;

            }

            var locW = currentLocationInformation.WeatherResult;
            List<WeatherResult> curLocWeatherResult = new List<WeatherResult>(locW);
            var currWeatherResultDate = curLocWeatherResult[0].Date;
            DateTime today = DateTime.Today;
            var datesDifference = DateTime.Compare(currWeatherResultDate, today);

            if (datesDifference < 0)
                {
                    var locationWeather = weatherResultService.GetWeatherFor5Days(id);
                    currentLocationInformation.WeatherResult = locationWeather;
                    _locationInformations.Add(currentLocationInformation);
                    Utils.XML.Save<List<LocationInformation>>(@"locationInformation.xml", _locationInformations);

                    return currentLocationInformation;

                }
            

            else
            {

                return currentLocationInformation;
            }


            //if not found => get from api
            // save to __locationInformations
            //save xml

            //return result;
        }

    }
}
