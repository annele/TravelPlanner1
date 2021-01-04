using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelPlanner.Data
{
    public class LocationInformationService
    {
        public List<LocationInformation> _locationInformations = new List<LocationInformation>();


        //load(string filename)
        //loads from file to _locationInformations

        public List<LocationInformation> Load(string filename)
        {
          //  path = @"locationInformation.xml";
          if(File.Exists(filename))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<LocationInformation>));
                StreamReader file = new StreamReader(filename);


                var locinfo = reader.Deserialize(file) as List<LocationInformation>;
                file.Close();
                return locinfo;
            } 
          else
            {
                return new List<LocationInformation>();
            }
          
        }

        //save() 
        //saves __locationInformations to file
        public void Save(string filename)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<LocationInformation>));
          //  path = @"locationInformation.xml";
            FileStream file = File.Create(filename);
            writer.Serialize(file, _locationInformations);
            file.Close();
        }


        public void Add(LocationInformation locationInformation)
        {
            _locationInformations.Add(locationInformation);
        }

        public LocationInformation GetByID(int id)
        {
            _locationInformations = Load(@"locationInformation.xml");
            var result = _locationInformations.Find(l => l.ID == id);

            //var result = new List<LocationInformation>();
            //  result = locInfo.Find(l => l.ID == id);
            //   var result = locInfo.Find(l => l.ID == id);
            if (result == null)
            {
                var weather = new WeatherResultService();
                var cafe = new CafeResultService();
                var city = new CityResult();
                result = new LocationInformation();

                var locWeather = weather.GetWeatherFor5Days(id);
                var locCafe = cafe.GetCafeResult(city);

                result.WeatherResult = locWeather;
                result.CafeResult = locCafe;
                result.ID = id;

                _locationInformations.Add(result);
                Save(@"locationInformation.xml");

                return result;

            }
            else
            {
                return result;
            }


            //if not found => get from api
            // save to __locationInformations
            //save xml

            //return result;
        }

    }
}
