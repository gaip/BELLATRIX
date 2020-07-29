﻿// <copyright file="ByValueContainingLoadTestLocator.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System.Linq;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace Bellatrix.LoadTesting.Model.Locators
{
    public class ByValueContainingLoadTestLocator : LoadTestLocator
    {
        public override string LocatorType => "Bellatrix.Web.ByValueContaining";

        public override LoadTestElement LocateElement(HtmlDocument htmlDoc, string locatorValue)
        {
            var htmlNodes = htmlDoc.DocumentNode.QuerySelectorAll($"[value*='{locatorValue}']").AsEnumerable();
            ThrowNewNotFoundElementException(htmlNodes, locatorValue);

            return new LoadTestElement(htmlNodes.FirstOrDefault(), LocatorType, locatorValue);
        }
    }
}
