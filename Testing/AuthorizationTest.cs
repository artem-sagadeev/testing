using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Testing
{
  [TestFixture]
  public class AuthorizationTest : TestBase
  {
    [Test]
    public void Authorization() {
      OpenSite();
      Login();
    }
  }
}
