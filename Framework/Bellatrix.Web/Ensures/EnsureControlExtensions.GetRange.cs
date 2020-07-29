﻿// <copyright file="EnsureControlExtensions.GetRange.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Web.Contracts;
using Bellatrix.Web.Events;

namespace Bellatrix.Web
{
    public static partial class EnsureControlExtensions
    {
        public static void EnsureRangeIs<T>(this T control, int value, int? timeout = null, int? sleepInterval = null)
            where T : IElementRange, IElement
        {
            WaitUntil(() => control.GetRange().Equals(value), $"The control's range should be '{value}' but was '{control.GetRange()}'.", timeout, sleepInterval);
            EnsuredRangeIsEvent?.Invoke(control, new ElementActionEventArgs(control, value.ToString()));
        }

        public static event EventHandler<ElementActionEventArgs> EnsuredRangeIsEvent;
    }
}