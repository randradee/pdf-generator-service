using HandlebarsDotNet;
using PdfGeneratorService.Application.Interfaces.Pdf;

namespace PdfGeneratorService.Infrastructure.Services.Pdf;

public class TemplateRenderer : ITemplateRenderer
{
    public string Render(string template, object data)
    {
        var compiled = Handlebars.Compile(template);
        return compiled(data);
    }
}