using Microsoft.Playwright;
using PdfGeneratorService.Application.Interfaces;

namespace PdfGeneratorService.Infrastructure.Services;

public class PdfGenerator : IPdfGenerator
{
    private static IBrowser? _browser;

    public PdfGenerator()
    {
        _ = EnsureBrowserInitialized();
    }

    private static async Task EnsureBrowserInitialized()
    {
        if (_browser is null)
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
        }
    }

    public async Task<byte[]> GeneratePdfAsync(string htmlContent)
    {
        await EnsureBrowserInitialized();
        
        var context = await _browser!.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.SetContentAsync(htmlContent);

        var pdfBytes = await page.PdfAsync(new PagePdfOptions
        {
            Format = "A4",
            Margin = new Margin
            {
                // TODO: pegar margens abnt
                Left = "10px",
                Top = "10px",
                Right = "10px",
                Bottom = "10px"
            }
        });
        await context.CloseAsync();

        return pdfBytes;
    }
}