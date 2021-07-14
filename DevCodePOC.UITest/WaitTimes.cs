using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Utils;
namespace DevCodePOC.UITest
{
    public class WaitTimes : IWaitTimes
    {
        public TimeSpan WaitForTimeout { get; } = TimeSpan.FromSeconds(5);
        public TimeSpan WaitForHomePageTimeout { get; } = TimeSpan.FromSeconds(20);

        public TimeSpan GestureWaitTimeout { get; } = TimeSpan.FromSeconds(5);
        public TimeSpan GestureCompletionTimeout { get; } = TimeSpan.FromSeconds(5);
    }
}
