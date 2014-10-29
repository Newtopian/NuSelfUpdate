using System;
using System.Collections.Generic;
using NuGet;

namespace NuSelfUpdate
{
    public class PreparedUpdate : IPreparedUpdate
    {
        public SemanticVersion Version { get; private set; }
        public IEnumerable<string> Files { get; private set; }

        public PreparedUpdate(SemanticVersion version, IEnumerable<string> files)
        {
            Version = version;
            Files = files;
        }
    }
}