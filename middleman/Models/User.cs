using System;
namespace middleman.Models
{
	public class User
	{
        public Guid Id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string u_Password { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string contact { get; set; }
    }
}

