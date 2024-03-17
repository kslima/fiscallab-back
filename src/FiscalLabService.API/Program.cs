using System.Text.Json.Serialization;
using FiscalLabService.API.Handlers;
using FiscalLabService.App.Extensions;
using FiscalLabService.Repository.PostgreSql.Extensions;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddUserSecrets<Program>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services
    .AddSqLiteRepositoryDependencies(builder.Configuration)
    .AddAppDependencies(builder.Configuration);

const string devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, policyBuilder => {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}

app.UseForwardedHeaders();
app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler();

app.Run();