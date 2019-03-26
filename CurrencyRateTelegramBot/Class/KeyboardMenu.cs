using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace EuroToReal {

    public static class KeyboardMenu {

        public static ReplyKeyboardMarkup MainMenu() {

            ReplyKeyboardMarkup rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard =
                new KeyboardButton[][] {
                        new KeyboardButton[] {
                            new KeyboardButton("Subscribe")
                        },
                        new KeyboardButton[] {
                            new KeyboardButton("Coins")
                        }
                };
            rkm.OneTimeKeyboard = true;
            return rkm;
        }

        public static ReplyKeyboardMarkup CoinsMenu() {

            ReplyKeyboardMarkup rkm = new ReplyKeyboardMarkup();
            List<KeyboardButton[]> rows = new List<KeyboardButton[]>();
            List<KeyboardButton> cols = new List<KeyboardButton>();

            for (int i = 1; i <= Enum.GetNames(typeof(Configuration.Currency)).Length; i++) {

                cols.Add(new KeyboardButton(Enum.GetName(typeof(Configuration.Currency), i)));
                if (i % Configuration.NumberOfButtons != 0) continue;
                rows.Add(cols.ToArray());
                cols = new List<KeyboardButton>();
            }

            rkm.Keyboard = rows.ToArray();
            rkm.OneTimeKeyboard = true;
            return rkm;
        }
    }
}