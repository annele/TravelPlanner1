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
        public string citySearch;
        public ObservableCollection<CityResult> CityResults { get; set; } = new ObservableCollection<CityResult>();

        public string CitySearch
        {
            get { return citySearch; }
            set { citySearch = value; }
        }

        /// <summary>
        /// searches for the city using users's input. either takes citydata from cityResults.xml or from the API
        /// </summary>
        public void SearchLocation()
        {
            var cities = cityResultService.GetByName(CitySearch);
            CityResults.Clear();
            foreach (var city in cities)
                CityResults.Add(city);
        }
    }
}
