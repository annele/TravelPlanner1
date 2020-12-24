using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class CafeResult
    {
        private string _url;
        private string _cafeType;
        private string _cafeName;
        private string _cafeAddress;
        private string _rate;
        private string _averagePrice;

        public string AveragePrice
        {
            get { return _averagePrice; }
            set { _averagePrice = value; }
        }


        public string Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }


        public string CafeAdress
        {
            get { return _cafeAddress; }
            set { _cafeAddress = value; }
        }


        public string CafeName
        {
            get { return _cafeName; }
            set { _cafeName = value; }
        }


        public string CafeType
        {
            get { return _cafeType; }
            set { _cafeType = value; }
        }


        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        public CafeResult()
        {

        }

        public CafeResult(string type, string name, string address, string avPrice, string rate)
        {
            _cafeType = type;
            _cafeName = name;
            _cafeAddress = address;
            _averagePrice = avPrice;
            _rate = rate;
        }
    }
}
