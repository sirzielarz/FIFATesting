using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleTest
{
    public class DriverContext : IDisposable
    {
        private const string baseUrl = "https://www.google.com/";

        public DriverContext()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            Driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options, TimeSpan.FromMinutes(3));

            var setUp = Driver.Manage();
            setUp.Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            setUp.Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            setUp.Window.Maximize();

            Driver.Navigate().GoToUrl(baseUrl);
        }

        public IWebDriver Driver { get; }

        public void RefreshPage() =>
            Driver.Navigate().Refresh();

        public void Dispose() => Driver.Quit();
    }
}