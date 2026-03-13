using System;
using Kumi.Domain.Tools;
using Kumi.Persistence;
using Kumi.Persistence.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Kumi.Core;

public static class KumiServiceExtension
{
    public static IServiceCollection AddKumiRuntime(this IServiceCollection services)
    {
        services.AddDbContext<KumiDbContext>();
        services.AddHostedService<KumiRuntime>();

        services.AddScoped<IToolRepository, ToolsRepository>();
        services.AddScoped<ToolsService>();

        return services;
    }
}
