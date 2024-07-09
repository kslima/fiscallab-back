using FiscalLabService.App.Documents;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.App.Resources;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Enums;
using FiscalLabService.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;
using QuestPDF.Fluent;

namespace FiscalLabService.App.Services;

public class EmailTask : BackgroundService
{
    private const string Subject = "Relatório de Visita Analítica";
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<EmailTask> _logger;
    private readonly CrontabSchedule _schedule;
    private DateTime _nextRun;
    private readonly EmailTaskOptions _emailTaskOptions;


    public EmailTask(
        IServiceScopeFactory serviceScopeFactory,
        EmailTaskOptions emailTaskOptions,
        ILogger<EmailTask> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;

        _emailTaskOptions = emailTaskOptions;
        _schedule = CrontabSchedule.Parse(_emailTaskOptions.CronExpression,
            new CrontabSchedule.ParseOptions { IncludingSeconds = true });
        _nextRun = _schedule.GetNextOccurrence(DateTime.Now.ToUniversalTime());
    }

    private int UntilNextExecution() =>
        Math.Max(0, (int)_nextRun.Subtract(DateTime.Now.ToUniversalTime()).TotalMilliseconds);
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await SendEmailsAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error on run worker");
            }
            finally
            {
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now.ToUniversalTime());
                await Task.Delay(UntilNextExecution(), stoppingToken);
            }
        }
    }

    private async Task SendEmailsAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var visitRepository = scope.ServiceProvider.GetRequiredService<IVisitRepository>();
        var visitsToSend = await visitRepository.GetAllMarkedForMailing();
        
        var imageRepository = scope.ServiceProvider.GetRequiredService<IImageRepository>();

        var visitIds = visitsToSend.Select(x => x.Id).ToList();
        var images = await imageRepository.ListByVisitsAsync(visitIds);
        
        _logger.LogInformation("Visits to send: {VisitToSend}", visitsToSend.Count);
        if (visitsToSend.Count == 0) return;
        var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
        
        foreach (var visit in visitsToSend)
        {
            try
            {
                var visitImages = images
                    .Where(x => x.VisitId.Equals(visit.Id))
                    .Select(x => x.MapToImage())
                    .ToList();
                
                var email = CreateEmail(visit, visitImages);
                await emailSender.SendEmailAsync(email);
                await visitRepository.MarkAsSentByEmail(visit.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error: {ErrorMessage}", e.Message);
                throw;
            }
        }
    }
    private EmailModel CreateEmail(Visit visit, List<ImageDto> images)
    {
        var bodyContent = File
            .ReadAllText(_emailTaskOptions.TemplatePath)
            .Replace("{greeting}", GetGreeting());
        
        var pdf = new VisitDocument(visit.AsVisitDto(), images);
        var pdfBytes = pdf.GeneratePdf();
        
        var attachment = new EmailAttachmentModel
        {
            Content = pdfBytes,
            Name = "visit.pdf"
        };

        var recipients = visit.BasicInformation.Association.Emails.Select(x => x.Address).ToArray();
        var model = new EmailModel
        {
            Subject = Subject,
            Recipients = recipients,
            Attachment = attachment,
            Body = bodyContent
        };
        
        return model;
    }
    
    private static string GetGreeting()
    {
        var currentUtcTime = DateTime.UtcNow;
        
        var saoPauloTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        var currentSaoPauloTime = TimeZoneInfo.ConvertTimeFromUtc(currentUtcTime, saoPauloTimeZone);
        var hour = currentSaoPauloTime.Hour;
        return hour switch
        {
            >= 5 and < 12 => "Bom Dia",
            >= 12 and < 18 => "Boa Tarde",
            _ => "Boa Noite"
        };
    }
}