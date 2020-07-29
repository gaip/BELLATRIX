﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Web.GettingStarted
{
    [TestClass]
    [Browser(BrowserType.Chrome, BrowserBehavior.RestartEveryTime)]
    [Browser(OS.OSX, BrowserType.Safari, BrowserBehavior.RestartEveryTime)]
    public class EnsureAssertions : WebTest
    {
        [TestMethod]
        [TestCategory(Categories.CI)]
        public void AssertEnsureCartPageFields()
        {
            // Instead of going to the main page and clicking the Add to Cart buttons we can directly add a product to the cart following the below link.
            App.NavigationService.Navigate("http://demos.bellatrix.solutions/?add-to-cart=26");

            // Instead of clicking the view cart button we can directly navigate to the cart.
            App.NavigationService.Navigate("http://demos.bellatrix.solutions/cart/");

            TextField couponCodeTextField = App.ElementCreateService.CreateById<TextField>("coupon_code");

            // 1. We can assert the default text in the coupon text fiend through the BELLATRIX element Placeholder property.
            // The different BELLATRIX web elements classes contain lots of these properties which are a representation of the most important HTML element attributes.
            //
            // The biggest drawback of using vanilla assertions is that the messages displayed on failure are not meaningful at all.
            // If the bellow assertion fails the following message is displayed: "Message: Assert.AreEqual failed. Expected:<Coupon code >. Actual:<Coupon code>. "
            // You can guess what happened, but you do not have information which element failed and on which page.
            //
            // If we use the Ensure extension methods, BELLATRIX waits some time for the condition to pass. After this period if it is not successful, a beatified
            // meaningful exception message is displayed:
            // "The control's placeholder should be 'Coupon code ' but was 'Coupon code'. The test failed on URL: http://demos.bellatrix.solutions/cart/"
            couponCodeTextField.EnsurePlaceholderIs("Coupon code");
            ////Assert.AreEqual("Coupon code ", couponCodeTextField.Placeholder);

            Button applyCouponButton = App.ElementCreateService.CreateByValueContaining<Button>("Apply coupon");

            // 2. Assert that the apply coupon button exists and is visible on the page.
            // On fail the following message is displayed: "Message: Assert.IsTrue failed."
            // Cannot learn much about what happened.
            //
            // Now if we use the EnsureIsVisible method and the check does not succeed the following error message is displayed:
            // "The control should be visible but was NOT. The test failed on URL: http://demos.bellatrix.solutions/cart/"
            // To all exception messages, the current URL is displayed, which improves the troubleshooting.

            ////Assert.IsTrue(applyCouponButton.IsPresent);
            ////Assert.IsTrue(applyCouponButton.IsVisible);
            applyCouponButton.EnsureIsVisible();

            Div messageAlert = App.ElementCreateService.CreateByClassContaining<Div>("woocommerce-message");

            // 3. Since there are no validation errors, verify that the message div is not visible.
            messageAlert.EnsureIsNotVisible();
            ////Assert.IsFalse(messageAlert.IsVisible);

            Button updateCart = App.ElementCreateService.CreateByValueContaining<Button>("Update cart");

            // 4. No changes are made to the added products so the update cart button should be disabled.
            updateCart.EnsureIsDisabled();
            ////Assert.IsTrue(updateCart.IsDisabled);

            Span totalSpan = App.ElementCreateService.CreateByXpath<Span>("//*[@class='order-total']//span");

            // 5. Check the total price contained in the order-total span HTML element.
            // By default, all Ensure methods have 5 seconds timeout. However, you can specify a custom timeout and sleep interval (period for checking again)
            totalSpan.EnsureInnerTextIs("120.00€", timeout: 30, sleepInterval: 2);
            ////Assert.AreEqual("120.00€", totalSpan.InnerText);

            // 6. BELLATRIX provides you with a full BDD logging support for ensure assertions and gives you a way to hook your logic in multiple places.

            // 7. You can execute multiple ensure assertions failing only once viewing all results.
            Bellatrix.Assertions.Assert.Multiple(
                () => totalSpan.EnsureInnerTextIs("120.00€", timeout: 30, sleepInterval: 2),
                () => updateCart.EnsureIsDisabled(),
                () => messageAlert.EnsureIsNotVisible(),
                () => Assert.AreEqual("120.00€", totalSpan.InnerText));
        }
    }
}