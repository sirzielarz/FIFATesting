using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace GoogleTest
{
    public class FinalPage
    {
        
        
        private readonly IWebDriver _driver;
        public string _pagetitle { get; set; }
        public FinalPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
            _pagetitle = driver.Title;
        }
    }
}