using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class LocationInformationService

    {
        public  List<LocationInformation> _locationInformations = new List<LocationInformation>();


        //load(string filename)
        //loads from file to _locationInformations

        public LocationInformationService Load(string filename)
        {
           /* var li = new LocationInformationService {_locationInformations = new List<LocationInformation>() };
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(LocationInformationService));
            var wfile = new System.IO.StreamWriter(@"locationInformation.xml");
            writer.Serialize(wfile, li);
            wfile.Close();*/

            System.Xml.Serialization.XmlSerializer reader =
        new System.Xml.Serialization.XmlSerializer(typeof(LocationInformationService));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"locationInformation.xml");
            LocationInformationService locationInformation = (LocationInformationService)reader.Deserialize(file);
            file.Close();
            return locationInformation;
        }

        //save() 
        //saves __locationInformations to file
        public void Save()

        {
            LocationInformationService locationInformation = new LocationInformationService();

            locationInformation._locationInformations = new List<LocationInformation>();
            
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(LocationInformationService));

            var path = @"locationInformation.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, locationInformation);
            file.Close();
        }


        public void Add(LocationInformation locationInformation)
        {
            _locationInformations.Add(locationInformation);
        }

        public LocationInformation GetByID(int id)
        {
            var result = _locationInformations.Find(l => l.ID == id);


            //if not found => get from api
            // save to __locationInformations
            //save xml

            return result;
        }


        public LocationInformationService()
        {

        }


    }
}
