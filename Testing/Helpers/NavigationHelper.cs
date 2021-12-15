using OpenQA.Selenium;

namespace Testing.Helpers
{
    public class NavigationHelper
    {
        private const string BaseUrl = "https://www.lastpass.com/";
        private readonly IWebDriver _driver;

        public NavigationHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenSite()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void ChangeFrame()
        {
            var frame = _driver.FindElement(By.CssSelector("#newvault"));
            _driver.SwitchTo().Frame(frame);
        }
    }
}