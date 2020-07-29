﻿// <copyright file="ITestWorkflowPluginProvider.cs" company="Automate The Planet Ltd.">
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

namespace Bellatrix.SpecFlow.TestWorkflowPlugins
{
    public interface ITestWorkflowPluginProvider
    {
        event EventHandler<TestWorkflowPluginEventArgs> PreBeforeScenarioEvent;

        event EventHandler<TestWorkflowPluginEventArgs> TestInitFailedEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PostBeforeScenarioEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PreAfterScenarioEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PostAfterScenarioEvent;

        event EventHandler<TestWorkflowPluginEventArgs> TestCleanupFailedEvent;

        event EventHandler<Exception> BeforeScenarioFailedEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PreBeforeFeatureActEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PreBeforeFeatureArrangeEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PostBeforeFeatureActEvent;

        event EventHandler<TestWorkflowPluginEventArgs> PostBeforeFeatureArrangeEvent;
    }
}