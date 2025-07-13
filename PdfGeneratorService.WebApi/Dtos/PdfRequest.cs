using System.Text.Json;

namespace PdfGeneratorService.WebApi.Dtos;

public class PdfRequest
{
    // public string Nome { get; set; } =  string.Empty;
    public string TemplateHtml { get; set; } = string.Empty;
    public JsonElement Data { get; set; }
}