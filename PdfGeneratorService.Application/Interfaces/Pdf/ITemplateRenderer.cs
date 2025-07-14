namespace PdfGeneratorService.Application.Interfaces.Pdf;

public interface ITemplateRenderer
{
    string Render(string template, object data);
}