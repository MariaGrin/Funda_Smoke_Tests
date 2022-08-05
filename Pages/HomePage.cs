using System.Collections.ObjectModel;
using System.Linq;
using Baseline.ImTools;
using FundaSmokeTests.Pages;
using FundaSmokeTests.Controls;
using OpenQA.Selenium;

namespace FundaSmokeTests
{
    class HomePage : BasePage
    {
        public TextBox SearchBox => new TextBox(Driver.FindElement(By.CssSelector("input[type='search']")));
        public Button SearchButton => new Button(Driver.FindElement(By.CssSelector("button[type='submit']")));

        public static HomePage Open(IWebDriver driver)
        {
            driver.Url = $"{Configuration.Settings["BaseUrl"]}/";
            var Page = new HomePage(driver);
            return Page.VerifyOnPage<HomePage>();
        }
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        protected override T VerifyOnPage<T>()
        {
            WaitForElement(Driver.FindElement(By.CssSelector("div[class*='home-search']")));
            return GetPageObject<T>();
        }

        public void Search(string data)
        {
            SearchBox.Text = data;
            SearchButton.Click();
        }

        public IEnumerable<string> GetSearchResults()
        {
            var elementTexts = Driver
                .FindElements(By.CssSelector(".search-result__header-subtitle"))
                .Select(x => x.Text.ToLower());
            return elementTexts;
        }
    }
}