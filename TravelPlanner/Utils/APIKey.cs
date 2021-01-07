using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace TravelPlanner.Utils
{
    public static class APIKey
    {
        /// <summary>
        /// getting APIKEY from config file
        /// </summary>
        /// <returns></returns>
        public static String getAccuWeatherAPIKey()
        {
            string filePath = @"config.txt";
            string weatherApikey = "";

            if (File.Exists(filePath))
            {
                string configs = File.ReadAllText(filePath);
                weatherApikey = configs.Split('=')[1];
            }
            else
            {
                return null;
            }
            return weatherApikey;
        }
    }
}
