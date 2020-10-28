﻿// <copyright file="AppRegistrationExtensions.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
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
using Bellatrix.Application;
using Bellatrix.Mobile.TestExecutionExtensions;
using Bellatrix.TestWorkflowPlugins;

namespace Bellatrix
{
    public static class AppRegistrationExtensions
    {
        public static BaseApp UseAppBehavior(this BaseApp baseApp)
        {
            baseApp.RegisterType<TestWorkflowPlugin, AppWorkflowPlugin>(Guid.NewGuid().ToString());

            return baseApp;
        }

        public static BaseApp UseLogExecutionBehavior(this BaseApp baseApp)
        {
            baseApp.RegisterType<TestWorkflowPlugin, LogWorkflowPlugin>(Guid.NewGuid().ToString());

            return baseApp;
        }

        public static BaseApp UseAndroidControlLocalOverridesCleanBehavior(this BaseApp baseApp)
        {
            baseApp.RegisterType<TestWorkflowPlugin, AndroidControlsLocalOverridesCleanExtension>(Guid.NewGuid().ToString());

            return baseApp;
        }

        public static BaseApp UseIOSControlLocalOverridesCleanBehavior(this BaseApp baseApp)
        {
            baseApp.RegisterType<TestWorkflowPlugin, IOSControlsLocalOverridesCleanExtension>(Guid.NewGuid().ToString());

            return baseApp;
        }
    }
}