using System;
namespace middleman.Models
{
	public class Product
	{
        public Guid Id { get; set; }
        public string category { get; set; }
        public string product { get; set; }
        public string productName { get; set; }
        public string price { get; set; }
        public string unitsAvailable { get; set; }
        public string image { get; set; }
        public string unitQuantity { get; set; }
        public string description { get; set; }
        
    }
}

