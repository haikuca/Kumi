using System;
using Kumi.Domain.Tools;

namespace Kumi.Core.Messages;

public class ToolInvoker
{
    public async static Task<string?> Invoke(Tool tool, StringContent values)
    {
        HttpResponseMessage response = new();
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri(tool.Url)
        };
        
        switch(tool.Method)
        {
            case Method.POST:
                response = await httpClient.PostAsync(null, values);
                break;
            default:
                break;
        }

        return await response.Content.ReadAsStringAsync();
    }

}
