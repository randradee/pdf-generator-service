using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdfGenerator.Application.Interfaces;
using PdfGenerator.Application.UseCases;
using PdfGeneratorService.WebApi.Dtos;
using PdfGeneratorService.WebApi.Extensions;

namespace PdfGeneratorService.WebApi.Controllers;

[ApiController]
[Route("api/pdf")]
public class PdfController(GeneratePdfUseCase generatePdfUseCase) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Generate([FromBody] PdfRequest request)
    {
        var dataDict = request.Data.ToDictionary();
        var pdfBytes = await generatePdfUseCase.ExecuteAsync(request.TemplateHtml, dataDict);
        
        Response.Headers.Append("Content-Disposition", "attachment; filename=documento.pdf");
        return File(pdfBytes, "application/pdf");
    }
}