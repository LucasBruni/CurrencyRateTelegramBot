using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace EuroToReal {

    public class Events {

        static ITelegramBotClient BotClient;

        public bool IsSubscribe { get; set; }

        public Events(ITelegramBotClient botClient) {
            BotClient = botClient;
        }

        public void MessageReceived(MessageEventArgs messageEvent) {

            string message = messageEvent.Message.Text.ToUpper();

            if (IsSubscribe) {

                if (message.Equals("EXIT")) {

                    IsSubscribe = false;
                } else {

                    string text = VerifySubscribe(message);

                    BotClient.SendTextMessageAsync(messageEvent.Message.Chat, text.ToString());
                }
            } else if (Enum.IsDefined(typeof(Configuration.Currency), message)) {

                ShowCurrencyRate(messageEvent.Message.Chat, message);
            }

            if (message.Equals("SUBSCRIBE")) {

                IsSubscribe = true;

                System.Text.StringBuilder text = new System.Text.StringBuilder();
                text.AppendLine("Send the currencies you want to subscribe separated by \",\".");
                text.AppendLine("Example: BRL, USD");
                text.AppendLine("Or \"exit\" to leave the subscribe.");

                BotClient.SendTextMessageAsync(messageEvent.Message.Chat, text.ToString());
            } else if (message.Equals("COINS")) {

                BotClient.SendTextMessageAsync(messageEvent.Message.Chat, "Choose an option", replyMarkup: KeyboardMenu.CoinsMenu());
            } else {

                BotClient.SendTextMessageAsync(messageEvent.Message.Chat, "Choose an option", replyMarkup: KeyboardMenu.MainMenu());
            }
        }

        public string VerifySubscribe(string message) {

            List<string> list = new List<string>();
            list.AddRange(message.Split(","));

            System.Text.StringBuilder text = new System.Text.StringBuilder();

            foreach (string currency in list) {

                if (!Enum.IsDefined(typeof(Configuration.Currency), currency.Trim())) {

                    text.AppendLine("Text invalid, try again.");
                    text.AppendLine("Send the currencies you want to subscribe separated by \",\".");
                    text.AppendLine("Example: BRL, USD");

                    return text.ToString();

                } else {
                    //TODO SAVE IN DATABASE
                    IsSubscribe = false;

                    text.AppendLine("Subscribed succeded!");

                    return text.ToString();
                }
            }

            return "ERROR";
        }

        public void ShowCurrencyRate(Telegram.Bot.Types.Chat chat, string text) {

            Exchange exchange = new Exchange();

            BotClient.SendTextMessageAsync(
                chatId: chat,
                text: exchange.GetRate(text)
            );
        }

    }
}