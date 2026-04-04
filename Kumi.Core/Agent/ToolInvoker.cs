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
       
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
        );

        switch(tool.Method)
        {
            case Method.GET:
                response = await httpClient.GetAsync("");
                break;
            case Method.POST:
                response = await httpClient.PostAsync("", values);
                break;
            default:
                break;
        }

        return await response.Content.ReadAsStringAsync();
    }

}
