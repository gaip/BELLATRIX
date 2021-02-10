﻿// <copyright file="AppRegistrationExtensions.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
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
using System.Collections.Generic;
using Bellatrix.Application;
using Bellatrix.Layout;
using Bellatrix.Web.Controls.Advanced.ControlDataHandlers;
using Bellatrix.Web.Controls.EventHandlers;
using Bellatrix.Web.EventHandlers.DynamicTestCases;
using Bellatrix.Web.Extensions.Controls.Controls.EventHandlers;

namespace Bellatrix.Web
{
    public static class AppRegistrationExtensions
    {
        public static BaseApp UseControlDataHandlers(this BaseApp baseApp)
        {
            // Editable Control DataHandlers - need to be registered both as readonly and editable
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Date>, DateControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<DateTimeLocal>, DateTimeLocalControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Email>, EmailControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Month>, MonthControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Password>, PasswordControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Phone>, PhoneControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Range>, RangeControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Search>, SearchControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Time>, TimeControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Url>, UrlControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Week>, WeekControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<CheckBox>, CheckBoxControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<RadioButton>, RadioButtonControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<Select>, SelectControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<TextArea>, TextAreaControlDataHandler>();
            ServicesCollection.Current.RegisterType<IEditableControlDataHandler<TextField>, TextFieldControlDataHandler>();

            // Readonly Control DataHandlers - need to be registered only as readonly
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Number>, NumberControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Output>, OutputControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Anchor>, AnchorControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Button>, ButtonControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Div>, DivControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Image>, ImageControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Label>, LabelControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Reset>, ResetControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Span>, SpanControlDataHandler>();
            ServicesCollection.Current.RegisterType<IReadonlyControlDataHandler<Color>, ColorControlDataHandler>();
            return baseApp;
        }

        public static BaseApp UseValidateExtensionsBddLogging(this BaseApp baseApp)
        {
            var bddLoggingValidateExtensions = new BDDLoggingValidateExtensionsService();
            bddLoggingValidateExtensions.SubscribeToAll();

            return baseApp;
        }

        public static BaseApp UseValidateExtensionsDynamicTestCases(this BaseApp baseApp)
        {
            var dynamicTestCasesValidateExtensions = new DynamicTestCasesValidateExtensionsEventHandlers();
            dynamicTestCasesValidateExtensions.SubscribeToAll();

            return baseApp;
        }

        public static BaseApp UseValidateExtensionsBugReporting(this BaseApp baseApp)
        {
            var bugReportingValidateExtensions = new BugReportingValidateExtensionsEventHandlers();
            bugReportingValidateExtensions.SubscribeToAll();

            return baseApp;
        }

        public static BaseApp UseLayoutAssertionExtensionsBddLogging(this BaseApp baseApp)
        {
            var bddLoggingLayoutAssertionsExtensions = new BDDLoggingAssertionExtensionsService();
            bddLoggingLayoutAssertionsExtensions.SubscribeToAll();

            return baseApp;
        }

        public static BaseApp UseLayoutAssertionExtensionsDynamicTestCases(this BaseApp baseApp)
        {
            var dynamicTestCasesLayoutAssertionsExtensions = new DynamicTestCasesAssertionExtensions();
            dynamicTestCasesLayoutAssertionsExtensions.SubscribeToAll();

            return baseApp;
        }

        public static BaseApp UseLayoutAssertionExtensionsBugReporting(this BaseApp baseApp)
        {
            var bugReportingLayoutAssertionsExtensions = new BugReportingAssertionExtensions();
            bugReportingLayoutAssertionsExtensions.SubscribeToAll();

            return baseApp;
        }

        public static BaseApp UseElementsBddLogging(this BaseApp baseApp)
        {
            var elementEventHandlers = new List<ElementEventHandlers>()
                                       {
                                           new BDDLoggingTextFieldEventHandlers(),
                                           new BDDLoggingDateEventHandlers(),
                                           new BDDLoggingColorEventHandlers(),
                                           new BDDLoggingCheckboxEventHandlers(),
                                           new BDDLoggingDateTimeLocalEventHandlers(),
                                           new BDDLoggingElementEventHandlers(),
                                           new BDDLoggingEmailEventHandlers(),
                                           new BDDLoggingInputFileEventHandlers(),
                                           new BDDLoggingMonthEventHandlers(),
                                           new BDDLoggingNumberEventHandlers(),
                                           new BDDLoggingPasswordEventHandlers(),
                                           new BDDLoggingPhoneEventHandlers(),
                                           new BDDLoggingRangeEventHandlers(),
                                           new BDDLoggingSearchEventHandlers(),
                                           new BDDLoggingSelectEventHandlers(),
                                           new BDDLoggingTextAreaEventHandlers(),
                                           new BDDLoggingTimeEventHandlers(),
                                           new BDDLoggingUrlEventHandlers(),
                                           new BDDLoggingWeekEventHandlers(),
                                       };
            foreach (var elementEventHandler in elementEventHandlers)
            {
                elementEventHandler.SubscribeToAll();
            }

            return baseApp;
        }

        public static BaseApp UseDynamicTestCases(this BaseApp baseApp)
        {
            var elementEventHandlers = new List<ElementEventHandlers>()
                                       {
                                           new DynamicTestCasesTextFieldEventHandlers(),
                                           new DynamicTestCasesDateEventHandlers(),
                                           new DynamicTestCasesColorEventHandlers(),
                                           new DynamicTestCasesCheckboxEventHandlers(),
                                           new DynamicTestCasesDateTimeLocalEventHandlers(),
                                           new DynamicTestCasesElementEventHandlers(),
                                           new DynamicTestCasesEmailEventHandlers(),
                                           new DynamicTestCasesInputFileEventHandlers(),
                                           new DynamicTestCasesMonthEventHandlers(),
                                           new DynamicTestCasesNumberEventHandlers(),
                                           new DynamicTestCasesPasswordEventHandlers(),
                                           new DynamicTestCasesPhoneEventHandlers(),
                                           new DynamicTestCasesRangeEventHandlers(),
                                           new DynamicTestCasesSearchEventHandlers(),
                                           new DynamicTestCasesSelectEventHandlers(),
                                           new DynamicTestCasesTextAreaEventHandlers(),
                                           new DynamicTestCasesTimeEventHandlers(),
                                           new DynamicTestCasesUrlEventHandlers(),
                                           new DynamicTestCasesWeekEventHandlers(),
                                       };
            foreach (var elementEventHandler in elementEventHandlers)
            {
                elementEventHandler.SubscribeToAll();
            }

            return baseApp;
        }

        public static BaseApp UseBugReporting(this BaseApp baseApp)
        {
            var elementEventHandlers = new List<ElementEventHandlers>()
                                       {
                                           new BugReportingTextFieldEventHandlers(),
                                           new BugReportingDateEventHandlers(),
                                           new BugReportingColorEventHandlers(),
                                           new BugReportingCheckboxEventHandlers(),
                                           new BugReportingDateTimeLocalEventHandlers(),
                                           new BugReportingElementEventHandlers(),
                                           new BugReportingEmailEventHandlers(),
                                           new BugReportingInputFileEventHandlers(),
                                           new BugReportingNumberEventHandlers(),
                                           new BugReportingPasswordEventHandlers(),
                                           new BugReportingPhoneEventHandlers(),
                                           new BugReportingRangeEventHandlers(),
                                           new BugReportingSearchEventHandlers(),
                                           new BugReportingSelectEventHandlers(),
                                           new BugReportingTextAreaEventHandlers(),
                                           new BugReportingTimeEventHandlers(),
                                           new BugReportingUrlEventHandlers(),
                                           new BugReportingWeekEventHandlers(),
                                       };
            foreach (var elementEventHandler in elementEventHandlers)
            {
                elementEventHandler.SubscribeToAll();
            }

            return baseApp;
        }

        public static BaseApp UseHighlightElements(this BaseApp baseApp)
        {
            if (ConfigurationService.GetSection<WebSettings>() == null)
            {
                throw new ArgumentException("Could not load web settings section from testFrameworkSettings.json");
            }

            if (ConfigurationService.GetSection<WebSettings>().ShouldHighlightElements)
            {
                var highlightElementEventHandler = new HighlightElementEventHandlers();
                highlightElementEventHandler.SubscribeToAll();
            }

            return baseApp;
        }
    }
}