namespace PdfGeneratorService.Application.Interfaces;

public interface ITemplateRenderer
{
    string Render(string template, object data);
}