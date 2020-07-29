﻿// <copyright file="Switch.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Mobile.Contracts;
using Bellatrix.Mobile.Controls.Android;
using Bellatrix.Mobile.Events;

namespace Bellatrix.Mobile.Android
{
   public class Switch : Element, IElementDisabled, IElementOn, IElementText
    {
        public static Func<Switch, bool> OverrideIsDisabledGlobally;
        public static Func<Switch, bool> OverrideIsOnGlobally;
        public static Action<Switch> OverrideTurnOnGlobally;
        public static Action<Switch> OverrideTurnOffGlobally;
        public static Func<Switch, string> OverrideGetTextGlobally;

        public static Func<Switch, bool> OverrideIsDisabledLocally;
        public static Func<Switch, bool> OverrideIsOnLocally;
        public static Action<Switch> OverrideTurnOnLocally;
        public static Action<Switch> OverrideTurnOffLocally;
        public static Func<Switch, string> OverrideGetTextLocally;

        public static event EventHandler<ElementActionEventArgs<OpenQA.Selenium.Appium.Android.AndroidElement>> TurningOn;
        public static event EventHandler<ElementActionEventArgs<OpenQA.Selenium.Appium.Android.AndroidElement>> TurnedOn;
        public static event EventHandler<ElementActionEventArgs<OpenQA.Selenium.Appium.Android.AndroidElement>> TurningOff;
        public static event EventHandler<ElementActionEventArgs<OpenQA.Selenium.Appium.Android.AndroidElement>> TurnedOff;

        public static new void ClearLocalOverrides()
        {
            OverrideIsDisabledLocally = null;
            OverrideIsOnLocally = null;
            OverrideTurnOnLocally = null;
            OverrideTurnOffLocally = null;
        }

        public void TurnOn()
        {
            var action = InitializeAction(this, OverrideTurnOnGlobally, OverrideTurnOnLocally, DefaultTurnOn);
            action();
        }

        public void TurnOff()
        {
            var action = InitializeAction(this, OverrideTurnOffGlobally, OverrideTurnOffLocally, DefaultTurnOff);
            action();
        }

        public string GetText()
        {
            var action = InitializeAction(this, OverrideGetTextGlobally, OverrideGetTextLocally, DefaultText);
            return action();
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsOn
        {
            get
            {
                var action = InitializeAction(this, OverrideIsOnGlobally, OverrideIsOnLocally, DefaultIsOn);
                return action();
            }
        }

        protected virtual void DefaultTurnOn(Switch switchButton)
        {
            bool isElementChecked = DefaultIsOn(switchButton);
            if (!isElementChecked)
            {
                DefaultClick(switchButton, TurningOn, TurnedOn);
            }
        }

        protected virtual void DefaultTurnOff(Switch switchButton)
        {
            bool isChecked = DefaultIsOn(switchButton);
            if (isChecked)
            {
                DefaultClick(switchButton, TurningOff, TurnedOff);
            }
        }

        protected virtual string DefaultText(Switch switchButton) => DefaultGetText(switchButton);

        protected virtual bool DefaultIsDisabled(Switch switchButton) => !WrappedElement.Enabled;

        protected virtual bool DefaultIsOn(Switch switchButton) => DefaultIsChecked(switchButton);
    }
}