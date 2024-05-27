namespace Portifolio.App.Service;

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var fromAddress = new MailAddress("your-email@example.com", "Your Name");
        var toAddress = new MailAddress(toEmail);
        const string fromPassword = "your-email-password";

        var smtp = new SmtpClient
        {
            Host = "smtp.example.com", // Use your smtp server
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
               {
                   Subject = subject,
                   Body = body
               })
        {
            await smtp.SendMailAsync(message);
        }
    }
}