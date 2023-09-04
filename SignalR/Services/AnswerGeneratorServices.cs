using OpenAI_API;
using OpenAI_API.Completions;

namespace SignalR.Services
{
    public class AnswerGeneratorServices : IAnswerGeneratorServices
    {
        public async Task<string> GenerateAnswer(string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;

            var openApi = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();

            completion.Prompt = prompt;
            completion.MaxTokens = 4000;

            var result = await openApi.Completions.CreateCompletionAsync(completion);

            if (result != null)
            {
                foreach (var item in result.Completions)
                {
                    answer = item.Text; 
                }
            }

            return answer;
        }
    }
}
