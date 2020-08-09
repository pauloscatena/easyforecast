using System;

namespace GeneralForecast.Forecasts.Domain.Entities
{
    public class Product
    {
        // For EF
        public Product()
        {            
        }

        public Product(string description, string name)
        {
            Id = Guid.NewGuid();
            SetDescription(description);
            SetName(name);
        }

        public Product(Guid id, string description, string name)
        {
            Id = id;
            SetDescription(description);
            SetName(name);
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }

        public void SetName(string newName)
        {
            Name = newName;
        }

        public void SetDescription(string newDescription)
        {
            Description = newDescription;
        }

        #region Overrides
        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is Product)) 
                return false;
            
            return Id == ((Product)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Id} - {Description}";
        }
        #endregion
    }
}