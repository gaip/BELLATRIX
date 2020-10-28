﻿// <copyright file="CartPage.cs" company="Automate The Planet Ltd.">
// Copyright 2019 Automate The Planet Ltd.
// Licensed under the Royalty-free End-user License Agreement, Version 1.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://bellatrix.solutions/licensing-royalty-free/
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System;
using System.Linq;
using Bellatrix.Web;

namespace Bellatrix.SpecFlow.Web.Tests
{
    public partial class CartPage : AssertedNavigatablePage
    {
        private const string CouponSuccessfullyAdded = @"Coupon code applied successfully.";

        public override string Url => "http://demos.bellatrix.solutions/cart/";

        public void ApplyCoupon(string coupon)
        {
            CouponCode.SetText(coupon);
            ApplyCouponButton.Click();
            MessageAlert.ToHasContent().ToBeVisible().WaitToBe();

            MessageAlert.EnsureInnerTextIs(CouponSuccessfullyAdded);
        }

        public void UpdateProductQuantity(int productNumber, int newQuantity)
        {
            if (productNumber > QuantityBoxes.Count())
            {
                throw new ArgumentException("There are less added items in the cart. Please specify smaller product number.");
            }

            var browserService = new BrowserService();
            browserService.WaitUntilReady();
            QuantityBoxes[productNumber - 1].SetNumber(newQuantity);
            UpdateCart.Click();
            browserService.WaitUntilReady();
        }

        public void UpdateAllProductsQuantity(int newQuantity)
        {
            if (QuantityBoxes.Any())
            {
                throw new ArgumentException("There are no items to be updated.");
            }

            foreach (var currentQuantityBox in QuantityBoxes)
            {
                currentQuantityBox.SetNumber(0);
                currentQuantityBox.SetNumber(newQuantity);
            }

            UpdateCart.Click();
        }
    }
}