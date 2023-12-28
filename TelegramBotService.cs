using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LolStats742
{
    internal class TelegramBotService
    {
       
        public TelegramBotService()
        {
            
        }

        public async Task HandleBot()
        {
            var botClient = new TelegramBotClient("6736759361:AAHRU8GFqWbUA2j3_eG6ix33z9UeyHRwxqo");

            

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions);
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            var words = messageText.Split(" ");

            var selenium = new ScreenShotTaker();

            var screen = selenium.TakeScreenShot(words[1], words[2]);

            Message sentPicture = await botClient.SendPhotoAsync(chatId, InputFile.FromStream(new MemoryStream(screen)));


            // Echo received message text
            // Message sentMessage = await botClient.SendTextMessageAsync(
            //chatId: chatId,
            //text: "Сам ти: " + messageText,
            //cancellationToken: cancellationToken);
        }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }

}
