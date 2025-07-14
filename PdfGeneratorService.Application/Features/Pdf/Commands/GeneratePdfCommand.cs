using System.Text.Json;
using PdfGeneratorService.Application.Abstractions;

namespace PdfGeneratorService.Application.Features.Pdf.Commands;

public class GeneratePdfCommand : CommandBase<byte[]>
{
    public string TemplateHtml { get; }
    public JsonElement Data { get; }

    public GeneratePdfCommand(string templateHtml, JsonElement data)
    {
        TemplateHtml = templateHtml;
        Data = data;
    }
}