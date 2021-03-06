﻿using System;
using System.Linq;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.PrepareUpdateScenarios
{
    public class PackageIsForTheVersionWhichIsCurrentlyInstalled
    {
        SemanticVersion _installedVersion;
        AppUpdater _appUpdater;
        IPackage _currentVersionPacakge;
        Exception _exception;

        void GivenAnInstalledVersion()
        {
            _installedVersion = new SemanticVersion(new Version(1, 0));
        }

        void AndGivenAnAppUpdater()
        {
            _appUpdater = new AppUpdaterBuilder(TestConstants.AppPackageId)
                .SetupWithTestValues(_installedVersion)
                .Build();
        }

        void AndGivenAPackageForTheCurrentlyInstalledVersion()
        {
            _currentVersionPacakge = Packages.FromVersions(TestConstants.AppPackageId, _installedVersion).Single();
        }

        void WhenTheUpdateIsPrepared()
        {
            _exception = Run.CatchingException(() => _appUpdater.PrepareUpdate(_currentVersionPacakge));
        }

        void ThenABackwardUpdateExceptionWillBeThrown()
        {
            _exception.ShouldBeOfType<BackwardUpdateException>();
            var backwardUpdate = (BackwardUpdateException) _exception;
            backwardUpdate.InstalledVersion.ShouldBe(_installedVersion);
            backwardUpdate.TargetVersion.ShouldBe(_installedVersion);
        }
    }
}