using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Testing.Helpers;

namespace Testing
{
    public class ApplicationManager
    {
        private readonly IWebDriver _driver;
        private IDictionary<string, object> _variables;
        private readonly IJavaScriptExecutor _js;

        public readonly AuthorizationHelper Authorization;
        public readonly NoteHelper Notes;
        public readonly NavigationHelper Navigation;

        public ApplicationManager()
        {
            _driver = new FirefoxDriver();
            _js = (IJavaScriptExecutor)_driver;
            _variables = new Dictionary<string, object>();
           
            Authorization = new AuthorizationHelper(_driver);
            Notes = new NoteHelper(_driver, _js);
            Navigation = new NavigationHelper(_driver);
        }

        public void Stop()
        {
            _driver.Quit();
        }
    }
}