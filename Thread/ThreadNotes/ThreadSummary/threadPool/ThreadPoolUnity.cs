using System.Threading;

namespace ThreadSummary.threadPool
{
    public class ThreadPoolUnity
    {
        public static void Do()
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                System.Console.WriteLine(obj);
            }, "nihao");
        }
        private static volatile int num = 0;
        public static void Timer()
        {
            ThreadPool.RegisterWaitForSingleObject(new AutoResetEvent(true), (obj, flag) =>
            {
                System.Console.WriteLine($"{obj},计时次数为:{num++}");
            }, "我是计时器", 1000, false);
        }
    }
}
