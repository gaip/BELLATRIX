﻿// <copyright file="LayoutTwoElementsActionTwoValuesEventArgs.cs" company="Automate The Planet Ltd.">
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
namespace Bellatrix.Layout
{
    public class LayoutTwoElementsActionTwoValuesEventArgs
    {
        public LayoutTwoElementsActionTwoValuesEventArgs(ILayoutElement element, ILayoutElement secondElement)
        {
            Element = element;
            SecondElement = secondElement;
        }

        public LayoutTwoElementsActionTwoValuesEventArgs(ILayoutElement element, ILayoutElement secondElement, string actionValue, string secondActionValue)
            : this(element, secondElement)
        {
            ActionValue = actionValue;
            SecondActionValue = secondActionValue;
        }

        public LayoutTwoElementsActionTwoValuesEventArgs(ILayoutElement element, ILayoutElement secondElement, double actionValue, double secondActionValue)
            : this(element, secondElement)
        {
            ActionValue = actionValue.ToString();
            SecondActionValue = secondActionValue.ToString();
        }

        public ILayoutElement Element { get; }
        public ILayoutElement SecondElement { get; }
        public string ActionValue { get; }
        public string SecondActionValue { get; }
    }
}
