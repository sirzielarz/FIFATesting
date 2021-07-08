using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace GoogleTest
{
    public class Test : DriverContext
    {
        private const string DefaultTimeFilter = "Kiedykolwiek";
        private const string DefaultResultFilter = "Wszystkie wyniki";
        private const string CorrectResultFilter = "Dokładnie";
        private const string CorrectPageTitle = "The Leader in Website Creation | Create Your Free Website | Wix.com";

        private const string Query = "how to create a website";


        [Theory]
        [InlineData(Query)]
        public void Test1(string query)
        {
            //Arrange
            var startPage = new GoogleStartPage(Driver);
            Driver.Manage().Window.Maximize();
            var assertionScope = new AssertionScope();
            //Act
            startPage.SearchFor(query);
            var resultPage = startPage.SubmitQuery();
            resultPage.ClickOnTools();

            //Assert
            using (assertionScope)
            {
                resultPage.TimeFilter.Text
                    .Should()
                    .Be(DefaultTimeFilter);
                resultPage.AllResultsFilter.Text
                    .Should()
                    .Be(DefaultResultFilter);
            }

            //Act
            resultPage.ChangeFilters();

            //Assert
            using (assertionScope)
            {
                resultPage.VerbatimResultsFilter.Text
                    .Should()
                    .Be(CorrectResultFilter);
            }


            //Act
            var finalPage = resultPage.ClickOnFirstResult();

            //Assert
            using (assertionScope)
            {
                finalPage.Pagetitle.Should().Be(CorrectPageTitle);
            }
        }
    }
}