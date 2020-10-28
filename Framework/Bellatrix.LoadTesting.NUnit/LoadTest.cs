﻿// <copyright file="LoadTest.cs" company="Automate The Planet Ltd.">
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

namespace Bellatrix.LoadTesting
{
    public abstract class LoadTest : NUnitBaseTest
    {
        private static readonly Lazy<LoadTestEngine> _loadTestEngine;

        static LoadTest()
        {
            _loadTestEngine = new Lazy<LoadTestEngine>();
            App = new App();
        }

        protected static LoadTestEngine LoadTestEngine => _loadTestEngine.Value;

        public static App App { get; }
    }
}