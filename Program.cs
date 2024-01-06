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

            var riotClient = ActivatorUtilities.CreateInstance<RiotClient>(host.Services);
            var summoner = await riotClient.GetSummonerByNameAsync("Hachy");
            var matches = await riotClient.GetMatchesByUserIdAsync(summoner.Puuid);
            var lastMatch = await riotClient.GetMatchByMatchIdAsync(matches[1]);
            var result = lastMatch.Info.Participants.FirstOrDefault(p => p.Puuid == summoner.Puuid).Win ? "won" : "lost";
            await Console.Out.WriteLineAsync($"Hachy {result} before last game");
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