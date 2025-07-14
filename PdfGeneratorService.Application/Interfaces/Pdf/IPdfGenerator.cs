namespace PdfGeneratorService.Application.Interfaces.Pdf;

public interface IPdfGenerator
{
    Task<byte[]> GeneratePdfAsync(string htmlContent);
}