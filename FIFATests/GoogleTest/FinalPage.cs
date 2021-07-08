using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GoogleTest
{
    public class FinalPage
    {
        private readonly IWebDriver _driver;

        public FinalPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            Pagetitle = driver.Title;
        }

        public string Pagetitle { get; set; }
    }
}