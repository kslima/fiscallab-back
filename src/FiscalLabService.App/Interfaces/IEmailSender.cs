using FiscalLabService.App.Models;

namespace FiscalLabService.App.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(EmailModel model);
}