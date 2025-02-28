using System;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork
{
    public interface ITestListener
    {
        void AddError(TestResult textTestResult, Test test, Exception ex);
        void AddFailure(TestResult textTestResult, Test test, Exception ex);
        void StartTest(TestResult textTestResult, Test test);
        void EndTest(TestResult textTestResult, Test test);
    }
}