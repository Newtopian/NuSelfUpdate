using System;
using NSubstitute;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.ApplyPreparedUpdateScenarios
{
    public class PreparedUpdateIsForAnOlderAppVersion
    {
        SemanticVersion _installedVersion;
        IPreparedUpdate _preparedUpdate;
        Exception _exception;
        AppUpdater _appUpdater;

        void GivenAnInstaledVersion()
        {
            _installedVersion = new SemanticVersion(new Version(1, 1));
        }

        void AndGivenAPreparedUpdateForAnOlderVersion()
        {
            _preparedUpdate = Substitute.For<IPreparedUpdate>();
            _preparedUpdate.Version.Returns(new SemanticVersion(new Version(1, 0)));
        }

        void AndGivenAnAppUpdater()
        {
            _appUpdater = new AppUpdaterBuilder(TestConstants.AppPackageId)
                .SetupWithTestValues(_installedVersion)
                .Build();
        }

        void WhenApplyingPreparedUpdate()
        {
            _exception = Run.CatchingException(() => _appUpdater.ApplyPreparedUpdate(_preparedUpdate));
        }

        void ThenABackwardUpdateExceptionWillBeThrown()
        {
            _exception.ShouldBeOfType<BackwardUpdateException>();
            var backwardUpdate = _exception as BackwardUpdateException;

            backwardUpdate.InstalledVersion.ShouldBe(_installedVersion);
            backwardUpdate.TargetVersion.ShouldBe(_preparedUpdate.Version);
        }
    }
}