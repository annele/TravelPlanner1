using System;

namespace TravelPlanner.Data
{
    public class WeatherResult
    {
        private DateTime _date;
        private double _tempDay;
        private double _tempNight;
        private string _headlineTexts;
        private string _daySummary;
        private string _nightSummary;

        public string NightSummary
        {
            get { return _nightSummary; }
            set { _nightSummary = value; }
        }

        public string DaySummary
        {
            get { return _daySummary; }
            set { _daySummary = value; }
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
                return _date.ToString();
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

        public WeatherResult(string headlineTexts, DateTime date, double tempDay, double tempNight, string daySummary, string nightSummary)
        {
            _headlineTexts = headlineTexts;
            _date = date;
            _tempDay = tempDay;
            _tempNight = tempNight;
            _daySummary = daySummary;
            _nightSummary = nightSummary;
        }

        public WeatherResult()
        {

        }

    }

}
