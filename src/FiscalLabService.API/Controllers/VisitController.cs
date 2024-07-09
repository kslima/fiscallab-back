using FiscalLabService.App.Documents;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("visits")]
public class VisitController : ControllerBase
{
    private readonly IVisitService _visitService;
    private readonly IVisitRepository _visitRepository;
    private readonly IImageService _imageService;

    public VisitController(
        IVisitService visitService,
        IVisitRepository visitRepository,
        IImageService imageService)
    {
        _visitService = visitService;
        _visitRepository = visitRepository;
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateManyAsync([FromBody] VisitModel[] visitModels)
    {
        var result = await _visitService.CreateManyAsync(visitModels);
        return Ok(result);
    }
    
    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertAsync([FromBody] List<VisitModel> visitModels)
    {
        var result = await _visitService.UpsertAsync(visitModels);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync([FromQuery] VisitQueryParameters parameters)
    {
        var result = await _visitRepository.ListAsync(parameters.AsVisitParameters());
        var response = Result<List<Visit>>.Success(result);
        response.Metadata = result.AsMetadata();
        
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        var response = await _visitService.DeleteAsync(id);
        return Accepted(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        var visit = await _visitService.GetByIdAsync(id);
        return Ok(visit);
    }
    
    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GeneratePdfAsync([FromRoute] string id)
    {
        var visit = await _visitService.GetByIdAsync(id);
        var images = await _imageService.ListByVisitAsync(id);
        var imageDtos = images.Data!
            .Select(x => x.MapToImageDto())
            .ToList();
        
        var pdf = new VisitDocument(visit.Data!, imageDtos);
        var pdfBytes = pdf.GeneratePdf();
        return File(pdfBytes, "application/pdf", "visit.pdf");
    }
    
    [HttpPost("{id}/images")]
    public async Task<IActionResult> ReplaceImagesAsync([FromRoute(Name = "id")] string visitId)
    {
        var images = new List<ImageDto>();
        var formCollection = await Request.ReadFormAsync();
        var files = formCollection.Files;
        foreach (var file in files.Where(f => f.Length > 0))
        {
            var imageId = file.Name["file_".Length..];
            var name = formCollection[$"name_{imageId}"].ToString();
            var description = formCollection[$"description_{imageId}"].ToString();
            
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            images.Add(new ImageDto
            {
                Id = imageId,
                Name = name,
                Description = description,
                Data = memoryStream.ToArray()
            });
        }

        var response = await _imageService.ReplaceImagesAsync(visitId, images);
        return Ok(response);
    }
    
    [HttpGet("{id}/images")]
    public async Task<IActionResult> ListImagesAsync([FromRoute(Name = "id")] string id)
    {
        var images = await _imageService.ListByVisitAsync(id);
        return Ok(images);
    }
    
    [HttpDelete("{id}/images/{imageId}")]
    public async Task<IActionResult> DeleteImageAsync([FromRoute] string id, [FromRoute] string imageId)
    {
        var result = await _imageService.DeleteAsync(id, imageId);
        return Accepted(result);
    }
}