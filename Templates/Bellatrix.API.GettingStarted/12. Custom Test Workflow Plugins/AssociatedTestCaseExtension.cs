﻿using System;
using System.Linq;
using System.Reflection;
using Bellatrix.TestWorkflowPlugins;

namespace Bellatrix.API.GettingStarted
{
    // 1. To create a custom test workflow plugin:
    // 1.1. Create a new class that derives from the 'TestExecutionExtension' base class.
    // 1.2. Then override some of the workflow's protected methods adding there your logic.
    // 1.3. Register the workflow plugin using the AddTestWorkflowPlugin method of the App service.
    public class AssociatedTestCaseExtension : TestWorkflowPlugin
    {
        // 2. You can override all mentioned test workflow method hooks in your custom handlers.
        // The method uses reflection to find out if the ManualTestCase attribute is set to the run test.
        // If the attribute is not set or is set more than once an exception is thrown.
        // The logic executes before the actual test run, during the PreTestInit phase.
        protected override void PreTestInit(object sender, TestWorkflowPluginEventArgs e)
        {
            base.PreTestInit(sender, e);
            ValidateManualTestCaseAttribute(e.TestMethodMemberInfo);
        }

        private void ValidateManualTestCaseAttribute(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException();
            }

            var methodBrowserAttributes = memberInfo.GetCustomAttributes<ManualTestCaseAttribute>(true).ToList();
            if (methodBrowserAttributes.Count == 0)
            {
                throw new ArgumentException("No manual test case is associated with the BELLATRIX test.");
            }
            else if (methodBrowserAttributes.Count > 1)
            {
                throw new ArgumentException("You cannot associate two manual test cases with a single BELLATRIX test.");
            }
            else if (methodBrowserAttributes.First().TestCaseId <= 0)
            {
                throw new ArgumentException("The associated manual test case ID cannot be <= 0.");
            }
        }
    }
}
