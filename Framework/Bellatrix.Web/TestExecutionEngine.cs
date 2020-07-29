﻿// <copyright file="TestExecutionEngine.cs" company="Automate The Planet Ltd.">
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
using System;
using Bellatrix.Trace;
using Bellatrix.Web.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Bellatrix.Web
{
    public class TestExecutionEngine
    {
        private IWebDriver _wrappedDriver;
        private IServicesCollection _childContainer;

        public void StartBrowser(BrowserConfiguration browserConfiguration, IServicesCollection childContainer)
        {
            try
            {
                _childContainer = childContainer;
                var wrappedWebDriver = WrappedWebDriverCreateService.Create(browserConfiguration);

                childContainer.RegisterInstance<IWebDriver>(wrappedWebDriver);
                childContainer.RegisterInstance(((RemoteWebDriver)wrappedWebDriver).SessionId.ToString(), "SessionId");
                childContainer.RegisterInstance(ConfigurationService.Instance.GetWebSettings().Remote.GridUri.AbsoluteUri, "GridUri");

                childContainer.RegisterInstance(new BrowserService(wrappedWebDriver));
                childContainer.RegisterInstance(new CookiesService(wrappedWebDriver));
                childContainer.RegisterInstance(new DialogService(wrappedWebDriver));
                childContainer.RegisterInstance(new JavaScriptService(wrappedWebDriver));
                childContainer.RegisterInstance(new InteractionsService(wrappedWebDriver));
                childContainer.RegisterInstance(new NavigationService(wrappedWebDriver));
                childContainer.RegisterInstance(new ElementCreateService());
                _wrappedDriver = childContainer.Resolve<IWebDriver>();
                childContainer.RegisterInstance<IWebDriverElementFinderService>(new NativeElementFinderService(wrappedWebDriver));
                childContainer.RegisterNull<int?>();
                childContainer.RegisterNull<IWebElement>();
                IsBrowserStartedCorrectly = true;
            }
            catch
            {
                IsBrowserStartedCorrectly = false;
                throw;
            }
        }

        public bool IsBrowserStartedCorrectly { get; set; }

        public void Dispose(IServicesCollection container)
        {
            var webDriver = container.Resolve<IWebDriver>();
            DisposeDriverService.Dispose(webDriver, container);
        }

        public void DisposeAll()
        {
            foreach (var childContainer in ServicesCollection.Current.GetChildServicesCollections())
            {
                var driver = childContainer.Resolve<IWebDriver>();
                DisposeDriverService.Dispose(driver, childContainer);
            }
        }
    }
}