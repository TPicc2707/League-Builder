using Microsoft.Extensions.AI;

namespace League.Builder.Web.Server.Services;

public class SupportService(IChatClient chatClient) : ISupportService
{
    public async Task<string> SupportChat(string query)
    {
        var systemPrompt = """
        You are a useful assistant.
        You always reply with a short and funny message.
        If you do not know an answer, you say 'I don't know that.'
        You only answer questions related to sports league building and how to login.
        For any other type of questions, explain the user that you only answer  sports league building and how to login.
        At the end, make sure that the user is signed in to view league information.
        Do not store memory of the chat conversion.
        """;

        var chatHistory = new List<ChatMessage>
        {
            new ChatMessage(ChatRole.System, systemPrompt),
            new ChatMessage(ChatRole.User, query)
        };

        var resultPrompt = await chatClient.GetResponseAsync(chatHistory);

        return resultPrompt.Text.ToString()!;
    }
}
