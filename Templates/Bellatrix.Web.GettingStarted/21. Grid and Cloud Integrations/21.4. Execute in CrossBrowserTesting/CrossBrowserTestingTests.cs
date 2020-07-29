﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Web.GettingStarted
{
    [TestClass]

    // 1. To execute BELLATRIX tests in CrossBrowserTesting cloud, you should use the CrossBrowserTesting attribute instead of Browser.
    // CrossBrowserTesting has the same parameters as Browser but adds to additional ones-
    // browser version, platform, recordVideo, recordNetwork and build. The last three are optional and have default values.
    // As with the Browser attribute you can override the class behaviour on Test level.
    //
    // 2. You can find a dedicated section about SauceLabs in testFrameworkSettings file under the webSettings section.
    //     "crossBrowserTesting": {
    //     "pageLoadTimeout": "30",
    //     "scriptTimeout": "1",
    //     "artificialDelayBeforeAction": "0",
    //     "gridUri":  "http://hub.crossbrowsertesting.com:80/wd/hub",
    //     "user": "aangelov",
    //     "key":  "mySecretKey"
    // }
    //
    // There you can set the grid URL, credentials and set some additional timeouts.
    [CrossBrowserTesting(BrowserType.Chrome,
        "62",
        "Windows 10",
        BrowserBehavior.ReuseIfStarted,
        recordVideo: true,
        recordNetwork: true,
        build: "myUniqueBuildName")]
    public class CrossBrowserTesting : WebTest
    {
        [TestMethod]
        [Ignore]
        public void PromotionsPageOpened_When_PromotionsButtonClicked()
        {
            App.NavigationService.Navigate("http://demos.bellatrix.solutions/");

            var promotionsLink = App.ElementCreateService.CreateByLinkText<Anchor>("Promotions");

            promotionsLink.Click();
        }

        // 2. As mentioned if you use the CrossBrowserTesting attribute on method level it overrides the class settings.
        // As you can see with the CrossBrowserTesting attribute we can change the browser window size again.
        [TestMethod]
        [Ignore]
        [CrossBrowserTesting(BrowserType.Chrome, "62", "Windows 10", DesktopWindowSize._1280_1024, BrowserBehavior.ReuseIfStarted)]

        // [BrowserStack(BrowserType.Chrome, "62", "Windows 10", 1000, 500, BrowserBehavior.ReuseIfStarted)]
        // [BrowserStack(BrowserType.Chrome, "62", "Windows 10", MobileWindowSize._320_568, BrowserBehavior.ReuseIfStarted)]
        // [BrowserStack(BrowserType.Chrome, "62", "Windows 10", TabletWindowSize._600_1024, BrowserBehavior.ReuseIfStarted)]
        public void BlogPageOpened_When_PromotionsButtonClicked()
        {
            App.NavigationService.Navigate("http://demos.bellatrix.solutions/");

            var blogLink = App.ElementCreateService.CreateByLinkText<Anchor>("Blog");

            blogLink.Click();
        }
    }
}