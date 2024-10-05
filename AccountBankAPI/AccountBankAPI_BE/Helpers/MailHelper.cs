using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace DemoSession2_C2212L.Helpers;

public class MailHelper
{
    private IConfiguration configuration;
    public MailHelper(IConfiguration configuration)
    {
        this.configuration = configuration; 
    }

    public bool Send(string from, string to, string subject, string body)
    {
        try
        {
            var host = configuration["Gmail:Host"];
            var port = int.Parse(configuration["Gmail:Port"]);
            var username = configuration["Gmail:Username"];
            var password = configuration["Gmail:Password"];
            var enable = bool.Parse(configuration["Gmail:SMTP:starttls:enable"]);
            var smtpClient = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = enable,
                Credentials = new NetworkCredential(username, password),
            };
            var mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
            return true;
        }
        catch (Exception ex)
        {
            {
                Debug.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}
