using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Testing.Entities;
using Testing.Helpers;

namespace Testing
{
    public class TestBase
    {
        protected ApplicationManager App;
        
        [SetUp]
        public void SetUp()
        {
            App = new ApplicationManager();
        }
    
        [TearDown]
        protected void TearDown() 
        {
            App.Stop();
        }
    }
}