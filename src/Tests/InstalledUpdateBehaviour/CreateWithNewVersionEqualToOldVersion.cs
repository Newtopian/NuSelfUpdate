using System;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.InstalledUpdateBehaviour
{
    public class CreateWithNewVersionEqualToOldVersion : BddifyTest
    {
        SemanticVersion _oldVersion;
        SemanticVersion _newVersion;
        Exception _exception;

        void GivenAnOldVersion()
        {
            _oldVersion =new SemanticVersion(new Version(1, 0));
        }

        void AndGivenANewVersionThatIsTheSameAsTheOld()
        {
            _newVersion = new SemanticVersion(new Version(1, 0));
        }

        void WhenAttemptingToCreateAnInstalledUpdateWithThoseVersions()
        {
            _exception = Run.CatchingException(() => new InstalledUpdate(_oldVersion, _newVersion));
        }

        void ThenABackwardUpdateExceptionWillBeThrown()
        {
            _exception.ShouldNotBe(null);
            _exception.ShouldBeOfType<BackwardUpdateException>();
            var backwardUpdateEx = (BackwardUpdateException) _exception;
            backwardUpdateEx.InstalledVersion.ShouldBe(_oldVersion);
            backwardUpdateEx.TargetVersion.ShouldBe(_newVersion);
        }        
    }
}