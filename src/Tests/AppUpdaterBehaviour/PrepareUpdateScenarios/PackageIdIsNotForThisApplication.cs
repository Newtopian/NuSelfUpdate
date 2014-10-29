using System;
using System.Linq;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.PrepareUpdateScenarios
{
    public class PackageIdIsNotForThisApplication
    {
        SemanticVersion _installedVersion;
        AppUpdater _appUpdater;
        IPackage _incorrectPackage;
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

        void AndGivenAPackageWithANewerVersionNumberButAnIdOtherThanTheAppsId()
        {
            _incorrectPackage = Packages.FromVersions("Not.Target.Id", new SemanticVersion(new Version(1, 1))).First();
        }

        void WhenTheUpdateIsPrepared()
        {
            _exception = Run.CatchingException(() => _appUpdater.PrepareUpdate(_incorrectPackage));
        }

        void ThenAnArgumentExceptionWillBeThrown()
        {
            _exception.ShouldBeOfType<ArgumentException>();
            ((ArgumentException)_exception).ParamName.ShouldBe("package");
        }
    }
}