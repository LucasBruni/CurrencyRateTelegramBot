using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace EuroToReal {

    public class Program {

        static ITelegramBotClient botClient;

        static void Main() {
            botClient = new TelegramBotClient(Configuration.BotToken);
            
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs messageEvent) {

            if (messageEvent.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text) {

                Events events = new Events(botClient);
                events.MessageReceived(messageEvent);
            }
        }
    }
}