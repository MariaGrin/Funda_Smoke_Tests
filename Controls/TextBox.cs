using OpenQA.Selenium;

namespace FundaSmokeTests.Controls
{
    public class TextBox : BaseControl
    {

        public TextBox(IWebElement container) : base(container)
        {
        }

        public string Text { get => Container.Text; set => Container.SendKeys(value); }

        public bool IsNotValid => Container.GetAttribute("class").Contains("input-validation-error");
    }
}
