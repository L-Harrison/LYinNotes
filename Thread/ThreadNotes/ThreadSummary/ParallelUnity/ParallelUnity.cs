using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.ParallelUnity
{
   public class ParallelUnity
    {

        public static void DO()
        {
            object obj = new object();
            var sum = 0;
            Parallel.For(1, 100,()=> {
                return 0;
            },(current,loop,total) => {
                total += current;
                Console.WriteLine($"current:{current},total:{total}");
                return total;
            },total=> {
                Interlocked.Add(ref sum, total);
            });
            Console.WriteLine($"sum:{sum}");
        }
        public static void DO2()
        {
            #region parallel

            ConcurrentStack<int> vs = new ConcurrentStack<int>();
            //Parallel.For(0, 100,new ParallelOptions {
            //      MaxDegreeOfParallelism=7
            //}, (m,loop) => {
            //    //if (m==20)
            //    //{
            //    //    loop.Break();
            //    //    return;
            //    //}
            //    //System.Threading.Thread.Sleep(11111); 
            //    vs.Push(m);
            //});

            var totalSum = 0;
            Parallel.For<int>(0, 100, new ParallelOptions
            {
                MaxDegreeOfParallelism = 7
            }, () => { return 0; }, (current, loop, total) =>
            {
                total += (int)current;
                return total;
            }, total =>
            {
                Interlocked.Add(ref totalSum, total);
            });
            Console.WriteLine(totalSum);
            Console.WriteLine(string.Join(',', vs));
            #endregion
        }
    }
}
