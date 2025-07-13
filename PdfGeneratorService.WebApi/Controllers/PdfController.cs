using Microsoft.AspNetCore.Mvc;
using PdfGenerator.Application.Interfaces;
using PdfGeneratorService.WebApi.Dtos;

namespace PdfGeneratorService.WebApi.Controllers;

[ApiController]
[Route("api/pdf")]
public class PdfController(ITemplateRenderer templateRenderer, IPdfGenerator pdfGenerator)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Generate([FromBody] PdfRequest request)
    {
        var html = templateRenderer.Render(request.TemplateHtml, request.Data);
        var pdfBytes = await pdfGenerator.GeneratePdfAsync(html);
        return File(pdfBytes, "application/pdf", request.Nome);
    }
}