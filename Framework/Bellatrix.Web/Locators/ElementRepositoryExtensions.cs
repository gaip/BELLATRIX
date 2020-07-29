﻿// <copyright file="ElementRepositoryExtensions.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Web.Locators;

namespace Bellatrix.Web
{
    public static class ElementRepositoryExtensions
    {
        public static TElement CreateByIdEndingWith<TElement>(this ElementCreateService repository, string idEnding, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByIdEndingWith>(new ByIdEndingWith(idEnding), shouldCacheElement);

        public static TElement CreateByTag<TElement>(this ElementCreateService repository, string tag, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByTag>(new ByTag(tag), shouldCacheElement);

        public static TElement CreateById<TElement>(this ElementCreateService repository, string id, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ById>(new ById(id), shouldCacheElement);

        public static TElement CreateByIdContaining<TElement>(this ElementCreateService repository, string idContaining, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByIdContaining>(new ByIdContaining(idContaining), shouldCacheElement);

        public static TElement CreateByValueContaining<TElement>(this ElementCreateService repository, string valueEnding, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByValueContaining>(new ByValueContaining(valueEnding), shouldCacheElement);

        public static TElement CreateByXpath<TElement>(this ElementCreateService repository, string xpath, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByXpath>(new ByXpath(xpath), shouldCacheElement);

        public static TElement CreateByLinkText<TElement>(this ElementCreateService repository, string linkText, bool shouldCacheElement = false)
          where TElement : Element => repository.Create<TElement, ByLinkText>(new ByLinkText(linkText), shouldCacheElement);

        public static TElement CreateByLinkTextContaining<TElement>(this ElementCreateService repository, string linkTextContaining, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByLinkTextContains>(new ByLinkTextContains(linkTextContaining), shouldCacheElement);

        public static TElement CreateByClass<TElement>(this ElementCreateService repository, string cssClass, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByClass>(new ByClass(cssClass), shouldCacheElement);

        public static TElement CreateByCss<TElement>(this ElementCreateService repository, string cssClass, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByCss>(new ByCss(cssClass), shouldCacheElement);

        public static TElement CreateByClassContaining<TElement>(this ElementCreateService repository, string cssClassContaining, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByClassContaining>(new ByClassContaining(cssClassContaining), shouldCacheElement);

        public static TElement CreateByInnerTextContaining<TElement>(this ElementCreateService repository, string innerText, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByInnerTextContains>(new ByInnerTextContains(innerText), shouldCacheElement);

        public static TElement CreateByNameEndingWith<TElement>(this ElementCreateService repository, string name, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByNameEndingWith>(new ByNameEndingWith(name), shouldCacheElement);

        public static TElement CreateByAttributesContaining<TElement>(this ElementCreateService repository, string attributeName, string value, bool shouldCacheElement = false)
            where TElement : Element => repository.Create<TElement, ByAttributeContaining>(Find.By.AttributeContaining(attributeName, value), shouldCacheElement);

        public static ElementsList<TElement> CreateAllByIdEndingWith<TElement>(this ElementCreateService repository, string idEnding, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByIdEndingWith(idEnding), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByTag<TElement>(this ElementCreateService repository, string tag, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByTag(tag), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllById<TElement>(this ElementCreateService repository, string id, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ById(id), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByIdContaining<TElement>(this ElementCreateService repository, string idContaining, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByIdContaining(idContaining), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByValueContaining<TElement>(this ElementCreateService repository, string valueEnding, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByValueContaining(valueEnding), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByXpath<TElement>(this ElementCreateService repository, string xpath, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByXpath(xpath), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByLinkText<TElement>(this ElementCreateService repository, string linkText, bool shouldCacheFoundElements = false)
          where TElement : Element => new ElementsList<TElement>(new ByLinkText(linkText), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByLinkTextContaining<TElement>(this ElementCreateService repository, string linkTextContaining, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByLinkTextContains(linkTextContaining), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByClass<TElement>(this ElementCreateService repository, string cssClass, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByClass(cssClass), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByCss<TElement>(this ElementCreateService repository, string cssClass, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByCss(cssClass), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByClassContaining<TElement>(this ElementCreateService repository, string classContaining, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByClassContaining(classContaining), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByInnerTextContaining<TElement>(this ElementCreateService repository, string innerText, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByInnerTextContains(innerText), null, shouldCacheFoundElements);

        public static ElementsList<TElement> CreateAllByNameEndingWith<TElement>(this ElementCreateService repository, string name, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(new ByNameEndingWith(name), null);

        public static ElementsList<TElement> CreateAllByAttributesContaining<TElement>(this ElementCreateService repository, string attributeName, string value, bool shouldCacheFoundElements = false)
            where TElement : Element => new ElementsList<TElement>(Find.By.AttributeContaining(attributeName, value), null, shouldCacheFoundElements);
    }
}