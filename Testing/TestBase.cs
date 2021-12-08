using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Testing.Entities;

namespace Testing
{
    public class TestBase
    {
        private IWebDriver _driver;
        private IDictionary<string, object> _variables;
        private IJavaScriptExecutor _js;

        private UserCredentials _credentials;
        
        [SetUp]
        public void SetUp() {
            _driver = new FirefoxDriver();
            _js = (IJavaScriptExecutor)_driver;
            _variables = new Dictionary<string, object>();
            _credentials = new UserCredentials {Email = "sagadeev.artem2001@gmail.com", Password = "Wepob19862001"};
        }
    
        [TearDown]
        protected void TearDown() {
            _driver.Quit();
        }
        
        protected void OpenSite()
        {
            _driver.Navigate().GoToUrl("https://www.lastpass.com/");
            _driver.Manage().Window.Size = new System.Drawing.Size(1295, 695);
        }
    
        protected void Login()
        {
            _driver.FindElement(By.CssSelector(".cdlogin h3")).Click();
            _driver.FindElement(By.CssSelector(".css-i9gxme .css-1qv22w3")).SendKeys(_credentials.Email);
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).Click();
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).SendKeys(_credentials.Password);
            _driver.FindElement(By.CssSelector(".css-7y6612")).Click();
        }
    }
}