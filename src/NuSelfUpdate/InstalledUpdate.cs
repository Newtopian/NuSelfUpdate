using System;
using NuGet;

namespace NuSelfUpdate
{
    public class InstalledUpdate
    {
        public SemanticVersion OldVersion { get; private set; }
        public SemanticVersion NewVersion { get; private set; }

        public InstalledUpdate(SemanticVersion old, SemanticVersion newVersion)
        {
            if (old >= newVersion)
                throw new BackwardUpdateException(old, newVersion);

            OldVersion = old;
            NewVersion = newVersion;
        }

        public override string ToString()
        {
            return "Installed Update: " + OldVersion + " -> " + NewVersion;
        }
    }
}