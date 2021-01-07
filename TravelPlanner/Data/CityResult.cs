using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class CityResult
    {

        private int _id;
        private string _description;
        private string _city;
        private string _country;
        private string _administrativeArea;
        private string _latitude;
        private string _longitude;

        public string Longitude
        {

            get { return _longitude; }
            set { value = _latitude; }
        }

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string County
        {
            get { return _country; }
            set { _country = value; }
        }

        public string AdministrativeArea
        {
            get { return _administrativeArea; }
            set { _administrativeArea = value; }
        }
        public string Description
        {
            get { return _city + ", " + _country + ", " + _administrativeArea; }
        }

        public CityResult(int id, string city, string country, string administrativeArea, string description, string longitude, string latitude)
        {
            _id = id;
            _city = city;
            _country = country;
            _administrativeArea = administrativeArea;
            _description = description;
            _latitude = latitude;
            _longitude = longitude;
        }
        public CityResult()
        {

        }

        public override string ToString()
        {
            return this.Description;
        }

    }
}
