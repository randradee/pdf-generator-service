using MediatR;
using PdfGeneratorService.Application.Features.Pdf.Commands;
using PdfGeneratorService.Application.Interfaces.Pdf;
using PdfGeneratorService.WebApi.Extensions;

namespace PdfGeneratorService.Application.Features.Pdf.Handlers;

public class GeneratePdfCommandHandler(ITemplateRenderer templateRenderer, IPdfGenerator pdfGenerator)
    : IRequestHandler<GeneratePdfCommand, byte[]>
{
    public async Task<byte[]> Handle(GeneratePdfCommand request, CancellationToken cancellationToken)
    {
        var dataDict = request.Data.ToDictionary();
        var html = templateRenderer.Render(request.TemplateHtml, dataDict);
        
        return await pdfGenerator.GeneratePdfAsync(html);
    }
}