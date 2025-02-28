using System;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork
{
    internal class TestFailure
    {
        private Test test;
        private Exception ex;

        public TestFailure(Test test, Exception ex)
        {
            this.test = test;
            this.ex = ex;
        }
    }
}