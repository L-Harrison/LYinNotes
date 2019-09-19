using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadSummary.PLinqUnity
{
    public class PLinqUnity
    {
        public void DO()
        {
            #region PLinq
            var nums = Enumerable.Range(0, 100);
            var query = from m in nums.AsParallel().AsOrdered()
                        select new
                        {
                            thread = System.Threading.Thread.CurrentThread.ManagedThreadId,
                            num = m
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            #endregion}
        }
    }
}
