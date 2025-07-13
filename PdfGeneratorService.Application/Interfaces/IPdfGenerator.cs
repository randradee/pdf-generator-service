namespace PdfGeneratorService.Application.Interfaces;

public interface IPdfGenerator
{
    Task<byte[]> GeneratePdfAsync(string htmlContent);
}