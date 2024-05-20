using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tgbot;
using Update = Telegram.Bot.Types.Update;

internal class Program
{

    static CancellationToken token = new CancellationToken();
    static Host kissabot;
    private static bool flagAskPhone = false;


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

    private static async void OnMessage(ITelegramBotClient client, Update update)

    {

        int order = 0;
        string connection = "server=localhost;port=3306;user=root;password=Masha0325;database=coffeeshop;Character Set=utf8mb4;";
        MySqlConnection connect = new MySqlConnection(connection);
        OpenConnection();

        bool OpenConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



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

            },
        });


        InlineKeyboardMarkup base_menu = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "кофя", callbackData: "coffee"),
                InlineKeyboardButton.WithCallbackData(text: "иное", callbackData: "another_coffee"),
            },
        });

        InlineKeyboardMarkup adds = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "альтернативное молоко", callbackData: "alternative_milk"),
                InlineKeyboardButton.WithCallbackData(text: "сироп", callbackData: "syrup"),
                InlineKeyboardButton.WithCallbackData(text: "корица", callbackData: "cinnamon"),
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "сахар", callbackData: "sugar"),
                InlineKeyboardButton.WithCallbackData(text: "маршмеллоу", callbackData: "marshmallow"),

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
                InlineKeyboardButton.WithCallbackData(text: "Флэт Уайт", callbackData: "flatwhite"),
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
        InlineKeyboardMarkup sizem = new(new[]
{
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "M", callbackData: "max"),
            },
        });

        //кнопочки меню
        switch (update.CallbackQuery?.Data)
        {
            case "base_menu":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/base_menu.jpg"), caption: "супер! что дальше?", replyMarkup: base_menu, cancellationToken: token);
                break;
            case "special_menu":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/special.png"), caption: "супер! что дальше?", replyMarkup: special_menu, cancellationToken: token);
                break;
        }

        int sumdrinkorder = 0;
        //кнопочки заказиков напитков
        switch (update.CallbackQuery?.Data)
        {
            case "coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: coffee, cancellationToken: token);
                break;
            case "another_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: another_coffee, cancellationToken: token);
                break;
            case "special_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: special_coffee, cancellationToken: token);
                break;
            case "another_special_coffee":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "скорее выбирай желаемое!", replyMarkup: another_special_coffee, cancellationToken: token);
                break;
        }

        int sumaddsorder = 0;
        //добавки
        switch (update.CallbackQuery?.Data)
        {
            case "adds":
                await client.SendPhotoAsync(update.CallbackQuery.From.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/adds.png"), caption: "супер! что дальше?", replyMarkup: adds, cancellationToken: token);
                break;
            case "alternative_milk":
                sumaddsorder++;
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "syrup":
                sumaddsorder++;
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "cinnamon":
                sumaddsorder++;
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "sugar":
                sumaddsorder++;
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
            case "marshmallow":
                sumaddsorder++;
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", cancellationToken: token);
                break;
        }

        //напитки
        switch (update.CallbackQuery?.Data)
        {
            case "americano":

                string getDrinkOrder = "SELECT id FROM drinkorder WHERE id_customer = @id_customer";
                MySqlCommand commandDrinkOrder = new MySqlCommand(getDrinkOrder, connect);
                commandDrinkOrder.Parameters.AddWithValue("@id_customer", update.CallbackQuery.Id);
                int idDrinkOrder = Convert.ToInt32(commandDrinkOrder.ExecuteScalar());
                string insertintodrinkorder = "INSERT INTO crossdrinksorderdrinks (id_drinks, id_drinksOrder, amount) " + "VALUES (@id_drinks, @id_drinksOrder, @amount);";
                using (MySqlCommand adddrinkorderdrink = new MySqlCommand(insertintodrinkorder, connect))
                {
                    adddrinkorderdrink.Parameters.AddWithValue("@id_drinks", 1);
                    adddrinkorderdrink.Parameters.AddWithValue("@id_drinksOrder", idDrinkOrder);
                    adddrinkorderdrink.Parameters.AddWithValue("@amount", 1);
                    Console.WriteLine($"успешно добавлен заказ пользователя с айди: {update.CallbackQuery.Id}");
                    using (MySqlDataReader readdrinkorderdrink = adddrinkorderdrink.ExecuteReader())
                    {
                        readdrinkorderdrink.Read();
                        readdrinkorderdrink.Close();
                    }
                    await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                }

                break;
            case "cappuchino":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "latte":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: sizem, cancellationToken: token);
                break;
            case "flatwhite":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: sizem, cancellationToken: token);
                break;

            case "matchalatte":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "tea":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "cacao":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "kissel":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;

            case "dlyagyliya":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "ochenstranniedela":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "bennet":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "hinatashoe":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: sizem, cancellationToken: token);
                break;
            case "kissa":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: sizem, cancellationToken: token);
                break;

            case "hakku":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: sizem, cancellationToken: token);
                break;
            case "xiao":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: sizem, cancellationToken: token);
                break;
            case "rei":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "moodl":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "barbiestyle":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "myataishocolad":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
            case "vedmachiysbor":
                await client.SendTextMessageAsync(update.CallbackQuery.From.Id, "выбери размер!", replyMarkup: size, cancellationToken: token);
                break;
        }

        //if(update.CallbackQuery.Data == "max")
        //{
        //    //тут короче будет свойство выбранный напиток ай гесс?? надо сначала разобраться с добавлением....
        //}

        switch (update.Message?.Text?.ToLower())
        {
            case "/start":
                await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/greeting_photo.jpeg"), caption: "На связи Кисса-бот!\nВыбери нужную команду;)", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                string sql = "SELECT id, phone_number FROM customer WHERE id = @id";
                using (MySqlCommand checkcustomers = new MySqlCommand(sql, connect))
                {
                    checkcustomers.Parameters.AddWithValue("@id", update.Message.Chat.Id);
                    using (MySqlDataReader customers = checkcustomers.ExecuteReader())
                    {
                        if (customers.Read())
                        {
                            long Id = customers.GetInt64("id");
                            string phonenumber = customers.GetString("phone_number");
                            Console.WriteLine($"пользователь: {Id} - номер {phonenumber}");
                        }
                        else
                        {
                            customers.Close();
                            string insertcustomer = "INSERT INTO customer (id, phone_number)" + "VALUES (@id, '/start')";
                            using (MySqlCommand addcustomers = new MySqlCommand(insertcustomer, connect))
                            {
                                addcustomers.Parameters.AddWithValue("@id", update.Message.Chat.Id);
                                Console.WriteLine($"успешно добавлен пользователь с айди: {update.Message.Chat.Id}, НОМЕР МОЖНО ИЗМЕНИТЬ");
                                using (MySqlDataReader readcustomers = addcustomers.ExecuteReader())
                                    readcustomers.Read();
                            }
                        }
                    }
                }
                break;
            case "новый заказ":
                {
                    await client.SendTextMessageAsync(update.Message.Chat.Id, "чтобы продолжить оформлять заказ, пожалуйста, укажите ваш номер телефона для связи", cancellationToken: token);
                    flagAskPhone = true;
                    MakeNewOrder(connect, update);
                }
                break;
            case "меню":
                await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/menu.jpeg"), replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;
            case "статус заказа":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 833690650, "данная функция недоступна", replyMarkup: replyKeyboardMarkup, cancellationToken: token);
                break;

            default:
                {
                    if (flagAskPhone == true)
                    {

                        string changecustomer = "UPDATE customer SET `id` = @id, `phone_number` =  @phone_number WHERE id = @id;";
                        using (MySqlCommand ChangeCustomer = new MySqlCommand(changecustomer, connect))
                        {
                            ChangeCustomer.Parameters.AddWithValue("@phone_number", update.Message.Text);
                            ChangeCustomer.Parameters.AddWithValue("@id", update.Message.Chat.Id);
                            using (MySqlDataReader ReadNowCustomer = ChangeCustomer.ExecuteReader())
                            {
                                ReadNowCustomer.Read();
                                ReadNowCustomer.Close();

                            }
                            Console.WriteLine("номер телефона успешно изменен!");
                            flagAskPhone = false;

                            await client.SendPhotoAsync(update.Message.Chat.Id, InputFile.FromUri("https://raw.githubusercontent.com/r0zmarin1/tgbot-console-/master/tgbot/docs/menu.jpeg"), caption: "глянь меню и выбери категорию", replyMarkup: newOrder, cancellationToken: token);
                        }
                    }
                }
                break;
        }
    }

    private static void MakeNewOrder(MySqlConnection connect, Update update)
    {
        string insertintodrinkorder = "INSERT INTO DrinkOrder (status, id_customer, date, time, description) " + "VALUES (@status, @id_customer, @date, @time, @description);";
        using (MySqlCommand addorderdrink = new MySqlCommand(insertintodrinkorder, connect))
        {
            addorderdrink.Parameters.AddWithValue("@status", "Не готов");
            addorderdrink.Parameters.AddWithValue("@id_customer", update.Message.Chat.Id);
            addorderdrink.Parameters.AddWithValue("@date", DateTime.Now.Date);
            addorderdrink.Parameters.AddWithValue("@time", "к 10");
            addorderdrink.Parameters.AddWithValue("@description", $"Заказ ");
            Console.WriteLine($"успешно добавлен заказ пользователя с айди: {update.Message.Chat.Id}");
            using (MySqlDataReader readorderdrink = addorderdrink.ExecuteReader())
            {
                readorderdrink.Read();
                readorderdrink.Close();
            }

        }
    }
}


