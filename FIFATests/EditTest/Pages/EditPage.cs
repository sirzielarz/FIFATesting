using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EditTest.Pages
{
    public class EditPage
    {
        public EditPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "edit-button")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "first-name-edit")]
        public IWebElement FirstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "last-name-edit")]
        public IWebElement LastNameField { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement SaveButton { get; set; }

        public void insertData(string firstname, string lastname)
        {
            EditButton.Click();
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);
            SaveButton.Click();
        }
    }
}