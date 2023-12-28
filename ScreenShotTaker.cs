using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace LolStats742
{
    class ScreenShotTaker
    {
        private IWebDriver driver;
        public ScreenShotTaker()
        {
            driver = new ChromeDriver();
        }

        public byte[] TakeScreenShot(string name, string tag) //css-1kw4425 ecc8cxr0
        {
            driver.Navigate().GoToUrl($"https://www.op.gg/summoners/euw/{name}-{tag}");
            driver.Manage().Window.Maximize();

            //driver.FindElement(By.CssSelector(".css-1ki6o6m")).Click();
            //Thread.Sleep(5000);
            //driver.Navigate().Refresh();

            Thread.Sleep(5000);
            if (IsElementPresent(By.ClassName("vm-footer-close")))
            {
                driver.FindElement(By.ClassName("vm-footer-close")).Click();
            }

         //   driver.FindElement(By.ClassName("btn-detail")).Click();

            IWebElement rank = driver.FindElement(By.CssSelector(".css-1kw4425.ecc8cxr0"));

         //   new Actions(driver).MoveToElement(lastGame, 0, 0).Perform();
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
         //   screenshot.SaveAsFile("ScreanShotTest.png");

            driver.Quit();

            return screenshot.AsByteArray;
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
