using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace tgbot
{

    public class Host
    {
        public Action<ITelegramBotClient, Update>? OnMessage;
       
        private TelegramBotClient kissabot;
        internal int lastMessageId;

        public Host(string token)
        {
            kissabot = new TelegramBotClient(token);

        }

        public void Start()
        {
            kissabot.StartReceiving(Update, Error);
            Console.WriteLine("Start!");
        }

        
        public async Task Delete(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update?.Message?.Text != null && lastMessageId !=0)
            {
            await client.DeleteMessageAsync(update.Message.Chat.Id, lastMessageId, cancellationToken);
            }
        }

        private async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {

            Console.WriteLine($"New message from {update.Message?.Chat.FirstName}: {update.Message?.Text ?? "[не текст]"}");
            OnMessage?.Invoke(client, update);
            await Task.CompletedTask;
        }

        private async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine("Error:" + exception.Message);
            await Task.CompletedTask;
        }


    }
}
