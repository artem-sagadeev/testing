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
        protected readonly ApplicationManager App = ApplicationManager.GetInstance();
    }
}