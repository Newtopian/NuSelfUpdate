using TestStack.BDDfy;
using NUnit.Framework;
using NuSelfUpdate.Tests.AppUpdaterBehaviour.RemoveOldVersionFilesScenarios;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour
{
    [TestFixture, Story(
        AsA = "As an application",
        IWant = "I want to delete previous versions of my self",
        SoThat = "I do not fill my users computer with cruft")]
    public class RemoveOldVersionFiles
    {
        [Test]
        public void OldFilesExist()
        {
            new OldFilesExist().BDDfy();
        }

        [Test]
        public void OldDirectoryExistsButDoesNotContainFiles()
        {
            new OldDirectoryExistsButDoesNotContainFiles().BDDfy();
        }

        [Test]
        public void OldFilesDoNotExist()
        {
            new OldFilesDoNotExist().BDDfy();
        }
    }
}