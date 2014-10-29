using System;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.PrepareUpdateScenarios
{
    public class NoPackageIsProvided
    {
        AppUpdater _appUpdater;
        Exception _exception;

        void GivenAnAppUpdater()
        {
            _appUpdater = new AppUpdaterBuilder(TestConstants.AppPackageId)
                .SetupWithTestValues(new SemanticVersion(new Version(1, 0)))
                .Build();
        }

        void WhenPrepareUpdateIsCalledWithoutProvidingAPackage()
        {
            _exception = Run.CatchingException(() =>_appUpdater.PrepareUpdate(null));
        }

        void ThenAnArgumentNullExceptionWillBeThrown()
        {
            _exception.ShouldBeOfType<ArgumentNullException>();
            ((ArgumentNullException)_exception).ParamName.ShouldBe("package");
        }
    }
}