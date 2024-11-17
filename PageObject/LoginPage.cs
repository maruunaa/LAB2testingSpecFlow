using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class LoginPage : PageBase
    {
        private WebDriverWait wait;
        private IWebElement userNameElement => driver.FindElement(By.Id("user-name"));
        private IWebElement userPasswordElement => driver.FindElement(By.Id("password"));
        private IWebElement loginBtn => driver.FindElement(By.Id("login-button"));
        private IWebElement errorField  => driver.FindElement(By.ClassName("error-message-container"));
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
        }

        public void LoginWithNameAndPassword(string name, string pwd)
        {
            wait.Until(d => d.FindElement(By.Id("user-name")).Displayed);
            userNameElement.Click();
            userNameElement.SendKeys(name);

            wait.Until(d => d.FindElement(By.Id("password")).Displayed);
            userPasswordElement.Click();
            userPasswordElement.SendKeys(pwd);

            wait.Until(d => d.FindElement(By.Id("login-button")).Displayed);

            loginBtn.Click();
        }
        public void CheckThatError(string message)
        {
            var TextError = errorField.Text;
            Assert.IsTrue(TextError.ToLower().Contains(message.ToLower()));
        }
    }
}
