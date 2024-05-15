using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tgbot;
using Update = Telegram.Bot.Types.Update;

internal class Program : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;


    static CancellationToken token = new CancellationToken();
    static Host kissabot;
    private static void Main()
    {
        kissabot = new Host("6888221290:AAH4uGzCC-9enq2KpdS0Iaigdiot4UHDv-Y");
        kissabot.Start();
        kissabot.OnMessage += OnMessage;
        Console.ReadLine();
    }
   
    static ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] { new KeyboardButton[] { "новый заказ" }, new KeyboardButton[] { "меню" }, new KeyboardButton[] { "статус заказа" } })
    {
        ResizeKeyboard = true
    };

    public static string Drink { get; private set; }

    private static async void OnMessage(ITelegramBotClient client, Update update)
    {
        string connection = "server=localhost;port=3306;user=root;password=Masha0325;database=coffeeshop;Character Set=utf8mb4;";
        MySqlConnection connect = new MySqlConnection(connection);
        OpenConnection();

        bool OpenConnection()
        {
            try
            {
                connect.Open();
                Console.WriteLine("connection open!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        var message = update.Message;

        

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
        InlineKeyboardMarkup special_coffee = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Для гуля", callbackData: "dlyagyliya"),
                InlineKeyboardButton.WithCallbackData(text: "Очень странные дела", callbackData: "ochenstranniedela"),
                InlineKeyboardButton.WithCallbackData(text: "Беннет", callbackData: "bennet"),
                
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Хината Шоё", callbackData: "hinatashoe"),
                InlineKeyboardButton.WithCallbackData(text: "Kissa", callbackData: "kissa"),
            },
        });
        InlineKeyboardMarkup another_special_coffee = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Хакку", callbackData: "hakku"),
                InlineKeyboardButton.WithCallbackData(text: "Сяо", callbackData: "xiao"),
                InlineKeyboardButton.WithCallbackData(text: "Рэй", callbackData: "rei"),
                InlineKeyboardButton.WithCallbackData(text: "Mood L", callbackData: "moodl"),
            },
             new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Барби стайл", callbackData: "barbiestyle"),
                InlineKeyboardButton.WithCallbackData(text: "Мята и шоколад", callbackData: "myataishocolad"),
                InlineKeyboardButton.WithCallbackData(text: "Ведьмачий сбор", callbackData: "vedmachiysbor"),
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

        switch (update.CallbackQuery?.Data)
        {
            case "toBack":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);

                break;
            case "base_menu":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/base_menu.jpg"), caption: "супер! что дальше?", replyMarkup: base_menu, cancellationToken: token);
                break;
            case "adds":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/adds.png"), caption: "супер! что дальше?", replyMarkup: adds, cancellationToken: token);

                break;
            case "special_menu":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/special.png"), caption: "супер! что дальше?", replyMarkup: special_menu, cancellationToken: token);
                break;
            
        }


        switch (update.CallbackQuery?.Data)
        {
            case "max":
                string sql = "SELECT title FROM drinks WHERE size = 'M'";
                using (MySqlCommand getMdrinks = new MySqlCommand(sql, connect))
                {
                    using (MySqlDataReader drinks = getMdrinks.ExecuteReader())
                    {
                        Drink = drinks.GetString("title");
                        
                        await client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, Drink, cancellationToken: token);
                        //await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/menu.jpeg"), caption: "глянь меню и выбери категорию", replyMarkup: newOrder, cancellationToken: token);
                    }
                }
            break;
            case "coffee":
                {
                    string getcoffee = "SELECT title, description, price FROM Drinks WHERE user_id = @id";
                    using (MySqlCommand nowgetcoffee = new MySqlCommand(getcoffee, connect))
                    {
                        nowgetcoffee.Parameters.Add(new MySqlParameter("id", update.CallbackQuery.Message.Chat.Id));
                    }
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: coffee, cancellationToken: token);
                }
                break;
            case "americano":
                {
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                    if(update.CallbackQuery?.Data == "max")
                    {
                        await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "хахаха работает!",  cancellationToken: token);

                    }
                }
                break;
            case "cappuchino":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!",  cancellationToken: token);
                break;
            case "latte":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "another_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: another_coffee, cancellationToken: token);
                break;
            case "matchalatte":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "tea":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "cacao":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!" , cancellationToken: token);
                break;
            case "kissel":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "special_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: special_coffee, cancellationToken: token);
                break;
            case "dlyagyliya":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "ochenstranniedela":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "bennet":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "hinatashoe":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "kissa":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "another_special_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: another_special_coffee, cancellationToken: token);
                break;
            case "hakku":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "xiao":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "rei":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "moodl":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "barbiestyle":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "myataishocolad":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "vedmachiysbor":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
        }

        //if (data != null)
        //    await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri(data.file), caption: data.text, replyMarkup: data.replyMarkup, cancellationToken: token);

        switch (update.Message?.Text?.ToLower())
        {
            case "/start":
                {
                    await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);

                    string checkcustomer = "SELECT id FROM customer WHERE id = @Id";
                    using (MySqlCommand check = new MySqlCommand(checkcustomer, connect))
                    {
                        check.Parameters.Add(new MySqlParameter("Id", message.Chat.Id));
                        using (MySqlDataReader reader = check.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("подключение успешно");
                                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[] { new KeyboardButton[] { "новый заказ" }, new KeyboardButton[] { "меню" }, new KeyboardButton[] { "статус заказа" } })
                                {
                                    ResizeKeyboard = true
                                };

                            }

                            //await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);

                        }
                    }
                }
                break;
            case "новый заказ":
                await client.SendTextMessageAsync(update.Message.Chat.Id, "для начала давай определимся с размером напитка!", replyMarkup: size, cancellationToken: token);
                //await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/menu.jpeg"), caption: "глянь меню и выбери категорию", replyMarkup: newOrder, cancellationToken: token);
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
