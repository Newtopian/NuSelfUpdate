using TestStack.BDDfy;
using NUnit.Framework;
using NuSelfUpdate.Tests.AppUpdaterBehaviour.PrepareUpdateScenarios;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour
{
    [TestFixture, Story(
        AsA = "As an application",
        IWant = "I want to prepare an update",
        SoThat = "So that when I can update quickly and also so I can validate the update before proceeding with the update")]
    public class PrepareUpdate
    {
        [Test]
        public void NoPackageIsProvided()
        {
            new NoPackageIsProvided().BDDfy();
        }

        [Test]
        public void PackageIdIsNotForThisApplication()
        {
            new PackageIdIsNotForThisApplication().BDDfy();
        }

        [Test]
        public void PackageIsForAVersionOlderThanTheCurrentlyInstalledVersion()
        {
            new PacakgeIsForOldVersion().BDDfy();
        }

        [Test]
        public void PackageIsForTheVersionWhichIsCurrentlyInstalled()
        {
            new PackageIsForTheVersionWhichIsCurrentlyInstalled().BDDfy();
        }

        [Test]
        public void AValidPackageIsProvided()
        {
            new AValidPackageIsProvided().BDDfy();
        }
    }
}