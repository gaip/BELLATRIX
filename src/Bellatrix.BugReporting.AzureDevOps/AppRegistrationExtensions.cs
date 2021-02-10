﻿// <copyright file="AppRegistrationExtensions.cs" company="Automate The Planet Ltd.">
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
using System;
using System.Collections.Generic;
using System.Text;
using Bellatrix.Application;
using Bellatrix.BugReporting;
using Bellatrix.BugReporting.AzureDevOps;
using Bellatrix.BugReporting.Contracts;
using Bellatrix.TestExecutionExtensions.Screenshots.Plugins;
using Bellatrix.TestExecutionExtensions.Video.Plugins;
using Bellatrix.TestWorkflowPlugins;

namespace Bellatrix
{
    public static class AppRegistrationExtensions
    {
        public static BaseApp UseAzureDevOpsBugReporting(this BaseApp baseApp)
        {
            baseApp.RegisterInstance(new BugReportingContextService());
            baseApp.RegisterType<IBugReportingService, AzureDevOpsBugReportingService>();
            baseApp.RegisterType<TestWorkflowPlugin, BugReportingPlugin>(Guid.NewGuid().ToString());
            baseApp.RegisterType<IScreenshotPlugin, BugReportingPlugin>(Guid.NewGuid().ToString());
            baseApp.RegisterType<IVideoPlugin, BugReportingPlugin>(Guid.NewGuid().ToString());

            return baseApp;
        }
    }
}