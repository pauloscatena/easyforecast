using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralForecast.Forecasts.Domain.Entities
{
    public class Group
    {
        private List<Product> _products;

        public Group(Guid id, string name): this()
        {
            Id = id;
            SetName(name);
        }

        public Group(string name): this()
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        // Constructor for EF
        private Group()
        {
            _products = new List<Product>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Product> Products => _products.AsReadOnly();
        
        public void SetName(string newName)
        {
            Name = newName;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if(product != null)
            {
                _products.Remove(product);
            }
        }

    }
}