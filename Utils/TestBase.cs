using System;
using FundaSmokeTests.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V103.DevToolsSessionDomains;
using Network = OpenQA.Selenium.DevTools.V103.Network;

namespace FundaSmokeTests
{
    [Explicit]
    [TestFixture(BrowserType.Chrome)]
    public class TestBase
    {
        private readonly BrowserType _browserType;

        public TestBase(BrowserType browserType)
        {
            _browserType = browserType;
        }

        protected IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Driver = BrowserSetup.GetDriver(_browserType.ToString());        
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Driver != null) Driver.Quit();
        }
    }
}