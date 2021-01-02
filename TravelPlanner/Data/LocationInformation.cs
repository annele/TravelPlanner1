using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class LocationInformation
    {
       public  int ID;
       public  ObservableCollection<CafeResult> CafeResult;
       public ObservableCollection<WeatherResult> WeatherResult;

        public LocationInformation()
        {

        }
    }
}
