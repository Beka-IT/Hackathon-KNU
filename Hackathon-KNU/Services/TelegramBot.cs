
using Telegram.Bot;

namespace Hackathon_KNU.Services;

public class TelegramBotService
{
    private const string token = "6415923264:AAHP9viF0V6ZZG-E6tsj-_iwgaCCu2fS-SU";
    private const string chatId = "-4006878103";

    public async Task SendMessage(string message)
    {
        TelegramBotClient bot = new TelegramBotClient(token);
        await bot.SendTextMessageAsync(chatId, message);
    }
}