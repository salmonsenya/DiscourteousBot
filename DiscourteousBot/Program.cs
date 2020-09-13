using System;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace DiscourteousBot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello! DiscourteousBot is started.");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var input = e.Message.Text;
            if (input != null)
            {
                var regexYes = new Regex(@"(^((да)|(Да)|(ДА))(\?*|\.*|!*)$)|(((\s|,)да\?+)$)");
                if (regexYes.IsMatch(input))
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        replyToMessageId: e.Message.MessageId,
                        text: $"пизда");
                }

                var regexNo = new Regex(@"(^((нет)|(Нет)|(НЕТ))(\.*|!*)$)");
                if (regexNo.IsMatch(input))
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        replyToMessageId: e.Message.MessageId,
                        text: $"пидора ответ");
                }
            }
        }
    }
}
