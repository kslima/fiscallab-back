using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Resources;
using FiscalLabService.App.Services;
using FiscalLabService.App.Validators;
using FiscalLabService.Shared.Extensions;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiscalLabService.App.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var validationMessageOptions = configuration
            .GetSection(nameof(ValidationMessageOptions))
            .Get<ValidationMessageOptions>();
        validationMessageOptions ??= new ValidationMessageOptions();
        services.AddSingleton(validationMessageOptions);
        
        services.AddScoped<IValidator<CreatePlantRequest>, CreatePlantRequestValidator>();
        services.AddScoped<IPlantService, PlantService>();
        
        services.AddScoped<IValidator<CreateAssociationRequest>, CreateAssociationRequestValidator>();
        services.AddScoped<IAssociationService, AssociationService>();
        
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IVisitPageService, VisitPageService>();
        services.AddScoped<IVisitService, VisitService>();
        services.AddScoped<ISyncService, SyncService>();
        services.AddScoped<IImageService, ImageService>();
        
        var emailOptions = configuration
            .GetSection(nameof(EmailOptions))
            .Get<EmailOptions>();
        emailOptions ??= new EmailOptions();
        
        emailOptions.From = configuration.GetRequiredValue<string>("EMAIL_FROM");
        emailOptions.DisplayName = configuration.GetRequiredValue<string>("EMAIL_DISPLAY_NAME");
        emailOptions.SmtpServer = configuration.GetRequiredValue<string>("EMAIL_SMTP_SERVER");
        emailOptions.Port = configuration.GetRequiredValue<int>("EMAIL_PORT");
        emailOptions.UserName = configuration.GetRequiredValue<string>("EMAIL_USERNAME");
        emailOptions.Password = configuration.GetRequiredValue<string>("EMAIL_PASSWORD");
        
        services.AddSingleton(emailOptions);
        
        var emailTaskOptions = configuration
            .GetSection(nameof(EmailTaskOptions))
            .Get<EmailTaskOptions>();
        emailTaskOptions ??= new EmailTaskOptions();
        
        emailTaskOptions.CronExpression = configuration.GetRequiredValue<string>("EMAIL_TASK_CRON_EXPRESSION");
        emailTaskOptions.TemplatePath = configuration.GetRequiredValue<string>("VISIT_EMAIL_TEMPLATE_PATH");
        
        services.AddSingleton(emailTaskOptions);
        
        services.AddScoped<IEmailSender, EmailSender>();
        
        services.AddHostedService<EmailTask>();
        return services;
    }
}