using Microsoft.AspNetCore.Components.Web;
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
        public CafeResultService crs = new CafeResultService();
        public string citySearch;

        public string CitySearch
        {
            get { return citySearch; }
            set { citySearch = value; }
        }



        public ObservableCollection<CityResult> CityResults { get; set; } = new ObservableCollection<CityResult>();

        public void SearchLocation()
        {
            var x = wd.GetCityResults(CitySearch);
            
            CityResults.Clear();
            foreach (var res in x)
                CityResults.Add(res);
        }

        public void UsersChoice(CityResult cityResult)
        {
            var x = wd.GetWeatherFor5Days(cityResult.ID);
            var y = crs.GetCafeResult(cityResult);

            var locinfo = new LocationInformation();

            locinfo.CafeResult = y;
            locinfo.WeatherResult = x;
            locinfo.ID = cityResult.ID;

            locationInformationService.Add(locinfo);

        }
    }
}
