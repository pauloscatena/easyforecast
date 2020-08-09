using System;
using GeneralForecast.Forecasts.Domain.ValueObjects;

namespace GeneralForecast.Forecasts.Domain.Entities
{
    public class ForecastUnit
    {
        // Exclusive for EF
        private ForecastUnit(){

        }
        public ForecastUnit(MonthYearDate baseDate, Product product, decimal quantity)
        {
            Id = Guid.NewGuid();
            SetDate(baseDate);
            SetProduct(product);
            SetQuantity(quantity);
        }

        public ForecastUnit(Guid id, MonthYearDate baseDate, Product product, decimal quantity)
        {
            Id = id;
            SetDate(baseDate);
            SetProduct(product);
            SetQuantity(quantity);
        }

        public Guid Id { get; private set; }
        public MonthYearDate BaseDate { get; private set; }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }

        public void SetProduct(Product newProduct)
        {
            Product = newProduct;
        }

        public void SetQuantity(decimal newQuantity)
        {
            Quantity = newQuantity;
        }

        public void SetDate(MonthYearDate newDate)
        {
            BaseDate = newDate;
        }
    }
}