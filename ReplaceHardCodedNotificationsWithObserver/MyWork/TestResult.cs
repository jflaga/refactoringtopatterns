using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork
{
    public class TestResult
    {
        protected ITestListener fRunner;

        private List<TestFailure> fFailures;
        private List<TestFailure> fErrors;
        private int fRunTests;
        private bool fStop;

        private readonly object syncLock = new object();

        public TestResult(ITestListener runner)
            : this()
        {
            fRunner = runner;
        }

        public TestResult()
        {
            fFailures = new List<TestFailure>();
            fErrors = new List<TestFailure>();
            fRunTests = 0;
            fStop = false;
        }

        public virtual void AddError(Test test, Exception ex)
        {
            lock (syncLock)
            {
                fErrors.Add(new TestFailure(test, ex));
                if (fRunner != null)
                    fRunner.AddError(this, test, ex);
            }
        }

        public virtual void AddFailure(Test test, Exception ex)
        {
            lock (syncLock)
            {
                fFailures.Add(new TestFailure(test, ex));
                if (fRunner != null)
                    fRunner.AddFailure(this, test, ex);
            }
        }

        public virtual void EndTest(Test test)
        {
            lock (syncLock)
            {
                if (fRunner != null)
                    fRunner.EndTest(this, test);
            }
        }

        public virtual void StartTest(Test test)
        {
            lock (syncLock)
            {
                if (fRunner != null)
                    fRunner.StartTest(this, test);
            }
        }
    }
}
