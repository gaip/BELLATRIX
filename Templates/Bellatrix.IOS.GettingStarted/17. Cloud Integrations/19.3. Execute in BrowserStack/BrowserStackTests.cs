﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Mobile.IOS.GettingStarted
{
    [TestClass]

    // 1. To execute BELLATRIX tests in BrowserStack cloud, you should use the BrowserStack attribute instead of IOS.
    // BrowserStack has the same parameters as IOS but adds to additional ones-
    // device name, captureVideo, captureNetworkLogs, consoleLogType, build and debug. The last five are optional and have default values.
    // As with the IOS attribute you can override the class behaviour on Test level.
    //
    // 2. You can find a dedicated section about SauceLabs in testFrameworkSettings file under the mobileSettings section.
    //     "browserStack": {
    //     "gridUri":  "http://hub-cloud.browserstack.com/wd/hub/",
    //     "user": "soioa1",
    //     "key":  "pnFG3Ky2yLZ5muB1p46P"
    // }
    //
    // There you can set the grid URL and credentials.
    [IOSBrowserStack("pngG38y26LZ5muB1p46P",
        "11.3",
        "iPhone 6",
        AppBehavior.RestartEveryTime,
        captureVideo: true,
        captureNetworkLogs: true,
        consoleLogType: BrowserStackConsoleLogType.Disable,
        debug: false,
        build: "CI Execution")]
    public class BrowserStackTests : IOSTest
    {
        [TestMethod]
        [Timeout(180000)]
        [Ignore]
        public void ButtonClicked_When_CallClickMethod()
        {
            var button = App.ElementCreateService.CreateByName<Button>("ComputeSumButton");

            button.Click();
        }

        // 2. As mentioned if you use the BrowserStack attribute on method level it overrides the class settings.
        [TestMethod]
        [Timeout(180000)]
        [Ignore]
        [IOSBrowserStack("pngG38y26LZ5muB1p46P",
            "11.3",
            "iPhone 6",
            AppBehavior.RestartOnFail,
            captureVideo: true,
            captureNetworkLogs: true,
            consoleLogType: BrowserStackConsoleLogType.Disable,
            debug: false,
            build: "CI Execution")]
        public void ButtonClicked_When_CallClickMethodSecond()
        {
            var button = App.ElementCreateService.CreateByName<Button>("ComputeSumButton");

            button.Click();
        }
    }
}