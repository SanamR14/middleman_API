using System;
namespace middleman.Models
{
	public class Seller
	{
        public Guid Id { get; set; }
        public string email { get; set; }
        public string S_Username { get; set; }
        public string S_Password { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string contact { get; set; }
        public string category { get; set; }
    }
}

