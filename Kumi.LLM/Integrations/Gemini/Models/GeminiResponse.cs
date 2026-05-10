namespace Kumi.LLM.Integrations.Gemini.Models;

public class GeminiResponse
{
    public required GeminiCandidate[] Candidates { get; set; }
}

public class GeminiCandidate
{
    public required GeminiMessage Content { get; set; }
}
