using GeneralForecast.Forecasts.Domain.Entities;
using GeneralForecast.Forecasts.Domain.ValueObjects;

namespace GeneralForecast.Forecasts.Domain.Interfaces.Services
{
    public interface IForecastService
    {
        void AddByGroup(Forecast forecast, Group group, MonthYearDate baseDate = null);
        void AddByProduct(Forecast forecast, Product product, 
            MonthYearDate baseDate = null, MonthYearDate maxDate = null);
        void RemoveByGroup(Forecast forecast, Group group);
        void RemoveByProduct(Forecast forecast, Product product);

        void DistributeYear(Forecast forecast, Product product, decimal qty);
        void DistributeMonth(Forecast forecast, MonthYearDate baseDate, decimal qty);
    }
}