﻿// <copyright file="Date.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Desktop.Contracts;
using Bellatrix.Desktop.Events;

namespace Bellatrix.Desktop
{
     public class Date : Element, IElementDisabled, IElementDate
    {
        public static Action<Date> OverrideHoverGlobally;
        public static Func<Date, bool> OverrideIsDisabledGlobally;
        public static Func<Date, string> OverrideGetDateGlobally;
        public static Action<Date, int, int, int> OverrideSetDateGlobally;

        public static Action<Date> OverrideHoverLocally;
        public static Func<Date, bool> OverrideIsDisabledLocally;
        public static Func<Date, string> OverrideGetDateLocally;
        public static Action<Date, int, int, int> OverrideSetDateLocally;

        public static event EventHandler<ElementActionEventArgs> Hovering;
        public static event EventHandler<ElementActionEventArgs> Hovered;
        public static event EventHandler<ElementActionEventArgs> SettingDate;
        public static event EventHandler<ElementActionEventArgs> DateSet;

        public static new void ClearLocalOverrides()
        {
            OverrideHoverLocally = null;
            OverrideIsDisabledLocally = null;
            OverrideGetDateLocally = null;
            OverrideSetDateLocally = null;
        }

        public string GetDate()
        {
            var action = InitializeAction(this, OverrideGetDateGlobally, OverrideGetDateLocally, (d) => WrappedElement.Text);
            return action();
        }

        public void SetDate(int year, int month, int day)
        {
            var action = InitializeAction(this, OverrideSetDateGlobally, OverrideSetDateLocally, DefaultSetDate);
            action(year, month, day);
        }

        public void Hover()
        {
            var action = InitializeAction(this, OverrideHoverGlobally, OverrideHoverLocally, DefaultHover);
            action();
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

        protected virtual void DefaultHover(Date date) => DefaultHover(date, Hovering, Hovered);

        protected virtual bool DefaultIsDisabled(Date date) => base.DefaultIsDisabled(date);

        protected virtual void DefaultSetDate(Date date, int year, int month, int day)
        {
            if (year <= 0)
            {
                throw new ArgumentException($"The year should be a positive number but you specified: {year}");
            }

            if (month <= 0 || month > 12)
            {
                throw new ArgumentException($"The month should be between 0 and 12 but you specified: {month}");
            }

            if (day <= 0 || day > 31)
            {
                throw new ArgumentException($"The day should be between 0 and 31 but you specified: {day}");
            }

            string valueToBeSet = month < 10 ? $"0{month}\\{year}" : $"{month}\\{year}";
            valueToBeSet = day < 10 ? $"{valueToBeSet}-0{day}" : $"{day}\\{valueToBeSet}";
            DefaultSetText(date, SettingDate, DateSet, valueToBeSet);
        }
    }
}