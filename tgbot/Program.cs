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
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] { new KeyboardButton[] { "новый заказ" }, new KeyboardButton[] { "меню" }, new KeyboardButton[] { "статус заказа" } })
        {
            ResizeKeyboard = true
        };

        if (update.Message?.Text == "/start")
        {
            await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri(""), caption: "на связи Кисса-бот! чтобы заказать наш Кисса-напиток, нажми кнопку новый заказ, а чтобы глянуть меню, нажми кнопку меню. а если ты уже ожидаешь свой заказ, нажми статус заказа", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
            //await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 833690650, "на связи Кисса-бот! чтобы заказать наш Кисса-напиток, нажми кнопку новый заказ, а чтобы глянуть меню, нажми кнопку меню. а если ты уже ожидаешь свой заказ, нажми статус заказа", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
        }

        if (update.Message?.Text == "новый заказ")
        {
            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 833690650, "данная функция недоступна", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
        }

        if (update.Message?.Text == "меню")
        {
            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 833690650, "данная функция недоступна", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
        }

     
    }
}
