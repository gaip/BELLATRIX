﻿// <copyright file="Number.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;
using Bellatrix.Mobile.Contracts;
using Bellatrix.Mobile.Controls.IOS;
using Bellatrix.Mobile.Events;
using OpenQA.Selenium.Appium.iOS;

namespace Bellatrix.Mobile.IOS
{
    public class Number : Element, IElementDisabled, IElementNumber
    {
        public static event EventHandler<ElementActionEventArgs<IOSElement>> SettingNumber;
        public static event EventHandler<ElementActionEventArgs<IOSElement>> NumberSet;

        public void SetNumber(int value)
        {
            SetValue(SettingNumber, NumberSet, value.ToString());
        }

        public int GetNumber()
        {
            var resultText = GetValueAttribute();
            int.TryParse(resultText, out var result);
            return result;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsDisabled => GetIsDisabled();
    }
}