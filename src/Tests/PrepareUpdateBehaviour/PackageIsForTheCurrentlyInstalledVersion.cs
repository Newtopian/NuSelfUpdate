﻿using System;
using System.Linq;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.PrepareUpdateBehaviour
{
    public class PackageIsForTheCurrentlyInstalledVersion :BddifyTest
    {
        Version _installedVersion;
        AppUpdater _appUpdater;
        IPackage _currentVersionPacakge;
        Exception _exception;
        TestUpdaterConfig _config;

        void GivenAnInstalledVersion()
        {
            _installedVersion = new Version(1, 0);
        }

        void AndGivenAnAppUpdater()
        {
            _config = new TestUpdaterConfig(_installedVersion);
            _appUpdater = new AppUpdater(_config);
        }

        void AndGivenAPackageForTheCurrentlyInstalledVersion()
        {
            _currentVersionPacakge = Packages.FromVersions(_config.AppPackageId, _installedVersion).Single();
        }

        void WhenTheUpdateIsPrepared()
        {
            _exception = Run.CatchingException(() => _appUpdater.PrepareUpdate(_currentVersionPacakge));
        }

        void ThenABackwardUpdateExceptionWillBeThrown()
        {
            _exception.ShouldBeTypeOf<BackwardUpdateException>();
            var backwardUpdate = _exception.As<BackwardUpdateException>();
            backwardUpdate.InstalledVersion.ShouldBe(_installedVersion);
            backwardUpdate.TargetVersion.ShouldBe(_installedVersion);
        }
    }
}