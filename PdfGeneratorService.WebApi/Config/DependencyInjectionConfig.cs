using System.Reflection;
using PdfGeneratorService.Application.Abstractions;
using PdfGeneratorService.Application.Interfaces.Pdf;
using PdfGeneratorService.Infrastructure.Services.Pdf;

namespace PdfGeneratorService.WebApi.Config;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ITemplateRenderer, TemplateRenderer>();
        services.AddSingleton<IPdfGenerator, PdfGenerator>();

        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CommandBase<>).Assembly));

        services.AddRepositoriesFromAssembly(typeof(DependencyInjectionConfig).Assembly);

        return services;
    }

    private static IServiceCollection AddRepositoriesFromAssembly(this IServiceCollection services, Assembly webApiAssembly)
    {
        var infraAssembly = Assembly.Load("PdfGeneratorService.Infrastructure");

        var types = infraAssembly.GetTypes();

        var repositories = types
            .Where(type => type is { IsClass: true, IsAbstract: false } && type.Name.EndsWith("Repository"))
            .Select(impl => new
            {
                Interface = impl.GetInterface($"I{impl.Name}"),
                Implementation = impl
            })
            .Where(x => x.Interface != null);

        foreach (var repo in repositories)
        {
            services.AddScoped(repo.Interface!, repo.Implementation);
        }

        return services;
    }
}