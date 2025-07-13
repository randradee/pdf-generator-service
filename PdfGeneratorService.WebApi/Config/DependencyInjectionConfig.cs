using PdfGenerator.Application.Interfaces;
using PdfGenerator.Application.UseCases;
using PdfGeneratorService.Infrastructure.Services;

namespace PdfGeneratorService.WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ITemplateRenderer, TemplateRenderer>();
            services.AddSingleton<IPdfGenerator, Infrastructure.Services.PdfGenerator>();
            
            services.AddSingleton<GeneratePdfUseCase>();

            return services;
        }
    }
}