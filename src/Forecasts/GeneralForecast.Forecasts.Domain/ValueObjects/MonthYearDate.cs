using System;

namespace GeneralForecast.Forecasts.Domain.ValueObjects
{
    public class MonthYearDate: IComparable
    {
        private DateTime _baseDate;
        public MonthYearDate(int year, int month)
        {
            _baseDate = new DateTime(year, month, 1);            
        }

        public int Month => _baseDate.Month;

        public int Year => _baseDate.Year;

        public void AddMonths(int months)
        {
            _baseDate.AddMonths(months);
        }

        public void AddYears(int years)
        {
            _baseDate.AddYears(years);
        }

        public void NextMonth()
        {
            AddMonths(1);            
        }

        public void NextYear()
        {
            AddYears(1);
        }

        public void PreviousMonth()
        {
            AddMonths(-1);
        }

        public void PreviousYear()
        {
            AddYears(-1);
        }

        #region Comparables
        public int CompareTo(object obj)
        {
            var tmp = (MonthYearDate)obj;
            var diff = (Year + Month) - (tmp.Year + tmp.Month);
            return diff > 0? 1: diff == 0? 0: -1;
        }

        public static bool operator > (MonthYearDate myd1, MonthYearDate myd2)
        {
            return myd1.CompareTo(myd2) == 1;
        }
        public static bool operator < (MonthYearDate myd1, MonthYearDate myd2)
        {
            return myd1.CompareTo(myd2) == -1;
        }

        public static bool operator >= (MonthYearDate myd1, MonthYearDate myd2)
        {
            return myd1.CompareTo(myd2) >= 0;
        }
        public static bool operator <= (MonthYearDate myd1, MonthYearDate myd2)
        {
            return myd1.CompareTo(myd2) <= 0;
        }

        public static bool operator == (MonthYearDate myd1, MonthYearDate myd2)
        {
            return myd1.Equals(myd2);
        }

        public static bool operator != (MonthYearDate myd1, MonthYearDate myd2)
        {
            return !myd1.Equals(myd2);
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            if(!(obj is MonthYearDate))
                return false;

            var tmp = (MonthYearDate)obj;
            return tmp.Month == Month && tmp.Year == Year;
        }

        public override int GetHashCode()
        {
            return Year + Month;
        }

        public override string ToString()
        {
            return $"{Month}/{Year}";
        }
        #endregion
    }
}