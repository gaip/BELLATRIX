﻿// <copyright file="Progress.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;
using Bellatrix.Mobile.Controls.Android;

namespace Bellatrix.Mobile.IOS
{
    public class Progress : Element
    {
        public static Func<Progress, bool> OverrideIsDisabledGlobally;

        public static Func<Progress, bool> OverrideIsDisabledLocally;

        public static new void ClearLocalOverrides()
        {
            OverrideIsDisabledLocally = null;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsDisabled
        {
            get
            {
                var action = InitializeAction(this, OverrideIsDisabledGlobally, OverrideIsDisabledLocally, DefaultIsDisabled);
                return action();
            }
        }

        protected virtual bool DefaultIsDisabled(Progress button) => base.DefaultIsDisabled(button);
    }
}