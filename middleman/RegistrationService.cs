using System;
using System.Security.Cryptography;
using System.Text;
using middleman.Models;

namespace middleman
{
	public interface IRegistrationService
	{
		bool RegisterUser(User user);
		bool RegisterSeller(Seller seller);
	}
	public class RegistrationService : IRegistrationService
    {
		private readonly MiddlemanDbContext _context;
        public RegistrationService(MiddlemanDbContext context)
		{
			_context = context;
		}
		public bool RegisterUser(User user)
		{
			user.U_Password = HashPassword(user.U_Password);
			_context.Users.Add(user);
			_context.SaveChanges();
			return true;
		}
        public bool RegisterSeller(Seller seller)
        {
            seller.S_Password = HashPassword(seller.S_Password);
            _context.Sellers.Add(seller);
            _context.SaveChanges();
            return true;
        }
        private string HashPassword(string password)
        {
			using (var sha256 = SHA256.Create())
			{
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
			}
        }
    }
}

