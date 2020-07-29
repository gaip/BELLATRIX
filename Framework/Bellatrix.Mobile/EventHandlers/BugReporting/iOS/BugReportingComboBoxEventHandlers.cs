﻿// <copyright file="BugReportingComboBoxEventHandlers.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.BugReporting;
using Bellatrix.Logging;
using Bellatrix.Mobile.EventHandlers.IOS;
using Bellatrix.Mobile.Events;
using OpenQA.Selenium.Appium.iOS;

namespace Bellatrix.Mobile.BugReporting.IOS
{
    public class BugReportingComboBoxEventHandlers : ComboBoxEventHandlers
    {
        protected BugReportingContextService BugReportingContextService => ServicesCollection.Current.Resolve<BugReportingContextService>();

        protected override void SelectingEventHandler(object sender, ElementActionEventArgs<IOSElement> arg) => BugReportingContextService.AddStep($"Select '{arg.ActionValue}' from {arg.Element.ElementName} on {arg.Element.PageName}");
    }
}