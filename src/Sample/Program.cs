﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using NuSelfUpdate;
using System.Reactive.Linq;

namespace NuSelfUpdate.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new AppUpdaterConfig("NuSelfUpdate.Sample")
                             {
                                 PackageSource = FullPath("packages")
                             };

            var appUpdater = new AppUpdater(config);

            var installedUpdates = Observable.Interval(TimeSpan.FromSeconds(5), Scheduler.TaskPool)
                .Select(_ => appUpdater.CheckForUpdate())
                .Do(Console.WriteLine)
                .Where(check => check.UpdateAvailable)
                .Take(1) // We only want to prepare the update once
                .Select(uc => appUpdater.PrepareUpdate(uc.UpdatePackage))
                .Do(Console.WriteLine)
                .Select(appUpdater.ApplyPreparedUpdate)
                .Do(Console.WriteLine)
                .Subscribe(Relaunch);

            Console.WriteLine("NuSelfUpdate.Sample - version: " + config.AppVersionProvider.CurrentVersion);
            Console.WriteLine("Sample, will check for updates every 5 seconds.");
            Console.WriteLine("Drop a new package version into the packages\\NuSelfUpdate.Sample.<version> folder to update.");

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");

            Console.ReadLine();
        }

        static void Relaunch(InstalledUpdate installedUpdate)
        {
            Console.WriteLine("Relaunching the app...");
            Process.Start(Environment.CommandLine.Replace("\"", ""));
            Environment.Exit(0);
        }

        static string FullPath(string relativePath)
        {
            if (Path.IsPathRooted(relativePath))
                return relativePath;

            var appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            return Path.Combine(appDir, relativePath);
        }
    }
}
