using OpenQA.Selenium;

namespace FundaSmokeTests.Controls
{

    public class BaseControl
    {
        public readonly IWebElement Container;

        public BaseControl(IWebElement container)
        {
            Container = container;
        }

        public bool IsVisible => Container.Displayed;
    }
}
