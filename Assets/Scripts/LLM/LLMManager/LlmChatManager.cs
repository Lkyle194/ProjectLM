using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LLama;
using LLama.Common;
using LLM.LLMManager.Interface;

namespace LLM.LLMManager
{
    public class LlmChatManager : ILlmChatManager
    {
        private LLamaWeights? _model;
        private LLamaContext? _context;
        private ChatSession? _session;
        private InteractiveExecutor? _executor;
        private ChatHistory _history = new();
        private InferenceParams _inferenceParams = new()
        {
            MaxTokens = 1024,
            AntiPrompts = new List<string> { "User:" }
        };

        public bool IsModelReady => _model != null && _context != null && _session != null;

        public void LoadModel(string modelPath, uint contextSize = 4096, int gpuLayerCount = 5)
        {
            if (!File.Exists(modelPath))
                throw new FileNotFoundException("Modèle introuvable", modelPath);

            var parameters = new ModelParams(modelPath)
            {
                ContextSize = contextSize,
                GpuLayerCount = gpuLayerCount
            };

            _model = LLamaWeights.LoadFromFile(parameters);
            _context = _model.CreateContext(parameters);
            _executor = new InteractiveExecutor(_context);
            _history = new ChatHistory();
            _session = new ChatSession(_executor, _history);
        }

        public void SetSystemPrompt(string systemPrompt)
        {
            if (!IsModelReady)
                throw new InvalidOperationException("Le modèle n'est pas chargé.");

            _history.AddMessage(AuthorRole.System, systemPrompt);
        }

        public async Task<string> SendMessageWithStreamAsync(
            string message,
            Action<string>? onToken = null,
            CancellationToken cancellationToken = default)
        {
            if (!IsModelReady)
                throw new InvalidOperationException("Le modèle n'est pas prêt.");

            var builder = new StringBuilder();

            await foreach (var token in _session!.ChatAsync(
                               new ChatHistory.Message(AuthorRole.User, message),
                               _inferenceParams,
                               cancellationToken))
            {
                onToken?.Invoke(token);    // Callback pour afficher ou streamer
                builder.Append(token);     // Construit la réponse finale
            }

            return builder.ToString();     // Retourne la réponse complète
        }



        public void ResetChat()
        {
            if (_executor == null)
                throw new InvalidOperationException("Executor manquant");

            _history = new ChatHistory();
            _session = new ChatSession(_executor, _history);
        }
    }
}
