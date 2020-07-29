﻿// <copyright file="EnsureControlExtensions.GetVisible.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Desktop.Contracts;
using Bellatrix.Desktop.Events;

namespace Bellatrix.Desktop
{
    public static partial class EnsureControlExtensions
    {
        public static void EnsureIsVisible<T>(this T control, int? timeout = null, int? sleepInterval = null)
            where T : IElementVisible, IElement
        {
            WaitUntil(() => control.IsVisible.Equals(true), "The control should be visible but was NOT.", timeout, sleepInterval);
            EnsuredIsVisibleEvent?.Invoke(control, new ElementActionEventArgs(control));
        }

        public static void EnsureIsNotVisible<T>(this T control, int? timeout = null, int? sleepInterval = null)
            where T : IElementVisible, IElement
        {
            WaitUntil(() => !control.IsVisible.Equals(true), "The control should be NOT visible but was NOT.", timeout, sleepInterval);
            EnsuredIsNotVisibleEvent?.Invoke(control, new ElementActionEventArgs(control));
        }

        public static event EventHandler<ElementActionEventArgs> EnsuredIsVisibleEvent;
        public static event EventHandler<ElementActionEventArgs> EnsuredIsNotVisibleEvent;
    }
}