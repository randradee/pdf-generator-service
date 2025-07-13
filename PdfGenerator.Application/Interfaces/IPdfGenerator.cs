namespace PdfGenerator.Application.Interfaces;

public interface IPdfGenerator
{
    Task<byte[]> GeneratePdfAsync(string htmlContent);
}