﻿using Bellatrix.Mobile.EventHandlers.IOS;
using Bellatrix.Mobile.Events;
using OpenQA.Selenium.Appium.iOS;

namespace Bellatrix.Mobile.IOS.GettingStarted
{
    public class DebugLoggingButtonEventHandlers : ButtonEventHandlers
    {
        protected override void ClickingEventHandler(object sender, ElementActionEventArgs<IOSElement> arg)
        {
            DebugLogger.LogInfo($"Before clicking button. Coordinates: X={arg.Element.WrappedElement.Location.X} Y={arg.Element.WrappedElement.Location.Y}");
        }

        protected override void ClickedEventHandler(object sender, ElementActionEventArgs<IOSElement> arg)
        {
            DebugLogger.LogInfo($"After button clicked. Coordinates: X={arg.Element.WrappedElement.Location.X} Y={arg.Element.WrappedElement.Location.Y}");
        }
    }
}
