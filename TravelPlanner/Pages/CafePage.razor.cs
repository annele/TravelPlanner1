using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Data;

namespace TravelPlanner.Pages
{
    public  partial class CafePage
    {
        public CafeResultService cafeResultService;

        public ObservableCollection<CafeResult> CafeResults { get; set; } = new ObservableCollection<CafeResult>();

       /* public void CafeSearch()
        {
            var cafeList = cafeResultService.GetCafeResult();
            foreach (var res in cafeList)
            {
                CafeResults.Add(res);
            }
        }*/

}
}
