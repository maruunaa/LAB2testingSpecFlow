using OpenQA.Selenium;

namespace PageObject
{
    public class PageBase
    {
        protected static IWebDriver driver;
        public PageBase(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public IWebElement Element(By by) => driver.FindElement(by);

        public void Click(By by) => Element(by).Click();

        public void SendKeys(By by, string text)
        {
            var element = Element(by);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(By by) => Element(by).Text;
    }
}