using System;
using Kumi.Core.Tools;
using Kumi.Core.Tools.Interfaces;
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

        services.AddScoped<IToolQueryActions, ToolActions>();
        services.AddScoped<IToolCommandActions, ToolActions>();

        services.AddScoped<ChatService>();

        return services;
    }
}
