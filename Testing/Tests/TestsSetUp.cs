using NUnit.Framework;

namespace Testing.Tests
{
    public class TestsSetUp
    {
        [SetUpFixture]
        public class TestsSetup
        {
            [OneTimeTearDown]
            public void GlobalTeardown()
            {
                ApplicationManager.GetInstance().Dispose();
            }
        }
    }
}