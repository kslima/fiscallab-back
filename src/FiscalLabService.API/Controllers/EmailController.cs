using FiscalLabService.App.Documents;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("email")]
public class EmailController(IEmailSender emailSender, IVisitService visitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendAsync([FromBody] EmailModel model)
    {
        var visit = await visitService.GetByIdAsync("69cdcef7-3670-4884-b73d-24f5edf37ed9");
        
        var pdf = new VisitDocument(visit.Data!);
        var pdfBytes = pdf.GeneratePdf();
        
        await emailSender.SendEmailAsync(model);
        return Ok();
    }
}