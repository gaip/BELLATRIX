﻿using Bellatrix.Mobile.Controls.Android;
using OpenQA.Selenium.Appium.Android;

namespace Bellatrix.Mobile.Android.GettingStarted.ExtensionMethodsWaitMethods
{
    public static class WaitStrategyElementsExtensions
    {
        // 1. The next and final step is to create an extension method for all UI elements.
        // After WaitToHaveContentStrategy is created, it is important to be passed on to the element’s ValidateState method.
        public static TElementType ToHaveSpecificContent<TElementType>(this TElementType element, string content, int? timeoutInterval = null, int? sleepInterval = null)
         where TElementType : Element
        {
            var until = new WaitToHaveSpecificContentStrategy<AndroidDriver<AndroidElement>, AndroidElement>(content, timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }
    }
}
