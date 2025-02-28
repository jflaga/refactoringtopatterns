using ReplaceHardCodedNotificationsWithObserver.MyWork.TextUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork.UI
{
    public class TestRunner : Frame, ITestListener // TestRunner for AWT
    {
        private TestResult fTestResult;
        private TestSuite testSuite;

        // ...

        protected TestResult CreateTestResult()
        {
            var testResult = new TestResult();
            testResult.AddObserver(this);
            return testResult;
        }

        private readonly object syncLock = new object();
        public void RunSuite()
        {
            lock (syncLock)
            {
                // ...
                fTestResult = CreateTestResult();
                testSuite.Run(fTestResult);
            }
        }

        public void AddFailure(TestResult result, Test test, Exception ex)
        {
            // ...
            // display the failure in a graphical AWT window
        }

        public void EndTest(TestResult uITestResult, Test test)
        {
            //
        }

        public void AddError(TestResult textTestResult, Test test, Exception ex)
        {
            //
        }

        public void StartTest(TestResult textTestResult, Test test)
        {
            //
        }
    }
}
