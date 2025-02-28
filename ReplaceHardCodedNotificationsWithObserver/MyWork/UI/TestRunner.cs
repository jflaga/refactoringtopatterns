using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork.UI
{
    public class TestRunner : Frame // TestRunner for AWT
    {
        private TestResult fTestResult;
        private TestSuite testSuite;

        // ...

        protected TestResult CreateTestResult()
        {
            return new UITestResult(this);
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
    }
}
