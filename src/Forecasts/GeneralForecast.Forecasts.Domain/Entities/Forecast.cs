using System;
using System.Collections.Generic;
using System.Linq;
using GeneralForecast.Forecasts.Domain.ValueObjects;

namespace GeneralForecast.Forecasts.Domain.Entities
{
    public class Forecast
    {
        private List<ForecastUnit> _forecasts;

        public Forecast(string description): this()
        {
            Id = Guid.NewGuid();
            SetDescription(description);
        }

        public Forecast(Guid id, string description): this()
        {
            Id = id;
            SetDescription(description);
        }

        // For EF
        private Forecast()
        {
            _forecasts = new List<ForecastUnit>();            
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<ForecastUnit> Forecasts => _forecasts.AsReadOnly();

        public void SetDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void AddForecast(ForecastUnit unit)
        {
            _forecasts.Add(unit);
        }

        public void RemoveForecast(Guid forecastUnitId)
        {
            var forecastUnit = _forecasts.FirstOrDefault(f => f.Id == forecastUnitId);
            if(forecastUnit != null)
            {
                _forecasts.Remove(forecastUnit);
            }
        }

        public MonthYearDate GetFirstForecastDate()
        {
            var firstForecast = Forecasts.Min(r => r.BaseDate);
            return firstForecast?? null;
        }

        public MonthYearDate GetLastForecastDate()
        {
            var lastForecast = Forecasts.Max(r => r.BaseDate);
            return lastForecast?? null;
        }
    }
}