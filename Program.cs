using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LolStats742
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();        
            //await host.RunAsync();

            var instance = ActivatorUtilities.CreateInstance<RiotClient>(host.Services);
            var lol = await instance.GetMatchesByUserIdAsync("0BD1Q79rW1WrD5iyyHpj8IeyVL6IYjfHZiXE5R68eNYlTYSeIOX5n1nHPZ9zESNrmOpjhb66eTc49w", queue: 1700);
            //var telegramBot = new TelegramBotService();
            //telegramBot.HandleBot();





            Console.ReadLine();
            //var screanShotTaker = new ScreenShotTaker();
            //screanShotTaker.TakeScreenShot();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IRiotClient, RiotClient>();
                    services.AddHttpClient<RiotClient>();
                });
        }
    }
}