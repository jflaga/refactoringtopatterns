using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork
{
    public class TestResult
    {
        public virtual void AddFailure(Test test, Exception ex)
        {
            // 
        }

        public virtual void AddError(Test test, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
