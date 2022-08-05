using FundaSmokeTests.Utils;
using OpenQA.Selenium;

namespace FundaSmokeTests.Tests
{
    public class LoginPageTests : TestBase
    {
        [SetUp]
        public void SepUp()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            LoginPage = LoginPage.Open(Driver);
            LoginPage.AcceptAllCookies();
        }

        private LoginPage LoginPage { get; set; }

        public LoginPageTests(BrowserType browserType) : base(browserType)
        {
        }

        [Test]
        public void ErrorMessageIsShownEmptyLoginFields()
        {
            LoginPage.Login(string.Empty, string.Empty);
            Assert.That(LoginPage.UserName.IsNotValid, Is.True);
            Assert.That(LoginPage.PassWord.IsNotValid, Is.True);
            Assert.That(LoginPage.IsLoggedIn, Is.False);
            Assert.That(LoginPage.ActualEmailMessageError, Is.EqualTo(LoginPage.ExpectedMessageErrorEmptyEmail));
            Assert.That(LoginPage.ActualPasswMessageError, Is.EqualTo(LoginPage.ExpectedMessageErrorEmptyPassw));
        }

        [Test]
        public void ErrorMessageIsShownForInvalidLoginData()
        {
            LoginPage.Login(Configuration.Settings["UserName"], "wrong_password");
            Assert.That(LoginPage.UserName.IsNotValid, Is.False);
            Assert.That(LoginPage.PassWord.IsNotValid, Is.False);
            Assert.That(LoginPage.IsLoggedIn, Is.False);
            Assert.That(LoginPage.Notification, Is.EqualTo(LoginPage.ExpectedNotificationError));
        }

        [Test]
        public void LoginSuccessfulDefaultUser()
        {
            LoginPage.Login(Configuration.Settings["UserName"], Configuration.Settings["PassWord"]);
            Assert.That(LoginPage.IsLoggedIn, Is.True);
        }

        [Test]
        public void DefaultUserLogOutSuccessfully()
        {
            LoginPage.Login(Configuration.Settings["UserName"], Configuration.Settings["PassWord"]);
            LoginPage.LogOut();
           Assert.That(LoginPage.IsLoggedIn, Is.False);
        }
    }
}