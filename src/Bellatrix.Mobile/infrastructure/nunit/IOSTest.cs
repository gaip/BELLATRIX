﻿// <copyright file="IOSTest.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>

using Bellatrix.Mobile.IOS;

namespace Bellatrix.Mobile.NUnit
{
    public abstract class IOSTest : NUnitBaseTest
    {
        public IOSApp App => ServicesCollection.Current.FindCollection(TestContext.Test.ClassName).Resolve<IOSApp>();

        public override void Configure()
        {
            NUnitPluginConfiguration.Add();
            ExecutionTimePlugin.Add();
            VideoRecorderPluginConfiguration.AddNUnit();
            ScreenshotsPluginConfiguration.AddNUnit();
            IOSPluginsConfiguration.AddIOSDriverScreenshotsOnFail();
            IOSPluginsConfiguration.AddElementsBddLogging();
            IOSPluginsConfiguration.AddDynamicTestCases();
            IOSPluginsConfiguration.AddBugReporting();
            IOSPluginsConfiguration.AddValidateExtensionsBddLogging();
            IOSPluginsConfiguration.AddValidateExtensionsDynamicTestCases();
            IOSPluginsConfiguration.AddValidateExtensionsBugReporting();
            IOSPluginsConfiguration.AddLayoutAssertionExtensionsBddLogging();
            IOSPluginsConfiguration.AddLayoutAssertionExtensionsDynamicTestCases();
            IOSPluginsConfiguration.AddLayoutAssertionExtensionsBugReporting();
            IOSPluginsConfiguration.AddLifecycle();
            IOSPluginsConfiguration.AddLogExecutionLifecycle();
        }
    }
}