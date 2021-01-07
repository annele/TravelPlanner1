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
        /// searches for the locations by the 
        /// </summary>
        public void SearchLocation()
        {
            var city = cityResultService.GetByName(CitySearch);
            foreach (var locationList in city)
                CityResults.Add(locationList);
        }
    }
}
