using System.Text;
using OpenAI;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using RestSharp;
using ChatMessage = OpenAI_API.Chat.ChatMessage;

namespace Hackathon_KNU.Services;

public class ChatGptService
{
    private const string ApiKey = "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";
    private const string Endpoint ="https://api.openai.com/v1/chat/completions";

    public static async Task<string> SendMessage(string message)
    {
        var openAi = new OpenAIAPI(new APIAuthentication(ApiKey));

        var conversation = openAi.Chat.CreateConversation();
        conversation.AppendMessage(new ChatMessage{ Role = ChatMessageRole.User, Content = message});
        var response = await conversation.GetResponseFromChatbotAsync();
        return response;
    }

}