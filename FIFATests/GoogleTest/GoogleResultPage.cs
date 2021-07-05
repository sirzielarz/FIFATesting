using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace GoogleTest
{
    public class GoogleResultPage
    {
        private readonly IWebDriver _driver;
        private Actions actions;

        [FindsBy(How=How.XPath, Using = "//*[@id=\"lb\"]/div/g-menu/g-menu-item[2]/div/a")] 
        public IWebElement VerbatimButton { get; set; }
        
        [FindsBy(How=How.Id, Using = "hdtb-tls")] 
        public IWebElement ToolsButton { get; set; }
        
        [FindsBy(How=How.XPath, Using = "//div[@class='KTBKoe' and text()='Kiedykolwiek']")] 
        public IWebElement TimeFilter { get; set; }
        
        [FindsBy(How=How.XPath, Using = "//div[@class='KTBKoe' and text()='Wszystkie wyniki']")] 
        public IWebElement AllResultsFilter { get; set; }
        
        [FindsBy(How=How.XPath, Using = "//div[@class='KTBKoe' and text()='Dokładnie']")] 
        public IWebElement VerbatimResultsFilter { get; set; }

        [FindsBy(How = How.TagName, Using = "h3")]
        public IList<IWebElement> AllResultsFromGoogle { get; set; }
        
        public GoogleResultPage(IWebDriver driver)
        {
            _driver = driver;
            actions  = new Actions(_driver);
            PageFactory.InitElements(driver,this);
        }

        public void ClickOnTools()
        {
            ToolsButton.Click();
           
        }

        public void ChangeFilters()
        {
            actions.MoveToElement(AllResultsFilter).Perform();
            AllResultsFilter.Click();
            VerbatimButton.Click();
        }

        public FinalPage ClickOnFirstResult()
        {
            var result = AllResultsFromGoogle[0];
            result.Click();
            return new FinalPage(_driver);
        }
    }
}