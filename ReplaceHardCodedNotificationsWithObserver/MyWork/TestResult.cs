using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork
{
    public class TestResult
    {
        private List<TestFailure> fFailures;
        private List<TestFailure> fErrors;
        private int fRunTests;
        private bool fStop;

        private readonly object syncLock = new object();

        private IList<ITestListener> observers = new List<ITestListener>();

        public TestResult()
        {
            fFailures = new List<TestFailure>();
            fErrors = new List<TestFailure>();
            fRunTests = 0;
            fStop = false;
        }

        public void AddObserver(ITestListener testListener)
        {
            observers.Add(testListener);
        }

        public virtual void AddError(Test test, Exception ex)
        {
            lock (syncLock)
            {
                fErrors.Add(new TestFailure(test, ex));
                foreach (var observer in observers)
                {
                    observer.AddError(this, test, ex);
                }
            }
        }

        public virtual void AddFailure(Test test, Exception ex)
        {
            lock (syncLock)
            {
                fFailures.Add(new TestFailure(test, ex));
                foreach (var observer in observers)
                {
                    observer.AddFailure(this, test, ex);
                }
            }
        }

        public virtual void EndTest(Test test)
        {
            lock (syncLock)
            {
                foreach (var observer in observers)
                {
                    observer.EndTest(this, test);
                }
            }
        }

        public virtual void StartTest(Test test)
        {
            lock (syncLock)
            {
                foreach (var observer in observers)
                {
                    observer.StartTest(this, test);
                }
            }
        }
    }
}
