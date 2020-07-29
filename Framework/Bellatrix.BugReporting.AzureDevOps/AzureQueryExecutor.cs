﻿// <copyright file="AzureQueryExecutor.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;

namespace Bellatrix.BugReporting.AzureDevOps
{
    public static class AzureQueryExecutor
    {
        private static readonly string _uri;
        private static readonly string _personalAccessToken;
        private static readonly string _project;

        static AzureQueryExecutor()
        {
            _uri = ConfigurationService.Instance.GetAzureDevOpsBugReportingSettings().Url;
            _personalAccessToken = ConfigurationService.Instance.GetAzureDevOpsBugReportingSettings().Token;
            _project = ConfigurationService.Instance.GetAzureDevOpsBugReportingSettings().ProjectName;
        }

        public static WorkItem CreateBug(string title, string stepsToReproduce, string description, List<string> filePathsToBeAttached = null)
        {
            var credentials = new VssBasicCredential(string.Empty, _personalAccessToken);

            JsonPatchDocument patchDocument = new JsonPatchDocument();

            patchDocument.Add(
                new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Title",
                    Value = title,
                });

            patchDocument.Add(
               new JsonPatchOperation()
               {
                   Operation = Operation.Add,
                   Path = "/fields/Microsoft.VSTS.TCM.SystemInfo",
                   Value = description,
               });

            patchDocument.Add(
                new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.TCM.ReproSteps",
                    Value = stepsToReproduce,
                });

            patchDocument.Add(
                new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.Common.Priority",
                    Value = ConfigurationService.Instance.GetAzureDevOpsBugReportingSettings().DefaultPriority,
                });

            patchDocument.Add(
                new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.Common.Severity",
                    Value = ConfigurationService.Instance.GetAzureDevOpsBugReportingSettings().DefaultSeverity,
                });

            try
            {
                using var httpClient = new WorkItemTrackingHttpClient(new Uri(_uri), credentials);
                var attachments = CreateAttachments(httpClient, filePathsToBeAttached);
                AddAttachmentRelationships(patchDocument, attachments);

                WorkItem result = httpClient.CreateWorkItemAsync(patchDocument, _project, "Bug").Result;
                return result;
            }
            catch
            {
                return null;
            }

            return null;
        }

        private static void AddAttachmentRelationships(JsonPatchDocument patchDocument, List<AttachmentReference> attachments)
        {
            if (attachments != null && attachments.Any())
            {
                foreach (var attachment in attachments)
                {
                    patchDocument.Add(new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/relations/-",
                        Value = new
                        {
                            rel = "AttachedFile",
                            url = attachment.Url,
                            attributes = new { comment = "Troubleshooting files" },
                        },
                    });
                }
            }
        }

        private static List<AttachmentReference> CreateAttachments(WorkItemTrackingHttpClient httpClient, List<string> filePathsToBeAttached)
        {
            var attachments = new List<AttachmentReference>();
            if (filePathsToBeAttached == null || !filePathsToBeAttached.Any())
            {
                return attachments;
            }

            foreach (var filePath in filePathsToBeAttached)
            {
                try
                {
                    using FileStream fileStream = File.OpenRead(filePath);
                    var attachment = httpClient.CreateAttachmentAsync(uploadStream: fileStream, project: _project, fileName: Path.GetFileName(filePath)).Result;
                    attachments.Add(attachment);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return attachments;
        }
    }
}
