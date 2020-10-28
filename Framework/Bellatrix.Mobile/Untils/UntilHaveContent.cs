﻿// <copyright file="UntilHaveContent.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Mobile.Configuration;
using Bellatrix.Mobile.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Bellatrix.Mobile.Untils
{
    public class UntilHaveContent<TDriver, TDriverElement> : BaseUntil<TDriver, TDriverElement>
       where TDriver : AppiumDriver<TDriverElement>
       where TDriverElement : AppiumWebElement
    {
        public UntilHaveContent(int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval) => TimeoutInterval = timeoutInterval ?? ConfigurationService.Instance.GetMobileSettings().ElementToHaveContentTimeout;

        public override void WaitUntil<TBy>(TBy by) => WaitUntil(ElementHasContent(WrappedWebDriver, by), TimeoutInterval, SleepInterval);

        private Func<TDriver, bool> ElementHasContent<TBy>(TDriver searchContext, TBy by)
            where TBy : By<TDriver, TDriverElement>
        {
            return driver =>
            {
                try
                {
                    var element = by.FindElement(searchContext);
                    return !string.IsNullOrEmpty(element.Text);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            };
        }
    }
}