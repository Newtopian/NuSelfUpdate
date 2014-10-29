using System;
using System.IO;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.RemoveOldVersionFilesScenarios
{
    public class BaseRemoveOldVerisionFilesScenario
    {
        protected const string AppDirectory = @"c:\app\";
        protected const string OldDir = @"c:\app\.old\";

        protected void VerifyFile(MockFileSystem fileSystem, string file, SemanticVersion version)
        {
            fileSystem.ReadAllText(file).ShouldBe(MockFileContent(Path.GetFileName(file), version));
        }

        protected static string MockFileContent(string file, SemanticVersion version)
        {
            return Path.GetFileName(file) + " - v" + version;
        }
    }
}