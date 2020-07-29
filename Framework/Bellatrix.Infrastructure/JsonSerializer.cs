﻿// <copyright file="JsonSerializer.cs" company="Automate The Planet Ltd.">
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

using System.Text.Json;

namespace Bellatrix.Infrastructure
{
    public class JsonSerializer
    {
        public string Serialize<TEntity>(TEntity entityToBeSerialized)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true,
            };

            return System.Text.Json.JsonSerializer.Serialize(entityToBeSerialized, options);
        }

        public TEntity Deserialize<TEntity>(string content)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                IgnoreNullValues = true,
            };

            return System.Text.Json.JsonSerializer.Deserialize<TEntity>(content, options);
        }
    }
}