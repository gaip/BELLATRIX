﻿// <copyright file="VideoRecorderOutputProvider.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using System.Linq;
using Bellatrix.TestExecutionExtensions.Video.Contracts;

namespace Bellatrix.VideoRecording.FFmpeg
{
    public class VideoRecorderOutputProvider : IVideoRecorderOutputProvider
    {
        public string GetOutputFolder()
        {
            var outputDir = ConfigurationService.Instance.GetVideoSettings().FilePath;
            if (outputDir.StartsWith("ApplicationData", StringComparison.Ordinal))
            {
                var folders = outputDir.Split('\\').ToList();
                folders.RemoveAt(0);
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string newFolderToBeCreated = Path.GetDirectoryName(appData);
                foreach (var currentFolder in folders)
                {
                    newFolderToBeCreated = Path.Combine(newFolderToBeCreated ?? throw new InvalidOperationException(), currentFolder);
                }

                outputDir = newFolderToBeCreated;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir ?? throw new InvalidOperationException());
            }

            return outputDir;
        }

        public string GetUniqueFileName(string testName) => string.Concat(testName, Guid.NewGuid().ToString());
    }
}
