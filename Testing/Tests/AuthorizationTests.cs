using NUnit.Framework;

namespace Testing.Tests
{
    public class AuthorizationTests : TestBase
    {
        [Test]
        public void Login() {
            App.Navigation.OpenSite();
            App.Authorization.Login();
        }
        
        [Test]
        public void Logout() {
            App.Navigation.OpenSite();
            App.Authorization.Login();
            App.Navigation.ChangeFrame();
            App.Authorization.Logout();
        }
    }
}