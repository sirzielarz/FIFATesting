using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace FIFAWebsiteTest
{
    public class StartPage
    {
        private readonly IWebDriver _driver;
        private readonly Actions actions;

        public StartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            actions = new Actions(_driver);
        }
        
        [FindsBy(How = How.Id, 
            Using = "onetrust-accept-btn-handler")]
        public IWebElement AcceptCookies { get; set; }
        
        [FindsBy(How = How.CssSelector, 
            Using = ".ff-mb-0[href='/tournaments']")]
        public IWebElement CompetitionsButton { get; set; }
        
        [FindsBy(How = How.CssSelector, 
            Using = ".ff-px-32 .row > li:nth-of-type(1) [href='/tournaments/womens/womensworldcup']")]
        public IWebElement WorldCupButton { get; set; }

        public void ClickAcceptCookies()
        {
            AcceptCookies.Click();
        }

        public WorldCupPage GoToWomensWorldCupSite()
        {
           actions.MoveToElement(CompetitionsButton).Perform();
           WorldCupButton.Click();
           return new WorldCupPage(_driver); 
        }
        
        
    }
}