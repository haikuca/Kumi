using System;
using Kumi.Core.Tools;
using Kumi.Core.Tools.Interfaces;
using Kumi.Core.Messages;
using Kumi.Core.Agent;
using Kumi.Domain.Tools.Interfaces;
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

        services.AddScoped<IToolRepository, ToolRepository>();
//        services.AddScoped<ILanguageModel>(model => new Ollama("huihui_ai/qwen3.5-abliterated"));
        services.AddScoped<ILanguageModel>(model => new Ollama("qwen3.5"));

        services.AddScoped<IToolQueryActions, ToolActions>();
        services.AddScoped<IToolCommandActions, ToolActions>();

        services.AddScoped<ChatService>();
        //services.AddScoped<MessageHistory>();

        return services;
    }
}
