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
using Bellatrix.Web.Contracts;

namespace Bellatrix.Web
{
    public class Progress : Element, IElementMaxText, IElementValue, IElementInnerText
    {
        public static Func<Progress, string> OverrideValueGlobally;
        public static Func<Progress, string> OverrideMaxGlobally;
        public static Func<Progress, string> OverrideInnerTextGlobally;

        public static Func<Progress, string> OverrideValueLocally;
        public static Func<Progress, string> OverrideMaxLocally;
        public static Func<Progress, string> OverrideInnerTextLocally;

        public static new void ClearLocalOverrides()
        {
            OverrideValueLocally = null;
            OverrideMaxLocally = null;
            OverrideInnerTextLocally = null;
        }

        public override Type ElementType => GetType();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Max
        {
            get
            {
                var action = InitializeAction(this, OverrideMaxGlobally, OverrideMaxLocally, DefaultGetMax);
                return action();
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Value
        {
            get
            {
                var action = InitializeAction(this, OverrideValueGlobally, OverrideValueLocally, DefaultGetValue);
                return action();
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string InnerText
        {
            get
            {
                var action = InitializeAction(this, OverrideInnerTextGlobally, OverrideInnerTextLocally, DefaultInnerText);
                return action();
            }
        }

        protected virtual string DefaultInnerText(Progress progress) => base.DefaultInnerText(progress);

        protected virtual string DefaultGetValue(Progress progress) => WrappedElement.GetAttribute("value");

        protected virtual string DefaultGetMax(Progress progress) => DefaultGetMaxAsString(progress);
    }
}