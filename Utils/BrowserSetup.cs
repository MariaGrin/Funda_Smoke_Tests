using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FundaSmokeTests
{
    class BrowserSetup
    {
        private static string userAgentSecret = $"{Configuration.Settings["UserAgentSecret"]}";

        private static Dictionary<string, Func<IWebDriver>> Browsers = new Dictionary<string, Func<IWebDriver>>(){
            {"Chrome", () => {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument($"--user-agent=Funda Interviewee/1.0.0 {userAgentSecret}");
                var driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
                return driver;
            } }
        };

        public static IWebDriver GetDriver(string browserType) =>
            (Browsers.ContainsKey(browserType)) ? Browsers[browserType].Invoke() :
            throw new NullReferenceException($"IWebDriver instance was not initialized: [{browserType}] is not a valid Browser type");
    }
}