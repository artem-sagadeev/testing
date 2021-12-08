﻿using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Testing
{
    public class TestBase
    {
        private IWebDriver _driver;
        private IDictionary<string, object> Variables { get; set; }
        private IJavaScriptExecutor _js;
        
        [SetUp]
        public void SetUp() {
            _driver = new FirefoxDriver();
            _js = (IJavaScriptExecutor)_driver;
            Variables = new Dictionary<string, object>();
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
            _driver.FindElement(By.CssSelector(".css-i9gxme .css-1qv22w3")).SendKeys("sagadeev.artem2001@gmail.com");
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).Click();
            _driver.FindElement(By.CssSelector(".css-79elbk .css-1qv22w3")).SendKeys("Wepob19862001");
            _driver.FindElement(By.CssSelector(".css-7y6612")).Click();
        }
    }
}