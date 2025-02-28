using System;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork.TextUI
{
    public class TestRunner : ITestListener
    {
        protected TestResult CreateTestResult()
        {
            return new TestResult(this);
        }

        protected void DoRun(Test suite, bool wait)
        {
            // ...
            TestResult result = CreateTestResult();
        }

        public void AddError(TestResult textTestResult, Test test, Exception ex)
        {
            System.Console.WriteLine("E");
        }

        public void AddFailure(TestResult textTestResult, Test test, Exception ex)
        {
            System.Console.WriteLine("F");
        }

        public void StartTest(TestResult textTestResult, Test test)
        {
            System.Console.WriteLine("Test Starting...");
        }

        public void EndTest(TestResult textTestResult, Test test)
        {
            // do nothing
        }
    }
}