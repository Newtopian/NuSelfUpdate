using System;
using System.Collections.Generic;
using System.Linq;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.CheckForUpdateScenarios
{
    public class ASinlgeUpdateIsAvailable
    {
        SemanticVersion _installedVersion;
        SemanticVersion _newVersion;
        IEnumerable<IPackage> _packages;
        AppUpdater _updater;
        IUpdateCheck _updateCheck;
        AppUpdaterBuilder _builder;

        void GivenAnInstalledVersion()
        {
            _installedVersion = new SemanticVersion(new Version(1,0));
        }

        void AndGivenAPackageForANewerVersionHasBeenPublished()
        {
            _newVersion = new SemanticVersion(new Version(1, 1));
            _packages = Packages.FromVersions(TestConstants.AppPackageId, _installedVersion, _newVersion).ToList();

            _builder = new AppUpdaterBuilder(TestConstants.AppPackageId)
                .SetupWithTestValues(_installedVersion)
                .SetPublishedPackages(_packages);
        }

        void AndGivenAnAppUpdater()
        {
            _updater = _builder.Build();
        }

        void WhenCheckForUpdateIsCalled()
        {
            _updateCheck = _updater.CheckForUpdate();
        }

        void ThenUpdateAvailableWillBeTrue()
        {
            _updateCheck.UpdateAvailable.ShouldBe(true);
        }

        void AndTheUpdatePackageWillBeTheNewVersion()
        {
            var newPackage = _packages.Single(p => p.Version == _newVersion);
            _updateCheck.UpdatePackage.ShouldBe(newPackage);
        }
    }
}