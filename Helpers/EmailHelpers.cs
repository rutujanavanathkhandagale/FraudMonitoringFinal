using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace FraudMonitoringSystem.Helpers
{
   

    public class EmailHelper
    {
        private readonly SmtpSettings _settings;

        public EmailHelper(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendConfirmationEmailAsync(string toEmail, int customerId)
        {
            using var mail = new MailMessage();
            mail.From = new MailAddress(_settings.SenderEmail);
            mail.To.Add(toEmail);

            mail.Subject = "Welcome to FraudShield – Your Account is Ready";

            mail.Body = $@"
Dear Customer,

Thank you for registering with FraudShield, the real-time fraud monitoring system designed to protect your transactions and provide peace of mind.

Your registration was successful, and your Customer ID is {customerId}. Please keep this ID safe, as it will be required for future logins and support requests.

With FraudShield, you gain:
- Continuous monitoring of suspicious activity
- Instant alerts for potential fraud attempts
- Secure access to your account dashboard

We are committed to safeguarding your digital journey. If you have any questions, please contact our support team at rutujakhandagale2002@gmail.com.

Welcome aboard,
The FraudShield Team
";

            using var smtp = new SmtpClient(_settings.Server)
            {
                Port = _settings.Port,
                Credentials = new System.Net.NetworkCredential(_settings.SenderEmail, _settings.Password),
                EnableSsl = true
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
