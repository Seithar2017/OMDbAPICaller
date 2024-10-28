using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDbAPICaller.Presenters.Validators
{
    public static class NullCheckerExtensions
    {
        public static void CheckAndExecute<T>(this T value, Action action)
        {
            if (value != null)
            {
                action?.Invoke();
            }
        }
    }
}
