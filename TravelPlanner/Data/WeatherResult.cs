using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class WeatherResult
    {
        private DateTime _date;
        private double _tempDay;
        private double _tempNight;
        private string _headlineTexts;

        public string HeadlineText
        {
            get { return _headlineTexts; }
            set { _headlineTexts = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public String DisplayDate
        {
            get
            {
                return _date.ToString("f");
            }
        }

        public double TempDay
        {
            get { return _tempDay; }
            set { _tempDay = value; }
        }

        public double TempNight
        {
            get { return _tempNight; }
            set { _tempNight = value; }
        }

        public WeatherResult(string headlineTexts, DateTime date, double tempDay, double tempNight)
        {
            _headlineTexts = headlineTexts;
            _date = date;
            _tempDay = tempDay;
            _tempNight = tempNight;
        }

        public WeatherResult()
        {

        }

    }

}
