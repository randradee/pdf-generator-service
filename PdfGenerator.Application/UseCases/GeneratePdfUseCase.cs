using PdfGenerator.Application.Interfaces;

namespace PdfGenerator.Application.UseCases
{
    public class GeneratePdfUseCase(ITemplateRenderer templateRenderer, IPdfGenerator pdfGenerator)
    {
        public async Task<byte[]> ExecuteAsync(string templateHtml, Dictionary<string, object> data)
        {
            var html = templateRenderer.Render(templateHtml, data);
            var pdfBytes = await pdfGenerator.GeneratePdfAsync(html);
            return pdfBytes;
        }
    }
}