﻿using Bellatrix.Logging;
using Bellatrix.Mobile;
using Bellatrix.Mobile.IOS;
using Bellatrix.Mobile.TestExecutionExtensions;
using NUnit.Framework;

namespace Bellatrix.Web.NUnit.Tests
{
    [SetUpFixture]
    public class TestsInitialize
    {
        [OneTimeSetUpAttribute]
        public void AssemblyInitialize()
        {
            var app = new AndroidApp();

            app.UseExceptionLogger();
            app.UseNUnitSettings();
            app.UseAppBehavior();
            app.UseLogExecutionBehavior();
            app.UseIOSControlLocalOverridesCleanBehavior();
            app.UseFFmpegVideoRecorder();
            app.UseIOSDriverScreenshotsOnFail();
            app.UseLogger();
            app.UseElementsBddLogging();
            app.UseEnsureExtensionsBddLogging();
            app.UseLayoutAssertionExtensionsBddLogging();
            app.StartAppiumLocalService();
            app.Initialize();

            // Software machine automation module helps you to install the required software to the developer's machine
            // such as a specific version of the browsers, browser extensions, and any other required software.
            // You can configure it from BELLATRIX configuration file testFrameworkSettings.json
            //  "machineAutomationSettings": {
            //      "isEnabled": "true",
            //      "packagesToBeInstalled": [ "googlechrome", "firefox --version=65.0.2", "opera" ]
            //  }
            //
            // You need to specify the packages to be installed in the packagesToBeInstalled array. You can search for packages in the
            // public community repository- https://chocolatey.org/
            //
            // To use the service you need to start Visual Studio in Administrative Mode. The service supports currently only Windows.
            // In the future BELLATRIX releases we will support OSX and Linux as well.
            //
            // To use the machine automation setup- install Bellatrix.MachineAutomation NuGet package.
            // SoftwareAutomationService.InstallRequiredSoftware();
        }

        [OneTimeTearDown]
        public void AssemblyCleanUp()
        {
            var app = ServicesCollection.Current.Resolve<AndroidApp>();
            app?.Dispose();
            app?.StopAppiumLocalService();
        }
    }
}