﻿using System;
using System.Linq;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.PrepareUpdateScenarios
{
    public class PacakgeIsForOldVersion
    {
        SemanticVersion _installedVersion;
        AppUpdater _appUpdater;
        IPackage _oldVersionPackage;
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

        void AndGivenAPackageForAnOlderVersion()
        {
            _oldVersionPackage = Packages.FromVersions(TestConstants.AppPackageId, new SemanticVersion(new Version(0,1))).Single();
        }

        void WhenTheUpdateIsPrepared()
        {
            _exception = Run.CatchingException(() => _appUpdater.PrepareUpdate(_oldVersionPackage));
        }

        void ThenABackwardUpdateExceptionWillBeThrown()
        {
            _exception.ShouldBeOfType<BackwardUpdateException>();
            var backwardUpdate = (BackwardUpdateException) _exception;
            backwardUpdate.InstalledVersion.ShouldBe(_installedVersion);
            backwardUpdate.TargetVersion.ShouldBe(_oldVersionPackage.Version);
        }
    }
}