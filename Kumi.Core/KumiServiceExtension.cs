using System;
using Kumi.Domain.Tools;
using Kumi.LLM.Integrations.Ollama;
using Kumi.LLM.Interfaces;
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
        services.AddScoped<ILanguageModel>(model => new Ollama("qwen3.5"));

        services.AddScoped<ToolsService>();
        services.AddScoped<ChatService>();

        return services;
    }
}
