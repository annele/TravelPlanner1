using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Data;

namespace TravelPlanner.Pages
{
    public partial class Index
    {
        public CityResult UserSelectedCityResult;
        public WeatherResultService wd = new WeatherResultService();
        public string citySearch;

        public string CitySearch
        {
            get { return citySearch; }
            set { citySearch = value; }
        }



        public ObservableCollection<CityResult> CityResults { get; set; } = new ObservableCollection<CityResult>();

        public void SearchLocation()
        {
            var x = wd.GetLocations(CitySearch);
            
            CityResults.Clear();
            foreach (var res in x)
                CityResults.Add(res);
        }

        public void UsersChoice ()
        {
            
        }
    }
}
