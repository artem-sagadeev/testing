using NUnit.Framework;

namespace Testing
{
  [TestFixture]
  public class Tests : TestBase
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
