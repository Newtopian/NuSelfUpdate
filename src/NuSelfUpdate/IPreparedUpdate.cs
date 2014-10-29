using System;
using System.Collections.Generic;
using NuGet;

namespace NuSelfUpdate
{
    public interface IPreparedUpdate
    {
        SemanticVersion Version { get; }
        IEnumerable<string> Files { get; }        
    }
}