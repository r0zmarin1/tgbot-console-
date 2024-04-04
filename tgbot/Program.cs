using Newtonsoft.Json.Linq;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tgbot;

internal class Program
{
    static CancellationToken token = new CancellationToken();
    private static void Main()
    {
        Host kissabot = new Host("6888221290:AAH4uGzCC-9enq2KpdS0Iaigdiot4UHDv-Y");
        kissabot.Start();
        kissabot.OnMessage += OnMessage;
        Console.ReadLine();
    }

    private static async void OnMessage(ITelegramBotClient client, Update update)
    {
        if (update.Message?.Text == "пошел нахуй")
        {
            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 833690650, "сам иди");
        }
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] {new KeyboardButton[] { "ты бот?" }, new KeyboardButton[] { "кто ты" },})
        {
            ResizeKeyboard = true
        };

        
        Message sentMessage = await client.SendTextMessageAsync(update.Message?.Chat.Id, "я не бот", replyMarkup: replyKeyboardMarkup, cancellationToken: token );


    }
}
