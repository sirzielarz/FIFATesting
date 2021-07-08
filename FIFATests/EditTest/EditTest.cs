using System;
using EditTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace EditTest
{
    public class Tests
    {
        public const int MAX_WAIT_FOR_APPEARANCE = 100;
        public IWebDriver driver;

        public string url = "https://recruitment.fifatms.com/?desc=test";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test1()
        {
            var editPage = new EditPage(driver);
            editPage.Driver.Navigate().GoToUrl(url);
            var firstname = "sample";
            var lastname = "sample";
            editPage.insertData(firstname, lastname);
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(MAX_WAIT_FOR_APPEARANCE))
                .Until(ExpectedConditions.TextToBePresentInElement(editPage.FirstName, firstname));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(MAX_WAIT_FOR_APPEARANCE))
                .Until(ExpectedConditions.TextToBePresentInElement(editPage.LastName, lastname));
            Assert.That(editPage.FirstName.Text.Equals(firstname));
            Assert.That(editPage.LastName.Text.Equals(lastname));
        }

        [Test]
        public void Test2()
        {
            var editPage = new EditPage(driver);
            editPage.Driver.Navigate().GoToUrl(url);
            var firstname = Utils.Utils.RandomString(10);
            var lastname = "ronaldo";
            editPage.insertData(firstname, lastname);
            editPage.Driver.Navigate().Refresh();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(100))
                .Until(ExpectedConditions.TextToBePresentInElement(editPage.FirstName, firstname));
            Assert.That(editPage.FirstName.Text.Equals(firstname));
            Assert.That(editPage.LastName.Text.Equals(lastname));
        }

        [TearDown]
        public void Close()
        {
            driver.Dispose();
        }
    }
}