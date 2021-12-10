using System.Collections.Generic;
using System.Threading;
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
        }
    
        protected void Login()
        {
            _driver.FindElement(By.CssSelector(".cdlogin h3")).Click();
            _driver.FindElement(By.CssSelector(".css-i9gxme .css-1qv22w3")).SendKeys(_credentials.Email);
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).Click();
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).SendKeys(_credentials.Password);
            _driver.FindElement(By.CssSelector(".css-7y6612")).Click();
        }

        protected void CreateNote()
        {
            _driver.SwitchTo().Frame(0);
            _driver.FindElement(By.CssSelector("#addMenuButtonCustom .focusable-add-menu-item")).Click();
            _driver.FindElement(By.CssSelector(".SecureNote")).Click();
            _driver.FindElement(By.CssSelector("div:nth-child(1) > div > .dialogInput")).Click();
            _driver.FindElement(By.CssSelector("div:nth-child(1) > div > .dialogInput")).SendKeys("New note");
            _driver.FindElement(By.CssSelector("td > .dialogInput")).Click();
            _driver.FindElement(By.CssSelector("td > .dialogInput")).SendKeys("Content of the note");
            _driver.FindElement(By.CssSelector(".rbtn:nth-child(3)")).Click();
        }
    }
}