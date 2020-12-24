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

        private string _latitude;
        private string _longitude;

        public string Longitude { 
        
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

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public CityResult (int id, string description, string longitude, string latitude)
        {
            this._id = id;
            this._description = description;
            this._latitude = latitude;
            this._longitude = longitude;
        }
        public CityResult ()
        {

        }

        public override string ToString()
        {
            return this.Description;
        }

    }
}
