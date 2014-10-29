using System;
using System.Reflection;
using NuGet;

namespace NuSelfUpdate
{
    public class EntryAssemblyAppVersionProvider : IAppVersionProvider
    {
        public SemanticVersion CurrentVersion
        {
            get
            {
                //shold probably make this configurable somehow to get the appropriate field, dont matter much though, in my case it's all good
                var informationnalVersion = Attribute
                    .GetCustomAttribute(
                        Assembly.GetEntryAssembly(),
                        typeof(AssemblyInformationalVersionAttribute))
                    as AssemblyInformationalVersionAttribute;

                return new SemanticVersion(Assembly.GetEntryAssembly().GetName().Version, informationnalVersion == null ? null : informationnalVersion.InformationalVersion);
            }
        }
    }
}