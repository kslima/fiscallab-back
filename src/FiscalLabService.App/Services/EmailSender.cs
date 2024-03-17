using System.Net;
using System.Net.Mail;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.App.Resources;
using FiscalLabService.Shared.Extensions;
using Microsoft.Extensions.Logging;

namespace FiscalLabService.App.Services;

public class EmailSender(EmailOptions emailOptions, ILogger<EmailSender> logger) : IEmailSender
{
    public async Task SendEmailAsync(EmailModel model)
    {
        var client = new SmtpClient(emailOptions.SmtpServer, emailOptions.Port);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(emailOptions.UserName, emailOptions.Password);

        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(emailOptions.From, emailOptions.DisplayName);
        
        foreach (var recipient in model.Recipients)
        {
            if (recipient.IsValidEmail())
            {
                mailMessage.To.Add(recipient);
                continue;
            }
            
            logger.LogWarning("'{Email}' is not a valid email address and will be ignored", recipient);
        }
        
        if (model.Attachment is not null)
        {
            var ms = new MemoryStream(model.Attachment.Content);
            mailMessage.Attachments.Add(new Attachment(ms, model.Attachment.Name, model.Attachment.MediaType));
        }

        mailMessage.Subject = model.Subject;
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = model.Body;

        await client.SendMailAsync(mailMessage);
    }
}