using TestStack.BDDfy;
using NUnit.Framework;
using NuSelfUpdate.Tests.AppUpdaterBehaviour.ApplyPreparedUpdateScenarios;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour
{
    [TestFixture, Story(
        AsA = "As an application",
        IWant = "I want to apply a prepared update",
        SoThat = "So that I can give my users sweet new features and fix bugs.")]
    public class ApplyPreparedUpdate
    {
        [Test]
        public void PreparedUpdateIsANewerVerion()
        {
            new PreparedUpdateIsANewerVerion().BDDfy();
        }

        [Test]
        public void PreparedUpdateIsForAnOlderAppVersion()
        {
            new PreparedUpdateIsForAnOlderAppVersion().BDDfy();
        }

        [Test]
        public void PreparedUpdateIsForInstalledAppVersion()
        {
            new PreparedUpdateIsForInstalledAppVersion().BDDfy();
        }

        [Test]
        public void TheLastOldVersionHasNotBeenCleanedUp()
        {
            new TheLastOldVersionHasNotBeenCleanedUp().BDDfy();
        }
    }
}