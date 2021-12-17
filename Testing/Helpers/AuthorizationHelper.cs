using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Testing.Entities;

namespace Testing.Helpers
{
    public class AuthorizationHelper
    {
        private readonly IWebDriver _driver;
        private readonly UserCredentials _credentials;

        public AuthorizationHelper(IWebDriver driver)
        {
            _driver = driver;
            _credentials = new UserCredentials {Email = "sagadeev.artem2001@gmail.com", Password = "Wepob19862001"};
        }

        public void Login()
        {
            _driver.FindElement(By.CssSelector(".cdlogin h3")).Click();
            _driver.FindElement(By.CssSelector(".css-i9gxme .css-1qv22w3")).SendKeys(_credentials.Email);
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).Click();
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).SendKeys(_credentials.Password);
            _driver.FindElement(By.CssSelector(".css-7y6612")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public void Logout()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#userMenu")));
            _driver.FindElement(By.CssSelector("#userMenu")).Click();
            _driver.FindElement(By.Id("logoutIcon")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public void IsAuthorised()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#pageTitle")));
            
            var pageTitle = _driver.FindElement(By.Id("pageTitle")).GetAttribute("innerHTML");
            var tagName = _driver.FindElement(By.Id("pageTitle")).TagName;
            
            Assert.AreEqual("All Items", pageTitle);
            Assert.AreEqual("h3", tagName);
        }

        public void IsNotAuthorised()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            var title = _driver.FindElement(By.TagName("title")).GetAttribute("innerHTML");
            
            Assert.AreEqual("#1 Password Manager & Vault App with Single-Sign On & MFA Solutions | LastPass", title);
        }
    }
}