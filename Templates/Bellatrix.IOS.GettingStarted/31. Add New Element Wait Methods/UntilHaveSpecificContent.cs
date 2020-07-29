﻿using System;
using Bellatrix.Mobile.Configuration;
using Bellatrix.Mobile.Locators;
using Bellatrix.Mobile.Untils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Bellatrix.Mobile.IOS.GettingStarted
{
    // 1. Imagine that you want to wait for an element to have a specific content.
    // First, create a new class and inherit the BaseUntil class.
    public class UntilHaveSpecificContent<TDriver, TDriverElement> : BaseUntil<TDriver, TDriverElement>
        where TDriver : IOSDriver<TDriverElement>
        where TDriverElement : AppiumWebElement
    {
        private readonly string _elementContent;

        public UntilHaveSpecificContent(string elementContent, int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval)
        {
            _elementContent = elementContent;
            TimeoutInterval = timeoutInterval ?? Bellatrix.ConfigurationService.Instance.GetMobileSettings().ElementToHaveContentTimeout;
        }

        public override void WaitUntil<TBy>(TBy by) => WaitUntil(ElementHasSpecificContent(WrappedWebDriver, by), TimeoutInterval, SleepInterval);

        // 2. We find the element and check the current value in the Text attribute.
        // The internal WaitUntil will wait until the value changes in the specified time.
        private Func<TDriver, bool> ElementHasSpecificContent<TBy>(TDriver searchContext, TBy by)
            where TBy : By<TDriver, TDriverElement>
        {
            return driver =>
            {
                try
                {
                    var element = by.FindElement(searchContext);
                    return element.Text == _elementContent;
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