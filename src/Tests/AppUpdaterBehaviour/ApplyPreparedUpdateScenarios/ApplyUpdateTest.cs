using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGet;
using NuSelfUpdate.Tests.Helpers;
using Shouldly;

namespace NuSelfUpdate.Tests.AppUpdaterBehaviour.ApplyPreparedUpdateScenarios
{
    public abstract class BaseApplyUpdateScenario
    {
        protected const string PrepDir = @"c:\app\.updates\1.1\";
        protected const string AppDirectory = @"c:\app\";
        protected const string OldDir = @"c:\app\.old\";

        protected MockFileSystem FileSystem { get; set; }

        protected void VerifyFile(string file, SemanticVersion version)
        {
            FileSystem.ReadAllText(file).ShouldBe(MockFileContent(Path.GetFileName(file), version));
        }

        protected void VerifyDirectoryFiles(string directory, IDictionary<string, SemanticVersion> expectedFiles)
        {
            foreach (var file in expectedFiles)
            {
                VerifyFile(Path.Combine(directory, file.Key), file.Value);
            }

            ShouldBeTestExtensions.ShouldBe(FileSystem.GetFiles(directory)
                                                                     .Select(Path.GetFileName)
                                                                     .All(expectedFiles.ContainsKey), true);
        }

        protected static string MockFileContent(string file, SemanticVersion version)
        {
            return Path.GetFileName(file) + " - v" + version;
        }
    }
}