﻿using Bellatrix.Desktop.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Desktop.GettingStarted
{
    [TestClass]
    [App(Constants.WpfAppPath, Lifecycle.RestartEveryTime)]
    public class LocateAndWaitElementsTests : DesktopTest
    {
        [TestMethod]
        [TestCategory(Categories.CI)]
        public void MessageChanged_When_ButtonHovered_Wpf()
        {
              // 1. Sometimes you need to perform an action against an element only when a specific condition is true.
            // As mentioned in previous part of the guide, BELLATRIX by default always waits for elements to exist.
            // However, sometimes this may not be enough. For example, you may want to click on a button once it is clickable.
            // It may be disabled at the beginning of the tests because some validation is not met. Your test fulfil the initial condition and if you use
            // vanilla WebDriver the test most probably fails because WebDriver clicks too fast before your button is enabled by your code.
            // So we created additional syntax sugar methods to help you deal with this.
            // You can use element "ToBe" methods after the Create and CreateAll methods.
            // As you can see in the example below you can chain multiple of this methods.
            //
            // Note: Since Bellatrix, elements creation logic is lazy loading as mentioned before,
            // BELLATRIX waits for the conditions to be True on the first action you perform with the element.
            //
            // Note 2: Keep in mind that with this syntax these conditions are checked everytime you perform an action with the element.
            // Which can lead tо small execution delays.
            //
            // The default timeouts that BELLATRIX use are placed inside the testFrameworkSettings file, mentioned in '01. Folder and File Structure' chapter.
            // Inside it, is the timeoutSettings section. All values are in seconds.
            // "timeoutSettings": {
            //    "sleepInterval": "1",
            //    "elementToBeVisibleTimeout": "30",
            //    "elementToExistTimeout": "30",
            //    "elementToNotExistTimeout": "30",
            //    "elementToBeClickableTimeout": "30",
            //    "elementNotToBeVisibleTimeout": "30",
            //    "elementToHaveContentTimeout": "15"
            // },
            var button = App.ElementCreateService.CreateByName<Button>("E Button").ToBeVisible();

            button.Hover();

            // 2. You can always override the timeout settings for each method.
            // The first value is the timeout in seconds and the second one controls how often the engine checks the condition.
            var label = App.ElementCreateService.CreateByAutomationId<Label>("ResultLabelId").ToHasContent(40, 1);
            Assert.AreEqual("ebuttonHovered", label.InnerText);

            // 3. All available ToBe methods:
            // ToExists  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToExists();
            // Waits for the element to exist. BELLATRIX always does it by default.
            // But if use another ToBe methods you need to add it again since you have to override the default lifecycle.
            //
            // ToNotExists  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToNotExists();
            // Waits for the element to disappear. Usually, we use in assertion methods.
            //
            // ToBeVisible  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToBeVisible();
            // Waits for the element to be visible.
            //
            // ToNotBeVisible  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToNotBeVisible();
            // Waits for the element to be invisible.
            //
            // ToBeClickable  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToBeClickable();
            // Waits for the element to be clickable (may be disabled at first).
            //
            // ToHasContent  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToHasContent();
            // Waits for the element to has some content in it. For example, some validation or label.
            //
            // ToHasStyle  --> App.ElementCreateService.CreateByName<Button>("Purchase").ToHasStyle("disabled");
            // Waits for the element to have some content in it. For example, some validation or label.
            //
            // ToBeDisabled  --> App.ElementCreateService.CreateByName<Anchor>("Purchase").ToBeDisabled();
            // Waits for the element to be disabled.
        }
    }
}