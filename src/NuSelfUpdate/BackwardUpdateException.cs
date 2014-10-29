using System;
using NuGet;

namespace NuSelfUpdate
{
    public class BackwardUpdateException : Exception
    {
        public SemanticVersion InstalledVersion { get; private set; }
        public SemanticVersion TargetVersion { get; private set; }

        public BackwardUpdateException(SemanticVersion installedVersion, SemanticVersion targetVersion)
            : base(string.Format("Can only update to a newer version. Installed Version: {0}, Update Version: {1}", installedVersion, targetVersion))
        {
            InstalledVersion = installedVersion;
            TargetVersion = targetVersion;
        }
    }
}