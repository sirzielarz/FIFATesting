using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GoogleTest
{
    public class GoogleStartPage
    {
        private readonly IWebDriver _driver;


        public GoogleStartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")] 
        public IWebElement QueryField { get; set; }

        [FindsBy(How = How.Id, Using = "L2AGLb")]
        public IWebElement AcceptCookies { get; set; }

        public void SearchFor(string query)
        {
            AcceptCookies.Click();
            QueryField.Click();
            QueryField.SendKeys(query);
        }

        public GoogleResultPage SubmitQuery()
        {
            QueryField.SendKeys(Keys.Enter);
            return new GoogleResultPage(_driver);
        }
    }
}