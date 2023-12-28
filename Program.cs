using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Runtime.InteropServices;

namespace LolStats742
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "Hello World");

            var telegramBot = new TelegramBotService();
            telegramBot.HandleBot();



            Console.ReadLine();
            //var screanShotTaker = new ScreenShotTaker();
            //screanShotTaker.TakeScreenShot();
        }
    }
}