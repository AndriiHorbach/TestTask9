using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Infrastructure.Common;

namespace TestTask.Infrastructure.Controls.Elements
{
    public class HtmlControl
    {
        internal By Locator;

        private IWebElement WrappedElement => DriverManager.Driver.FindElement(Locator);

        protected string Text => WrappedElement.Text;

        public bool Displayed => WrappedElement.Displayed;

        public void Clear()
            => WrappedElement.Clear();

        protected void Click()
            => WrappedElement.Click();

        public IWebElement FindElement(By by)
        {
            return WrappedElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return WrappedElement.FindElements(by);
        }

        protected void SendKeys(string text)
            => WrappedElement.SendKeys(text);

        protected void Submit()
            => WrappedElement.Submit();
    }
}
