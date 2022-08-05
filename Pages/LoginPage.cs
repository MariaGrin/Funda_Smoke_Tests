using System.Linq;
using FundaSmokeTests.Pages;
using FundaSmokeTests.Controls;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FundaSmokeTests
{
    class LoginPage : BasePage
    {
        public static LoginPage Open(IWebDriver driver)
        {
            driver.Url = $"{Configuration.Settings["BaseUrl"]}/mijn/login/";
            var Page = new LoginPage(driver);
            return Page.VerifyOnPage<LoginPage>();
        }

        private LoginPage(IWebDriver driver) : base(driver) { }

        protected override T VerifyOnPage<T>()
        {
            Assert.That(Driver.Title, Is.EqualTo("Inloggen met uw account [funda]"), "BasePage title");
            return GetPageObject<T>();
        }

        public TextBox UserName => new TextBox(Driver.FindElement(By.CssSelector("input#UserName")));
        public TextBox PassWord => new TextBox(Driver.FindElement(By.CssSelector("input#Password")));
        public Button LoginButton => new Button(Driver.FindElement(By.CssSelector("button[type='submit']")));
        public Link HeaderAccountLink => new Link(Driver.FindElement(By.CssSelector("a[aria-controls*='app-header__account']")));
        public Link LogOutLink => new Link(Driver.FindElement(By.CssSelector("a#appheader-logout-link"))); 
        public string Message => Driver.FindElement(By.CssSelector("span[class*='field-validation-error']")).Text;
        public string Notification => Driver.FindElement(By.CssSelector("div[class*='notification']")).Text;
        public string ActualEmailMessageError => Driver.FindElement(By.CssSelector("span#UserName-error")).Text;
        public string ActualPasswMessageError => Driver.FindElement(By.CssSelector("span#Password-error")).Text;

        public string ExpectedMessageErrorEmptyEmail = "Voer jouw e-mailadres in";
        public string ExpectedMessageErrorEmptyPassw = "Voer jouw wachtwoord in";
        public string ExpectedNotificationError = "De combinatie van e-mailadres en wachtwoord is ongeldig.";


        public void Login(string userName, string passWord)
        {
            UserName.Text = userName;
            PassWord.Text = passWord;
            LoginButton.Click();
        }

        public void LogOut()
        {
            HeaderAccountLink.Click();
            LogOutLink.Click();
            Wait.Until(c => c.FindElement(By.CssSelector("li[class*='app-header__menu--inloggen']")));
        }

        public bool IsLoggedIn => Driver.FindElements(By.CssSelector("a[aria-controls*='app-header__account']")).Any();

    }
}