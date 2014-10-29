using TestStack.BDDfy;
using NUnit.Framework;
using NuSelfUpdate.Tests.AppUpdaterBehaviour.OldVersionExistsScenarios;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour
{
    [TestFixture, Story(
        AsA = "As an application",
        IWant = "I want to determine if a previous version of myself exists",
        SoThat = "I can perform any post update steps and/or clean up the previous version")]
    public class OldVersionExists
    {
        [Test]
        public void NoOldVersionExists()
        {
            new NoOldVersionExists().BDDfy();
        }

        [Test]
        public void AnOldVersionExists()
        {
            new AnOldVersionExists().BDDfy();
        }
    }
}