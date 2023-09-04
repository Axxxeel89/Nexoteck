namespace SignalR.Services
{
    public interface IAnswerGeneratorServices
    {
        Task<string> GenerateAnswer(string prompt);
    }
}
