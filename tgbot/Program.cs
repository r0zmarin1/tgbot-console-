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

        InlineKeyboardMarkup newOrder = new(new[]
        {
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "база", callbackData: "base_menu"),
                InlineKeyboardButton.WithCallbackData(text: "спец/гик/артерское", callbackData: "special_menu"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "добавки", callbackData: "adds"),
                InlineKeyboardButton.WithCallbackData(text: "назад", callbackData: "toBack"),
            },
        });

        InlineKeyboardMarkup base_menu = new(new[]
        {
            new[]
            {
            InlineKeyboardButton.WithCallbackData(text: "кофя", callbackData: "coffee"),
            InlineKeyboardButton.WithCallbackData(text: "иное", callbackData: "another"),
            },
        }) ;

        switch (update.CallbackQuery?.Data)
        {
            case "toBack":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;
            case "base_menu":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/base.png"), caption: "супер! что дальше?", replyMarkup: base_menu, cancellationToken: token);
                break;
        }

        switch (update.Message?.Text?.ToLower())
        {
            case "/start":
                await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;
            case "новый заказ":
                await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/menu.jpeg"), caption: "глянь меню и выбери категорию", replyMarkup: newOrder, cancellationToken: token);
                break;
            case "меню":
                await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/menu.jpeg"), replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;
            case "статус заказа":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 833690650, "данная функция недоступна", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;
            case "22":
                await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;
            
        }


    }
}
