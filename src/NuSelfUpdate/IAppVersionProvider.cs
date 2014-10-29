using System;
using NuGet;

namespace NuSelfUpdate
{
    public interface IAppVersionProvider
    {
        SemanticVersion CurrentVersion { get; }
    }
}