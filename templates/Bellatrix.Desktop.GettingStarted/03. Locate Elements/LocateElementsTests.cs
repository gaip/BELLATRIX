﻿using System;
using Bellatrix.Desktop.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Desktop.GettingStarted
{
    [TestClass]
    [App(Constants.WpfAppPath, Lifecycle.RestartEveryTime)]

    public class LocateElementsTests : DesktopTest
    {
        [TestMethod]
        [TestCategory(Categories.CI)]
        public void MessageChanged_When_ButtonHovered_Wpf()
        {
            // 1. There are different ways to locate elements in the app. To do it you use the element create service.
            // You need to know that BELLATRIX has a built-in complex mechanism for waiting for elements, so you do not need to worry about this anymore.
            // Keep in mind that when you use the Create methods, the element is not searched. All elements use lazy loading.
            // Which means that they are searched once you perform an action or assertion on them. By default on each new action, the element is searched again and be refreshed.
            var button = App.ElementCreateService.CreateByName<Button>("E Button");

            button.Hover();

            // 2. Because of the proxy element mechanism (we have a separate type of element instead of single WebDriver IWebElement interface) we have several benefits.
            // Each control (element type- ComboBox, TextField and so on) contains only the actions you can do with it, and the methods are named properly.
            // In vanilla WebDriver to type the text you call SendKeys method.
            // Also, we have some additional properties in the proxy web control such as- By. Now you can get the locator with which you element was found.
            Console.WriteLine(button.By.Value);

            // 3. You can access the WebDriver wrapped element through WrappedElement and the current WebDriver instance through- WrappedDriver
            Console.WriteLine(button.WrappedElement.Coordinates);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [App(Constants.WpfAppPath, Lifecycle.RestartOnFail)]
        public void MessageChanged_When_ButtonClicked_Wpf()
        {
            // 4. BELLATRIX extends the vanilla WebDriver selectors and give you additional ones.
            // Available create methods:
            //
            // CreateByTag   -->  App.ElementCreateService.CreateByTag<Button>("button");
            // Searches the element by its tag.
            //
            // CreateById   -->  App.ElementCreateService.CreateById<Button>("myId");
            // Searches the element by its ID.
            //
            // CreateByXpath   -->  App.ElementCreateService.CreateByXpath<Button>("//*[@title='Add to cart']");
            // Searches the element by XPath locator.
            //
            // CreateByClass   -->  App.ElementCreateService.CreateByClassContaining<Button>("ul.products");
            // Searches the element by its CSS classes.
            //
            // CreateByName   -->  App.ElementCreateService.CreateByName<Button>("products");
            // Searches the element by its name.
            //
            // CreateByAccessibilityId   -->  App.ElementCreateService.CreateByAccessibilityId<Button>("myCustomButton");
            // Searches the element by its accessibility ID.
            //
            // CreateByAutomationId   -->  App.ElementCreateService.CreateByAutomationId<Search>("search");
            // Searches the element by its automation ID.
            var button = App.ElementCreateService.CreateByName<Button>("E Button");

            button.Click();

            // 5. Sometimes we need to find more than one element. For example, in this test we want to locate all Add to Cart buttons.
            // To do it you can use the element create service CreateAll method.
            // Available create methods:
            //
            // CreateAllByTag   -->  App.ElementCreateService.CreateAllByTag<Button>("button");
            // Searches the elements by its tag.
            //
            // CreateAllById   -->  App.ElementCreateService.CreateAllById<Button>("myId");
            // Searches the elements by its ID.
            //
            // CreateAllByXpath   -->  App.ElementCreateService.CreateAllByXpath<Button>("//*[@title='Add to cart']");
            // Searches the elements by XPath locator.
            //
            // CreateAllByClass   -->  App.ElementCreateService.CreateAllByClassContaining<Button>("ul.products");
            // Searches the elements by its CSS classes.
            //
            // CreateAllByName   -->  App.ElementCreateService.CreateAllByName<Button>("products");
            // Searches the elements by its name.
            //
            // CreateAllByAccessibilityId   -->  App.ElementCreateService.CreateAllByAccessibilityId<Button>("myCustomButton");
            // Searches the elements by its accessibility ID.
            //
            // CreateAllByAutomationId   -->  App.ElementCreateService.CreateAllByAutomationId<Search>("search");
            // Searches the elements by its automation ID.
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        public void ReturnNestedElement_When_ElementContainsOneChildElement_Wpf()
        {
            // 6. Sometimes it is easier to locate one element and then find the next one that you need, inside it.
            // For example in this test the list box is located and then the button inside it.
            var comboBox = App.ElementCreateService.CreateByAutomationId<ComboBox>("listBoxEnabled");
            var comboBoxItem = comboBox.CreateByAutomationId<Button>("lb2");

            comboBoxItem.Hover();

            // Note: it is entirely legal to create a Button instead of TextField. BELLATRIX library does not care about the real type of the elements.
            // The proxy types are convenience wrappers so to say. Meaning they give you a better interface of predefined properties and methods to make your tests more readable.

            // Available create methods on element level:
            // CreateByTag   -->  element.CreateByTag<Button>("button");
            // Searches the element by its tag.
            //
            // CreateById   -->  element.CreateById<Button>("myId");
            // Searches the element by its ID.
            //
            // CreateByXpath   -->  element.CreateByXpath<Button>("//*[@title='Add to cart']");
            // Searches the element by XPath locator.
            //
            // CreateByClass   -->  element.CreateByClassContaining<Button>("ul.products");
            // Searches the element by its CSS classes.
            //
            // CreateByName   -->  element.CreateByName<Button>("products");
            // Searches the element by its name.
            //
            // CreateByAccessibilityId   -->  element.CreateByAccessibilityId<Button>("myCustomButton");
            // Searches the element by its accessibility ID.
            //
            // CreateByAutomationId   --> element.CreateByAutomationId<Search>("search");
            // Searches the element by its automation ID.
            //
            //
            // CreateAllByTag   -->  element.CreateAllByTag<Button>("button");
            // Searches the elements by its tag.
            //
            // CreateAllById   -->  element.CreateAllById<Button>("myId");
            // Searches the elements by its ID.
            //
            // CreateAllByXpath   -->  element.CreateAllByXpath<Button>("//*[@title='Add to cart']");
            // Searches the elements by XPath locator.
            //
            // CreateAllByClass   -->  element.CreateAllByClassContaining<Button>("ul.products");
            // Searches the elements by its CSS classes.
            //
            // CreateAllByName   -->  element.CreateAllByName<Button>("products");
            // Searches the elements by its name.
            //
            // CreateAllByAccessibilityId   -->  element.CreateAllByAccessibilityId<Button>("myCustomButton");
            // Searches the elements by its accessibility ID.
            //
            // CreateAllByAutomationId   -->  element.CreateAllByAutomationId<Search>("search");
            // Searches the elements by its automation ID.
        }
    }
}