using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Testing.Helpers;

namespace Testing
{
    public class ApplicationManager : IDisposable
    {
        private readonly IWebDriver _driver;
        private IDictionary<string, object> _variables;
        private readonly IJavaScriptExecutor _js;

        public readonly AuthorizationHelper Authorization;
        public readonly NoteHelper Notes;
        public readonly NavigationHelper Navigation;
        
        private static readonly ThreadLocal<ApplicationManager> App = new();
        
        public static ApplicationManager GetInstance()
        {
            if (!App.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance.Navigation.OpenSite();
                App.Value = newInstance;
            }
            return App.Value;
        }


        private ApplicationManager()
        {
            _driver = new FirefoxDriver();
            _js = (IJavaScriptExecutor)_driver;
            _variables = new Dictionary<string, object>();
           
            Authorization = new AuthorizationHelper(_driver);
            Notes = new NoteHelper(_driver, _js);
            Navigation = new NavigationHelper(_driver);
        }
        
        ~ApplicationManager()
        {
            Dispose(false);
        }

        private void ReleaseUnmanagedResources()
        {
            _driver.Quit();
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                _driver?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}