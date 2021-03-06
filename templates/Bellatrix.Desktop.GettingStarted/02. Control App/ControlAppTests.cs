﻿using Bellatrix.Desktop.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Desktop.GettingStarted
{
    // 1. This is the main attribute that you need to mark each class that contains MSTest tests.
    [TestClass]

    // 2. This is the attribute for automatic start/control of WebDriver applications by Bellatrix. If you have to do it manually properly, you will need thousands of lines of code.
    // 2.1. appPath- sets the path where your application is.
    // 2.2. Lifecycle enum controls when the app is started and stopped. This can drastically increase or decrease the tests execution time, depending on your needs.
    // However you need to be careful because in case of tests failures the app may need to be restarted.
    // Available options:
    // RestartEveryTime- for each test a separate WebDriver instance is created and the previous app instance is closed.
    // RestartOnFail- the app is only restarted if the previous test failed. Alternatively, if the previous test's app was different.
    // ReuseIfStarted- the app is only restarted if the previous test's app was different. In all other cases, the app is reused if possible.
    // Note: However, use this option with caution since in some rare cases if you have not properly setup your tests you may need to restart the app if the test fails otherwise all other tests may fail too.
    //
    // There are even more things you can do with this attribute, but we look into them in the next sections.
    //
    // If you place attribute over the class all tests inherit the lifecycle. It is possible to place it over each test and this way it overrides the class lifecycle only for this particular test.
    [App(Constants.WpfAppPath, Lifecycle.RestartEveryTime)]

    // 2.2. All web BELLATRIX test classes should inherit from the DesktopTest base class. This way you can use all built-in BELLATRIX tools and functionalities.
    public class ControlAppTests : DesktopTest
    {
        // 2.3. All MSTest tests should be marked with the TestMethod attribute.
        [TestMethod]
        [TestCategory(Categories.CI)]
        public void MessageChanged_When_ButtonHovered_Wpf()
        {
            // Use the element creation service to create an instance of the button. There are much more details about this process in the next sections.
            var button = App.ElementCreateService.CreateByName<Button>("E Button");

            button.Hover();

            var label = App.ElementCreateService.CreateByAutomationId<Label>("ResultLabelId");
            Assert.AreEqual("ebuttonHovered", label.InnerText);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]

        // 2.4. As mentioned above you can override the app lifecycle for a particular test. The global lifecycle for all tests in the class is to reuse the app instance.
        // Only for this particular test, BELLATRIX opens it and restarts it only on fail.
        public void MessageChanged_When_ButtonClicked_Wpf()
        {
            var button = App.ElementCreateService.CreateByName<Button>("E Button");

            button.Click();

            var label = App.ElementCreateService.CreateByAutomationId<Label>("ResultLabelId");
            Assert.AreEqual("ebuttonClicked", label.InnerText);
        }
    }
}