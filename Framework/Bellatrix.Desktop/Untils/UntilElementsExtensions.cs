﻿// <copyright file="UntilElementsExtensions.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Desktop.Untils;

namespace Bellatrix.Desktop
{
    public static class UntilElementsExtensions
    {
        public static TElementType ToExists<TElementType>(this TElementType element, int? timeoutInterval = null, int? sleepInterval = null)
            where TElementType : Element
        {
            var until = new UntilExist(timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }

        public static TElementType ToNotExists<TElementType>(this TElementType element, int? timeoutInterval = null, int? sleepInterval = null)
           where TElementType : Element
        {
            var until = new UntilNotExist(timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }

        public static TElementType ToBeVisible<TElementType>(this TElementType element, int? timeoutInterval = null, int? sleepInterval = null)
          where TElementType : Element
        {
            var until = new UntilBeVisible(timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }

        public static TElementType ToNotBeVisible<TElementType>(this TElementType element, int? timeoutInterval = null, int? sleepInterval = null)
         where TElementType : Element
        {
            var until = new UntilNotBeVisible(timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }

        public static TElementType ToBeClickable<TElementType>(this TElementType element, int? timeoutInterval = null, int? sleepInterval = null)
         where TElementType : Element
        {
            var until = new UntilBeClickable(timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }

        public static TElementType ToHasContent<TElementType>(this TElementType element, int? timeoutInterval = null, int? sleepInterval = null)
         where TElementType : Element
        {
            var until = new UntilHaveContent(timeoutInterval, sleepInterval);
            element.EnsureState(until);
            return element;
        }
    }
}
