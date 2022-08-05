using OpenQA.Selenium;

namespace FundaSmokeTests.Controls
{
    public class Link : BaseControl
    {
        public Link(IWebElement container) : base(container)
        {
        }

        public void Click() => Container.Click();
    }
}
