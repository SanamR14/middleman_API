using System;
using System.Net;
using System.Net.Mail;
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
			user.u_Password = HashPassword(user.u_Password);
			_context.Users.Add(user);
			_context.SaveChanges();
            SendConfirmationEmail(user.username);
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

        private void SendConfirmationEmail(string userEmail)
        {
            try
            {
                // Set up the SMTP client
                var smtpClient = new SmtpClient("smtp.your-email-provider.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),
                    EnableSsl = true,
                };

                // Create the email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"),
                    Subject = "Registration Confirmation",
                    Body = "<h1>Thank you for registering!</h1><p>Your registration was successful.</p>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(userEmail);

                // Send the email synchronously
                smtpClient.Send(mailMessage);

                Console.WriteLine("Confirmation email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
                // Handle exceptions (log them, rethrow them, etc.)
            }
        }

    }
}

