using Newtonsoft.Json.Linq;
using System.Data.Common;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tgbot;

class LastMessage
{
    public IReplyMarkup replyMarkup;
    public string file;
    public string text;
}
internal class Program
{
    static CancellationToken token = new CancellationToken();
    static Host? kissabot;
    private static void Main()
    {
        kissabot = new Host("6888221290:AAH4uGzCC-9enq2KpdS0Iaigdiot4UHDv-Y");
        kissabot.Start();
        kissabot.OnMessage += OnMessage;
        Console.ReadLine();
    }
    static Dictionary<long, LastMessage> lastButtons = new();

    static LastMessage SetLastButtons(long user, IReplyMarkup buttons, string file, string text)
    {
        var data = new LastMessage { replyMarkup = buttons, file = file, text = text };
        if (lastButtons.ContainsKey(user))
            lastButtons[user] = data;
        else
            lastButtons.Add(user, data);
        return data;
    }
    static ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] { new KeyboardButton[] { "новый заказ" }, new KeyboardButton[] { "меню" }, new KeyboardButton[] { "статус заказа" } })
    {
        ResizeKeyboard = true
    };
    static LastMessage GetLastButtons(long user)
    {
        if (lastButtons.ContainsKey(user))
            return lastButtons[user];
        else
        {
            return new LastMessage { replyMarkup = replyKeyboardMarkup , file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg", text = "На связи Кисса-бот!\nВыбери нужную команду;)" };
        }
    }
    private static async void OnMessage(ITelegramBotClient client, Update update)
    {

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
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "назад", callbackData: "toBack"),
            },
        });

        InlineKeyboardMarkup adds = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "альтернативное молоко", callbackData: "alternative_milk"),
                InlineKeyboardButton.WithCallbackData(text: "сироп", callbackData: "syrup"),
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "авторский напиток", callbackData: "author_drinks"),
                InlineKeyboardButton.WithCallbackData(text: "выпечка", callbackData: "bakery"),
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "назад", callbackData: "toBack"),
            },
        });

        InlineKeyboardMarkup special_menu = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "кофя", callbackData: "special_coffee"),
                InlineKeyboardButton.WithCallbackData(text: "не кофя", callbackData: "another_coffee"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "назад", callbackData: "toBack"),
            },
        });
        string file, text;
        LastMessage data = null;
        switch (update.CallbackQuery?.Data)
        {
            case "toBack":
                data = GetLastButtons(update.CallbackQuery.From.Id);
                break;
            case "base_menu":
                file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/base_menu.jpg";
                text = "супер! что дальше?";
                data = SetLastButtons(update.CallbackQuery.From.Id, base_menu, file, text);
                break;
            case "adds":
                file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/adds.png";
                text = "супер! что дальше?";
                data = SetLastButtons(update.CallbackQuery.From.Id, adds, file, text);
                break;
            case "special_menu":
                file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/special.png";
                text = "супер! что дальше?";
                data = SetLastButtons(update.CallbackQuery.From.Id, special_menu, file, text);
                break;
        }
        if (data != null)
            await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri(data.file), caption: data.text, replyMarkup: data.replyMarkup, cancellationToken: token);

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
