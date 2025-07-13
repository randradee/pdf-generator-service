using PdfGenerator.Application.Interfaces;
using PdfGeneratorService.Infrastructure.Services;

namespace PdfGeneratorService.WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ITemplateRenderer, TemplateRenderer>();
            services.AddSingleton<IPdfGenerator, Infrastructure.Services.PdfGenerator>();

            return services;
        }
    }
}