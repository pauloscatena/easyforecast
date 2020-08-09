using System.Linq;
using GeneralForecast.Forecasts.Domain.Entities;
using GeneralForecast.Forecasts.Domain.Interfaces.Services;
using GeneralForecast.Forecasts.Domain.ValueObjects;

namespace GeneralForecast.Forecasts.Domain
{
    public class ForecastService: IForecastService
    {
        public void AddByGroup(Forecast forecast, Group group, MonthYearDate baseDate = null)
        {
            if(baseDate == null)
                baseDate = forecast.GetFirstForecastDate();

            var maxDate = forecast.GetLastForecastDate();           

            foreach(var product in group.Products)
            {
                AddByProduct(forecast, product, baseDate, maxDate);
            }            
        }       

        public void AddByProduct(Forecast forecast, Product product, 
            MonthYearDate baseDate = null, MonthYearDate maxDate = null)
        {
            if(baseDate == null)
                baseDate = forecast.GetFirstForecastDate();

            if(maxDate == null)
                maxDate = forecast.GetLastForecastDate(); 

            var tmpDate = baseDate;
            while(tmpDate <= maxDate)
            {
                var forecastUnit = new ForecastUnit(tmpDate, product, 0);
                forecast.AddForecast(forecastUnit);
                tmpDate.NextMonth();
            }
        }

        public void DistributeMonth(Forecast forecast, MonthYearDate baseDate, decimal qty)
        {
            var forecastUnits = forecast.Forecasts.Where(r => r.BaseDate == baseDate).ToList();
            var count = forecastUnits.Count;
            var distribution = qty / count;
            var reminder = qty - (count * distribution);

            ForecastUnit lastUnit = null;
            foreach(var unit in forecastUnits)
            {
                unit.SetQuantity(distribution);
                lastUnit = unit;
            }

            if(lastUnit != null)
                lastUnit.SetQuantity(lastUnit.Quantity + reminder);
        }

        public void DistributeYear(Forecast forecast, Product product, decimal qty)
        {
            var monthlyDistribution = qty / 12;
            var reminder = qty - (monthlyDistribution * 12);

            var forecastUnits = forecast.Forecasts.Where(r => r.Product.Equals(product)).ToList();
            ForecastUnit lastUnit = null;
            foreach(var unit in forecastUnits)
            {
                unit.SetQuantity(monthlyDistribution);
                lastUnit = unit;
            }
            if(lastUnit != null)
                lastUnit.SetQuantity(lastUnit.Quantity + reminder);                
        }

        public void RemoveByGroup(Forecast forecast, Group group)
        {
            foreach(var product in group.Products)
            {
                RemoveByProduct(forecast, product);
            }
        }

        public void RemoveByProduct(Forecast forecast, Product product)
        {
            foreach(var unit in forecast.Forecasts.Where(r => r.Product.Equals(product)))
            {
                forecast.RemoveForecast(unit.Id);
            }
        }
    }
}