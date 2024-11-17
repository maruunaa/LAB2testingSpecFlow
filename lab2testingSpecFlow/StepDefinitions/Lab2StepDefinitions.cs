using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject;
using System;
using TechTalk.SpecFlow;

namespace lab2testingSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class Lab2StepDefinitions:BaseSteps
    {
        private LoginPage loginPage;

        [Given(@"I am on the SauceDemo login page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            driver = new ChromeDriver("D:\\chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginPage = new LoginPage(driver);
        }

        [When(@"I enter valid username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterValidUsernameAndPassword(string name, string pwd)
        {
            loginPage.LoginWithNameAndPassword(name, pwd);
        }


        [Then(@"I should see an error message ""([^""]*)""")]
        public void ThenIShouldSeeAnErrorMessage(string error)
        {
            loginPage.CheckThatError(error);
        }
    }
}
