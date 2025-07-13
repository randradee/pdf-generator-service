using HandlebarsDotNet;
using PdfGenerator.Application.Interfaces;

namespace PdfGeneratorService.Infrastructure.Services;

public class TemplateRenderer : ITemplateRenderer
{
    public string Render(string template, object data)
    {
        var compiled = Handlebars.Compile(template);
        return compiled(data);
    }
}