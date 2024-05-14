﻿using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tgbot;
using tgbot.DB;

internal class Program : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    //private ObservableCollection<DrinkOrder> drinkOrder;
    //private ObservableCollection<Adds> adds;
    //private ObservableCollection<Customer> customer;
    //private ObservableCollection<Drinks> drinks;
    //private ObservableCollection<Category> category;

    //public ObservableCollection<DrinkOrder> DrinkOrder
    //{
    //    get => drinkOrder;
    //    set
    //    {
    //        drinkOrder = value;
    //        PropertyChanged?.Invoke(this,
    //                new PropertyChangedEventArgs(nameof(DrinkOrder)));
    //    }
    //}
    //public ObservableCollection<Adds> Adds
    //{
    //    get => adds;
    //    set
    //    {
    //        adds = value;
    //        PropertyChanged?.Invoke(this,
    //                new PropertyChangedEventArgs(nameof(Adds)));
    //    }
    //}
    //public ObservableCollection<Customer> Customer
    //{
    //    get => customer;
    //    set
    //    {
    //        customer = value;
    //        PropertyChanged?.Invoke(this,
    //                            new PropertyChangedEventArgs(nameof(Customer)));
    //    }
    //}
    //public ObservableCollection<Drinks> Drinks
    //{
    //    get => drinks;
    //    set
    //    {
    //        drinks = value;
    //        PropertyChanged?.Invoke(this,
    //                            new PropertyChangedEventArgs(nameof(Drinks)));
    //    }
    //}
    //public ObservableCollection<Category> Category
    //{
    //    get => category;
    //    set
    //    {
    //        category = value;
    //        PropertyChanged?.Invoke(this,
    //                             new PropertyChangedEventArgs(nameof(Category)));
    //    }
    //}

    static CancellationToken token = new CancellationToken();
    static Host kissabot;
    private static void Main()
    {
        kissabot = new Host("6888221290:AAH4uGzCC-9enq2KpdS0Iaigdiot4UHDv-Y");
        kissabot.Start();
        kissabot.OnMessage += OnMessage;
        Console.ReadLine();
    }
    //class LastMessage
    //{
    //    public IReplyMarkup replyMarkup;
    //    public string file;
    //    public string text;
    //}

    //static Dictionary<long, LastMessage> lastButtons = new();

    //static LastMessage SetLastButtons(long user, IReplyMarkup buttons, string file, string text)
    //{
    //    var data = new LastMessage {replyMarkup = buttons, file = file, text = text };
    //    if (lastButtons.ContainsKey(user))
    //        lastButtons[user] = data;
    //    else
    //        lastButtons.Add(user, data);
    //    return data;
    //}
    static ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] { new KeyboardButton[] { "новый заказ" }, new KeyboardButton[] { "меню" }, new KeyboardButton[] { "статус заказа" } })
    {
        ResizeKeyboard = true
    };
    //static LastMessage GetLastButtons(long user)
    //{
    //    if (lastButtons.ContainsKey(user))
    //        return lastButtons[user];
    //    else
    //    {
    //        return new LastMessage { replyMarkup = replyKeyboardMarkup, file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg", text = "На связи Кисса-бот!\nВыбери нужную команду;)" };
    //    }
    //}
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
                InlineKeyboardButton.WithCallbackData(text: "иное", callbackData: "another_coffee"),
            },
        }) ;

        InlineKeyboardMarkup adds = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "альтернативное молоко", callbackData: "alternative_milk"),
                InlineKeyboardButton.WithCallbackData(text: "сироп", callbackData: "syrup"),
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "авторский напиток", callbackData: "author_drink"),
                InlineKeyboardButton.WithCallbackData(text: "выпечка", callbackData: "bakery"),
            },
        });

        InlineKeyboardMarkup special_menu = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "кофя", callbackData: "special_coffee"),
                InlineKeyboardButton.WithCallbackData(text: "не кофя", callbackData: "another_special_coffee"),
            },
        });

        InlineKeyboardMarkup coffee = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Американо", callbackData: "americano"),
                InlineKeyboardButton.WithCallbackData(text: "Капучино", callbackData: "cappuchino"),
                InlineKeyboardButton.WithCallbackData(text: "Латте", callbackData: "latte"),
            },
        });
        InlineKeyboardMarkup another_coffee = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Матча Латте", callbackData: "matchalatte"),
                InlineKeyboardButton.WithCallbackData(text: "Чай", callbackData: "tea"),
                InlineKeyboardButton.WithCallbackData(text: "Какао", callbackData: "cacao"),
                InlineKeyboardButton.WithCallbackData(text: "Кисель", callbackData: "kissel"),
            },
        });
        InlineKeyboardMarkup size = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "M", callbackData: "max"),
                InlineKeyboardButton.WithCallbackData(text: "S", callbackData: "small"),
            },
        });

        //string file, text;
        //LastMessage data = null;
        switch (update.CallbackQuery?.Data)
        {
            case "toBack":
                //data = GetLastButtons(update.CallbackQuery.From.Id);
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);

                break;
            case "base_menu":
                ////file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/base_menu.jpg";
                ////text = "супер! что дальше?";
                ////data = SetLastButtons(update.CallbackQuery.From.Id, base_menu, file, text);
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/base_menu.jpg"), caption: "супер! что дальше?", replyMarkup: base_menu, cancellationToken: token);
                break;
            case "adds":
                //file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/adds.png";
                //text = "супер! что дальше?";
                //data = SetLastButtons(update.CallbackQuery.From.Id, adds, file, text);
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/adds.png"), caption: "супер! что дальше?", replyMarkup: adds, cancellationToken: token);

                break;
            case "special_menu":
                //file = "https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/special.png";
                //text = "супер! что дальше?";
                //data = SetLastButtons(update.CallbackQuery.From.Id, special_menu, file, text);
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/special.png"), caption: "супер! что дальше?", replyMarkup: special_menu, cancellationToken: token);
                break;
            
        }
        switch (update.CallbackQuery?.Data)
        {
            case "coffee":
                {
                    string getcoffee = "SELECT title, description, price FROM Drinks";
                    using (MySqlConnector nowgetcoffee = new MySqlCommand(getcoffee, mySqlConnection))
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: coffee, cancellationToken: token);
                }
                break;
            case "americano":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "cappuchino":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "latte":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "another_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: another_coffee, cancellationToken: token);
                break;
        }

        //if (data != null)
        //    await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri(data.file), caption: data.text, replyMarkup: data.replyMarkup, cancellationToken: token);

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
        //string sql = "SELECT d.Id, d.Title, d.Description, d.Price, d.Size, c.Id_category FROM Drinks d, Category c";
        //Drinks = new ObservableCollection<Drinks>(DrinksRepository.Instance.GetDrinks(sql));
        //if (update.CallbackQuery?.Data == "coffee")
        //{
        //    await client.SendTextMessageAsync(update.Message?.Chat.Id, text: sql, cancellationToken: token); 
            
        //}

    }
}
