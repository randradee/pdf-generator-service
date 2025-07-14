using MediatR;
using Microsoft.AspNetCore.Mvc;
using PdfGeneratorService.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using PdfGeneratorService.Application.Features.Pdf.Commands;

namespace PdfGeneratorService.WebApi.Controllers;

[ApiController]
[Route("api/pdf")]
public class PdfController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Generate([FromBody] PdfRequest request)
    {
        var pdfBytes = await mediator.Send(new GeneratePdfCommand(request.TemplateHtml, request.Data));
        Response.Headers.Append("Content-Disposition", "attachment; filename=documento.pdf");
        return File(pdfBytes, "application/pdf");
    }
}