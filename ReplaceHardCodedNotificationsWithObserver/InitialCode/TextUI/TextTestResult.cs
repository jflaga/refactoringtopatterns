using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.InitialCode.TextUI
{
    public class TextTestResult : TestResult
    {
        private readonly object syncLock = new object();

        public override void AddError(Test test, Exception ex)
        {
            lock (syncLock)
            {
                base.AddError(test, ex);
                System.Console.WriteLine("E");
            }
        }

        public override void AddFailure(Test test, Exception ex)
        {
            lock (syncLock)
            {
                base.AddFailure(test, ex);
                System.Console.WriteLine("F");
            }
        }
    }
}
