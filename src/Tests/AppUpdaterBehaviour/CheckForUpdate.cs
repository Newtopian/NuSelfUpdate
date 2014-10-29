using TestStack.BDDfy;
using NUnit.Framework;
using NuSelfUpdate.Tests.AppUpdaterBehaviour.CheckForUpdateScenarios;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour
{
    [TestFixture, Story(
        AsA = "As an application",
        IWant = "I want to check and see if there are new updates available",
        SoThat = "I can start the process of updating my self")]
    public class CheckForUpdate
    {
        [Test]
        public void NoPackagesHaveEverBeenPublished()
        {
            new NoPackagesHaveEverBeenPublished().BDDfy();
        }

        [Test]
        public void NoUpdatesAvailable()
        {
            new NoUpdatesAvailable().BDDfy();
        }

        [Test]
        public void ASingleUpdateIsAvailable()
        {
            new ASinlgeUpdateIsAvailable().BDDfy();
        }

        [Test]
        public void MultipleUpdatesAreAvailable()
        {
            new MultipleUpdatesAreAvailable().BDDfy();
        }
    }
}