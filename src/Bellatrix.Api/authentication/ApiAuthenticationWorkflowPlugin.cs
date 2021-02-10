﻿// <copyright file="ApiAuthenticationWorkflowPlugin.cs" company="Automate The Planet Ltd.">
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
using System.Reflection;
using Bellatrix.TestWorkflowPlugins;
using RestSharp.Authenticators;

namespace Bellatrix.TestExecutionExtensions.Api
{
    public class ApiAuthenticationWorkflowPlugin : TestWorkflowPlugin
    {
        protected override void PreTestsArrange(object sender, TestWorkflowPluginEventArgs e)
        {
            var authenticator = GetAuthenticatorByType(e.TestClassType);
            if (authenticator != null)
            {
                e.Container.RegisterInstance(authenticator);
            }
        }

        private IAuthenticator GetAuthenticatorByType(Type currentType)
        {
            if (currentType == null)
            {
                throw new ArgumentNullException();
            }

            var authenticationClassAttribute = currentType.GetCustomAttribute<AuthenticationStrategyAttribute>(true);
            return authenticationClassAttribute?.GetAuthenticator();
        }
    }
}