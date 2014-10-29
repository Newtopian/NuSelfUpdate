﻿using System;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.LaunchInstalledUpdateScenarios
{
    public class InstalledUpdateIsNull
    {
        InstalledUpdate _installedUpdate;
        AppUpdater _appUpdater;
        Exception _exception;

        void GivenANullInstalledUpdate()
        {
            _installedUpdate = default(InstalledUpdate);
        }

        void AndGivenAnAppUpdater()
        {
            _appUpdater = new AppUpdaterBuilder(TestConstants.AppPackageId)
                .SetupWithTestValues(new SemanticVersion(new Version(1, 0)))
                .Build();
        }

        void WhenLaunchInstalledUpdateIsCalled()
        {
            _exception = Run.CatchingException(() => _appUpdater.LaunchInstalledUpdate(_installedUpdate));
        }

        void ThenAnArgumentNullExceptionWillBeThrown()
        {
            _exception.ShouldNotBe(null);
            _exception.ShouldBeOfType<ArgumentNullException>();
            var argEx = (ArgumentNullException) _exception;
            argEx.ParamName.ShouldBe("installedUpdate");
        }
    }
}