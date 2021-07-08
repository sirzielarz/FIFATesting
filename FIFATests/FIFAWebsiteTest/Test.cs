using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace FIFAWebsiteTest
{
    public class Test : DriverContext
    {

        private const string CorrectTitle = "FIFA Women's World Cup™";
        [Fact]
        public void Test1()
        {
            //Arrange
            var startPage = new StartPage(Driver);
            Driver.Manage().Window.Maximize();
            var assertionScope = new AssertionScope();
            //Act
            startPage.ClickAcceptCookies();
            var worldCupPage = startPage.GoToWomensWorldCupSite();

            //Assert
            using (assertionScope)
            {
                worldCupPage.PageTitle.Should().Be(CorrectTitle);
            }
        }
    }
}