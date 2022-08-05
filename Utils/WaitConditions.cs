using System;
using OpenQA.Selenium;

namespace FundaSmokeTests
{

    class WaitConditions
    {
        public static Func<IWebDriver, IWebElement> IsClickable(IWebElement element) => driver =>
            (element != null && element.Displayed && element.Enabled) ? element : null;

        public static Func<IWebDriver, IWebElement> IsVisible(IWebElement element) => driver =>
            (element != null && element.Displayed) ? element : null;

        public static Func<IWebDriver, IWebElement> IsEnable(IWebElement element) => driver =>
            (element != null && element.Enabled) ? element : null;
    }
}