using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace KE03_INTDEV_SE_2_Base.Models;


public class EmailSender
{
    private readonly string smtpServer;
    private readonly int smtpPort;
    private readonly string smtpUsenamer;
    private readonly string smtpPassword;

    public EmailSender(IConfiguration configuration)
    {
        smtpServer = configuration.GetValue<string>("SmtpSettings:SmtpServer", "");
        smtpPort = configuration.GetValue<int>("SmtpSettings:SmtpPort", 0);
        smtpUsenamer = configuration.GetValue<string>("SmtpSettings:SmtpUsername", "");
        smtpPassword = configuration.GetValue<string>("SmtpSettings:SmtpPassword", "");
    }

    public async Task sendEmailAsync(string senderName, string senderEmail, string toName, string toEmail,
        string subject, string textContent)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(senderName, senderEmail));
        message.To.Add(new MailboxAddress(toName, toEmail));
        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = textContent
        };

        using (var client = new SmtpClient())
        {
            client.Connect(smtpServer, smtpPort, false);

            client.Authenticate(smtpUsenamer, smtpPassword);

            try
            {
                var result = client.Send(message);
                Console.WriteLine($"Email Sender OK: \n + {result}");
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email Sender Failure: \n + {ex.ToString}");
            }
        }
    }
}
