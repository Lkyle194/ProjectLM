using System;
using System.Threading;
using System.Threading.Tasks;

namespace LLM.LLMManager.Interface
{
    public interface ILlmChatManager
    {
        bool IsModelReady { get; }
        void LoadModel(string modelPath, uint contextSize = 4096, int gpuLayerCount = 5);
        void SetSystemPrompt(string systemPrompt);

        Task<string> SendMessageWithStreamAsync(string message, Action<string>? onToken = null, CancellationToken cancellationToken = default);
    
        void ResetChat();
    }
}