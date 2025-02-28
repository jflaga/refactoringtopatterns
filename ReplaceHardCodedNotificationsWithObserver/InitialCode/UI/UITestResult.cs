using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.InitialCode.UI
{
    public class UITestResult : TestResult
    {
        private TestRunner fRunner;

        internal UITestResult(TestRunner runner)
        {
            fRunner = runner;
        }

        // See "C# version of java's synchronized keyword" - https://stackoverflow.com/questions/541194/c-sharp-version-of-javas-synchronized-keyword
        private readonly object syncLock = new object();
        public override void AddFailure(Test test, Exception ex)
        {
            lock (syncLock) {
                base.AddFailure(test, ex);
                fRunner.AddFailure(this, test, ex); // notification to TestRunner
            }
        }
    }
}
