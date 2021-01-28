using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class LocationInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string City { get; set; }
        [ForeignKey("CityID")]
        public ObservableCollection<CafeResult> CafeResults { get; set; }
        [ForeignKey("CityID")]
        public ObservableCollection<WeatherResult> WeatherResults { get; set; }

        public LocationInformation()
        {

        }
    }
}
