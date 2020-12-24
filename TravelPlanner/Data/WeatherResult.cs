using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class WeatherResult
    {
        private DateTime _date;
        private int _iconNumberDay;
        private int _iconNumberNight;
        private double _tempDay;
        private double _tempNight;
        private string _headlineTexts;



        public int IconNumberDay
        {
            get { return _iconNumberDay; }
            set { _iconNumberDay = value; }
        }

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

        public int IconNumbeNight
        {
            get { return _iconNumberNight; }
            set { _iconNumberNight = value; }
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



        public WeatherResult(string headlineTexts, DateTime date, int iconNumberDay, double tempDay, int iconNumberNight, double tempNight)
        {
            _headlineTexts = headlineTexts;
            _date = date;
            _iconNumberDay = iconNumberDay;
            _tempDay = tempDay;
            _iconNumberNight = iconNumberNight;
            _tempNight = tempNight;
        }

    }

}
