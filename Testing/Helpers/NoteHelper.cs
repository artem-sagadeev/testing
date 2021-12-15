using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Testing.Entities;

namespace Testing.Helpers
{
    public class NoteHelper
    {
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _js;

        public NoteHelper(IWebDriver driver, IJavaScriptExecutor js)
        {
            _driver = driver;
            _js = js;
        }
        
        public void Create()
        {
            var newNote = new SecureNote {Name = "New note", Text = "Content of the note"};
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#addMenuButtonCustom")));
            _js.ExecuteScript("document.getElementById('addMenuButtonDefault').style.display='none';" +
                              "document.getElementById('addMenuButtonCustom').style.display='block';");
            _driver.FindElement(By.CssSelector("#addMenuButtonCustom .focusable-add-menu-item")).Click();
            _driver.FindElement(By.CssSelector(".SecureNote")).Click();
            _driver.FindElement(By.CssSelector("div:nth-child(1) > div > .dialogInput")).Click();
            _driver.FindElement(By.CssSelector("div:nth-child(1) > div > .dialogInput")).SendKeys(newNote.Name);
            _driver.FindElement(By.CssSelector("td > .dialogInput")).Click();
            _driver.FindElement(By.CssSelector("td > .dialogInput")).SendKeys(newNote.Text);
            _driver.FindElement(By.CssSelector(".rbtn:nth-child(3)")).Click();
        }

        public void Edit()
        {
            var updatedNote = new SecureNote {Text = "Updated content"};
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".launchButton")));
            _js.ExecuteScript("document.getElementsByClassName('itemIconOverlay')[0].style.display='block';" +
                              "document.getElementsByClassName('launchButton')[0].style.display='block';");
            _driver.FindElement(By.CssSelector(".launchButton")).Click();
            _driver.FindElement(By.CssSelector("td > .dialogInput")).Click();
            _driver.FindElement(By.CssSelector("td > .dialogInput")).SendKeys(updatedNote.Text);
            _driver.FindElement(By.CssSelector(".rbtn:nth-child(3)")).Click();
        }
    }
}