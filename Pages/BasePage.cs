using System;
using FundaSmokeTests;
using FundaSmokeTests.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FundaSmokeTests.Pages
{
    abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected IWebElement OnetrustAcceptBtn => Driver.FindElement(By.CssSelector("button#onetrust-accept-btn-handler"));

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected abstract T VerifyOnPage<T>() where T : BasePage;

        protected T GetPageObject<T>() => (T)Convert.ChangeType(this, typeof(T));

        protected IWebElement WaitForElement(IWebElement element)
        {
            return Wait.Until(WaitConditions.IsVisible(element));
        }

        protected IWebElement WaitClickable(IWebElement element)
        {
            return Wait.Until(WaitConditions.IsClickable(element));
        }

        protected IWebElement WaitUntilElementEnable(IWebElement element)
        {
            return Wait.Until(WaitConditions.IsEnable(element));
        }

        public void AcceptAllCookies()
        {
            Wait.Until(c => c.FindElement(By.CssSelector("button#onetrust-accept-btn-handler"))).Click();
        }
    }
}