using NUnit.Framework;

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

    [Test]
    public void NoteCreating()
    {
      OpenSite();
      Login();
      CreateNote();
    }
  }
}
