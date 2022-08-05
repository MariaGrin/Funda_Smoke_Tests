using FundaSmokeTests.Utils;

namespace FundaSmokeTests.Tests
{
    public class HomePageTests : TestBase
    {
        private string SearchData = "haarlem";

        [SetUp]
        public void SepUp()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            HomePage = HomePage.Open(Driver);
            HomePage.AcceptAllCookies();
        }

        private HomePage HomePage { get; set; }

        public HomePageTests(BrowserType browserType) : base(browserType)
        {
        }

        [Test]
        public void CheckSearchResult()
        {
            HomePage.Search(SearchData);
            var actualResults = HomePage.GetSearchResults();
            var expectedList = actualResults.Where(x => x.Contains(SearchData)).ToList();

            Assert.That(actualResults.Count, Is.EqualTo(expectedList.Count), "Searching items are displayed");
        }
    }
}