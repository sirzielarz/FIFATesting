using OpenQA.Selenium;

namespace FIFAWebsiteTest
{
    public class WorldCupPage
    {
        private readonly IWebDriver _driver;
        public string PageTitle { get; set; }

        public WorldCupPage(IWebDriver driver)
        {
            _driver = driver;
            PageTitle = _driver.Title;
        }
    }
}