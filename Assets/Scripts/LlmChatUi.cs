using System;
using LLM.LLMManager;
using LLM.LLMManager.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LlmChatUi : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button sendButton;
    public TMP_Text chatText;
    
    private ILlmChatManager _llm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _llm = new LlmChatManager();
        AppendToChat(Application.streamingAssetsPath + "/models/tinyllama-1.1b-chat-v1.0.Q4_K_M.gguf");
        _llm.  LoadModel(Application.streamingAssetsPath + "/models/tinyllama-1.1b-chat-v1.0.Q4_K_M.gguf", 2048, 5);
        _llm.SetSystemPrompt("Tu es une IA immersive pour analyser des comportements...");
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }

    private async void OnSendButtonClicked()
    {
        var userInput = inputField.text;
        if (string.IsNullOrWhiteSpace(userInput)) return;

        AppendToChat("👤 Toi : " + userInput);
        inputField.text = "";

        await _llm.SendMessageWithStreamAsync(userInput, token =>
        {
            AppendToChatLive(token);
        });

        AppendToChat(""); // saut de ligne
    }

    private void AppendToChat(string text)
    {
        chatText.text += text + "\n";
    }

    private void AppendToChatLive(string token)
    {
        chatText.text += token;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
