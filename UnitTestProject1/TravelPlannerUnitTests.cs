using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using TravelPlanner;

namespace UnitTestProject1
{
    [TestClass]
    public class TravelPlannerUnitTests
    {
        [TestMethod]
        public void AccuWeatherAPIstorage()
        {
            var res = TravelPlanner.Utils.APIKey.getAccuWeatherAPIKey();

            Assert.IsNotNull(res, "API file not found");

        }
        [TestMethod]
        public void ForkURL()
        {
            //setup 
            var crs = new TravelPlanner.Data.CafeResultService();
            var cr = new TravelPlanner.Data.CityResult();
            cr.Latitude = "100";
            cr.Longitude = "200";

            //act
            var res = crs.getUrl(cr);

            //assert
            StringAssert.StartsWith(res, "http");
            StringAssert.Contains(res, cr.Longitude);
            StringAssert.Contains(res, cr.Latitude);
        }

        [TestMethod]

        public void CafeResults()
        {
            //setup
            var crs = new TravelPlanner.Data.CafeResultService();
            var cafeResult = new TravelPlanner.Data.CafeResult();
            var cr = new TravelPlanner.Data.CityResult();
            cr.Latitude = "52.520008";
            cr.Longitude = "13.404954";
            cafeResult.CafeType = "Coffe";
            cafeResult.CafeName = "Espressolab";
            cafeResult.CafeAdress = "Lorenzerplatz";
            cafeResult.AveragePrice = "3";
            cafeResult.Rate = "9";

            //act

            var res = crs.GetCafeResults(cr);
            int number = res.Count();                    
            //assert
         
            Assert.AreEqual(number, 5);
            Assert.IsNotNull(res[0]);
          

        }


    }
}
