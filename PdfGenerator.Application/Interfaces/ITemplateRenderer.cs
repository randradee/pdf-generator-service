namespace PdfGenerator.Application.Interfaces;

public interface ITemplateRenderer
{
    string Render(string template, object data);
}