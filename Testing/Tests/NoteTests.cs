using NUnit.Framework;

namespace Testing.Tests
{
    public class NoteTests : TestBase
    {
        [Test]
        public void Creating()
        {
            App.Navigation.OpenSite();
            App.Authorization.Login();
            App.Navigation.ChangeFrame();
            App.Notes.Create();
        }

        [Test]
        public void Editing()
        {
            App.Navigation.OpenSite();
            App.Authorization.Login();
            App.Navigation.ChangeFrame();
            App.Notes.Edit();
        }
    }
}