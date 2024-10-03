using System;
using System.ComponentModel.DataAnnotations;

namespace middleman.Models
{
	public class Product
	{
       
        public string category { get; set; }
        public string product { get; set; }
        public string productName { get; set; }
        [Key]
        public string price { get; set; }
        public string unitsAvailable { get; set; }
        public string image { get; set; }
        public string unitQuantity { get; set; }
       
        
    }
}

